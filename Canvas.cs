using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LimitlessDrawEngine
{
    public class Canvas
    {
        public List<Shape> Shapes { get; set; }
        public Color CurrentColor { get; set; }
        public PictureBox CurrentColorDisplay { get; set; }
        public ShapeType Type { get; set; }
        public Shape SelectedShape { get; set; }
        public Pen Pen { get; set; }

        public Point pointA = new Point(0, 0);
        public Point pointB = new Point(0, 0);

        public Canvas()
        {
            this.Pen = new Pen(Brushes.Black, 2);
            this.Type = ShapeType.None;
            this.Shapes = ShapeManager.load(@"");
        }

        public void addLine()
        {
            Line line = new Line(new Pen(this.Pen.Brush, this.Pen.Width), pointA, pointB);
            this.Shapes.Add(line);
        }

        public void addRectangle()
        {
            Rectangle rectangle = new Rectangle(new Pen(this.Pen.Brush, this.Pen.Width), pointA, pointB);
            this.Shapes.Add(rectangle);
        }

        public void addCircle()
        {
            Circle circle = new Circle(new Pen(this.Pen.Brush, this.Pen.Width), pointA, pointB);
            this.Shapes.Add(circle);
        }

        public void draw(Graphics graphic)
        {
            foreach(var shape in Shapes)
            {
                shape.Draw(graphic);
            }
        }
    }
}
