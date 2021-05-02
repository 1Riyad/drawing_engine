using System.Collections.Generic;
using System.Drawing;
using LimitlessDrawEngine.Shapes;

namespace LimitlessDrawEngine.Canvas
{
    public class Canvas
    {
        public List<Shape> Shapes { get; }
        public ShapeType SelectedShapeType { get; set; }
        public Shape SelectedShape { get; set; }
        public Pen Pen { get; }
        public Point pointA;
        public Point pointB;
        public Point DeltaCenter { get; set; }

        public bool ResizeMode { get; set; }
        public Direction direction { get; set; }
        public bool IsMouseDown { get; set; }
        public CursorMode Mode { get; set; }

        public Canvas()
        {
            this.Pen = new Pen(Brushes.Black, 2);
            this.Shapes = new();
            this.SelectedShapeType = ShapeType.None;
        }

        public void addShape()
        {
            switch (this.SelectedShapeType)
            {
                case ShapeType.Line:
                    this.addLine();
                    break;
                case ShapeType.RectAngle:
                    this.addRectangle();
                    break;
                case ShapeType.Circle:
                    this.addCircle();
                    break;
            }
        }

        public void MouseDown(Point mousePoint)
        {
            this.IsMouseDown = true;
            this.pointA.X = mousePoint.X;
            this.pointA.Y = mousePoint.Y;

            if (this.SelectedShape != null)
            {
                int x = mousePoint.X - this.SelectedShape.Center.X;
                int y = mousePoint.Y - this.SelectedShape.Center.Y;

                this.DeltaCenter = new Point(x, y);

                Direction direction;
                
                foreach (var shape in this.Shapes)
                {
                    if (shape.ResizeControlContains(mousePoint))
                    {
                        this.ResizeMode = true;
                    }
                }
            }
        }

        private void addLine()
        {
            Pen pen = new Pen(this.Pen.Brush, this.Pen.Width);
            pen.DashStyle = this.Pen.DashStyle;
            Line line = new Line(pen, pointA, pointB);
            this.Shapes.Add(line);
        }

        private void addRectangle()
        {
            Pen pen = new Pen(this.Pen.Brush, this.Pen.Width);
            pen.DashStyle = this.Pen.DashStyle;
            Shapes.Rectangle rectangle = new Shapes.Rectangle(pen, pointA, pointB);
            this.Shapes.Add(rectangle);
        }

        private void addCircle()
        {
            Pen pen = new Pen(this.Pen.Brush, this.Pen.Width);
            pen.DashStyle = this.Pen.DashStyle;
            Circle circle = new Circle(pen, pointA, pointB);
            this.Shapes.Add(circle);
        }

        public void draw(Graphics graphic)
        {
            foreach(var shape in Shapes)
            {
                shape.Draw(graphic);

                if (shape.isSelected)
                    shape.DrawSelection(graphic);
            }
        }

        public void toggleSelection(Point point)
        {
            Shape target = null;

            foreach (var shape in Shapes)
            {
                if (shape.Contains(point))
                {
                    if (shape.isSelected)
                        return;

                    target = shape;
                }
            }

            if(target != null)
            {
                target.isSelected = !target.isSelected;

                if (target.isSelected)
                {
                    if(this.SelectedShape != null)
                        this.SelectedShape.isSelected = false;

                    this.SelectedShape = target;
                }
                else
                {
                    this.SelectedShape = null;
                }
            }
            else if(this.SelectedShape != null)
            {
                this.SelectedShape.isSelected = false;
                this.SelectedShape = null;
            }
        }

        public bool MouseMove(Point mousePoint)
        {
            if(this.IsMouseDown && this.SelectedShape != null)
            {
                int cendx = mousePoint.X - this.SelectedShape.Center.X;
                int cendy = mousePoint.Y - this.SelectedShape.Center.Y;

                int x = cendx - this.DeltaCenter.X;
                int y = cendy - this.DeltaCenter.Y;

                if (!this.ResizeMode && this.Mode == CursorMode.Selection)
                {
                    this.SelectedShape.move(x, y);
                }
                else
                {
                    this.SelectedShape.resize(mousePoint);
                }
                return true;
            }

            return false;
        }
    }
}
