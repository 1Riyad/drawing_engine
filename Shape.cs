using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LimitlessDrawEngine
{
    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public Point pointA { get; set; }
        public Point pointB { get; set; }
        public Color Color { get; set; }
        public bool isSelected { get; set; }
        public System.Drawing.Rectangle Selection { get; set; }
        
        public Shape(Pen pen, Point pointA, Point pointB)
        {
            this.Pen = pen;
            this.pointA = pointA;
            this.pointB = pointB;

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

            using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(Selection);
                contains = gp.IsVisible(point);
            }

            return contains;
        }

        public virtual void update()
        {
            int outline = 5;
            int width = Math.Max(this.pointA.X, this.pointB.X) - Math.Min(this.pointA.X, this.pointB.X);
            int height = Math.Max(this.pointA.Y, this.pointB.Y) - Math.Min(this.pointA.Y, this.pointB.Y);
            Point topLeftCornet = new Point(Math.Min(this.pointA.X, this.pointB.X) - outline, Math.Min(this.pointA.Y, this.pointB.Y) - outline);
            this.Selection = new System.Drawing.Rectangle(topLeftCornet, new Size(width + (outline * 2), height + (outline * 2)));
        }

        public void move(int x, int y)
        {
            this.pointA = new Point(this.pointA.X + x, this.pointA.Y + y);
            this.pointB = new Point(this.pointB.X + x, this.pointB.Y + y);
        }

        public void resize(float scale)
        {
            scale /= 2;

            if(this.pointA.X > this.pointB.X)
            {
                this.pointA = new Point(this.pointA.X + (int)(this.pointA.X * scale), this.pointA.Y);
                this.pointB = new Point(this.pointB.X - (int)(this.pointA.X * scale), this.pointB.Y);
            }
            else
            {
                this.pointA = new Point(this.pointA.X - (int)(this.pointA.X * scale), this.pointA.Y);
                this.pointB = new Point(this.pointB.X + (int)(this.pointA.X * scale), this.pointB.Y);
            }

            if (this.pointA.Y > this.pointB.Y)
            {
                this.pointA = new Point(this.pointA.X, this.pointA.Y + (int)(this.pointA.Y * scale));
                this.pointB = new Point(this.pointB.X, this.pointB.Y - (int)(this.pointA.Y * scale));
            }
            else
            {
                this.pointA = new Point(this.pointA.X, this.pointA.Y - (int)(this.pointA.Y * scale));
                this.pointB = new Point(this.pointB.X, this.pointB.Y + (int)(this.pointA.Y * scale));
            }

            update();
        }
    }
}