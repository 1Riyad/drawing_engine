using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LimitlessDrawEngine
{
    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point Center { get; set; }
        public Color Color { get; set; }
        public bool isSelected { get; set; }
        public System.Drawing.Rectangle Selection { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Shape(Pen pen, Point pointA, Point pointB)
        {
            this.Pen = pen;
            this.PointA = pointA;
            this.PointB = pointB;

            this.update();
        }

        public abstract void Draw(Graphics graphic);

        public void DrawSelection(Graphics graphic)
        {
            Pen selectionPen = new Pen(Brushes.Red, 2);
            selectionPen.DashStyle = DashStyle.Dash;
            graphic.DrawRectangle(selectionPen, this.Selection);
        }

        public bool Contains(Point point)
        {
            var contains = false;

            using (var gp = new GraphicsPath())
            {
                gp.AddRectangle(Selection);
                contains = gp.IsVisible(point);
            }

            return contains;
        }

        public virtual void update()
        {
            int outline = 5;
            int width = Math.Max(this.PointA.X, this.PointB.X) - Math.Min(this.PointA.X, this.PointB.X);
            int height = Math.Max(this.PointA.Y, this.PointB.Y) - Math.Min(this.PointA.Y, this.PointB.Y);
            
            this.Width = width;
            this.Height = height;

            Point topLeftCornet = new Point(Math.Min(this.PointA.X, this.PointB.X) - outline, Math.Min(this.PointA.Y, this.PointB.Y) - outline);
            this.Selection = new System.Drawing.Rectangle(topLeftCornet, new Size(width + (outline * 2), height + (outline * 2)));

            this.Center = new Point(Math.Min(this.PointA.X, this.PointB.X) + (width / 2), Math.Min(this.PointA.Y, this.PointB.Y) + (height / 2));
        }

        public void move(int x, int y)
        {
            this.PointA = new Point(this.PointA.X + x, this.PointA.Y + y);
            this.PointB = new Point(this.PointB.X + x, this.PointB.Y + y);

            update();
        }

        public void resize(Direction direction, int value)
        {
            switch(direction)
            {
                case Direction.UP:
                    moveUp(value);
                    break;
                case Direction.DOWN:
                    moveDown(value);
                    break;
                case Direction.LEFT:
                    moveLeft(value);
                    break;
                case Direction.RIGHT:
                    moveRight(value);
                    break;
            }

            update();
        }

        public void moveUp(int value)
        {
            if (this.PointA.Y < this.PointB.Y)
                this.PointA = new Point(this.PointA.X, this.PointA.Y - value);
            else
                this.PointB = new Point(this.PointB.X, this.PointB.Y - value);
        }

        public void moveDown(int value)
        {
            if (this.PointA.Y > this.PointB.Y)
                this.PointA = new Point(this.PointA.X, this.PointA.Y + value);
            else
                this.PointB = new Point(this.PointB.X, this.PointB.Y + value);
        }

        public void moveLeft(int value)
        {
            if (this.PointA.X < this.PointB.X)
                this.PointA = new Point(this.PointA.X - value, this.PointA.Y);
            else
                this.PointB = new Point(this.PointB.X - value, this.PointB.Y - value);
        }

        public void moveRight(int value)
        {
            if (this.PointA.X > this.PointB.X)
                this.PointA = new Point(this.PointA.X + value, this.PointA.Y);
            else
                this.PointB = new Point(this.PointB.X + value, this.PointB.Y - value);
        }
    }
}