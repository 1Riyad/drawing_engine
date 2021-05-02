using System.Drawing;

namespace LimitlessDrawEngine.Shapes
{
    public class Circle : Shape
    {
        public Circle(Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB) {}

        public override void Draw(Graphics graphic)
        {
            graphic.DrawEllipse(this.Pen, this.TopLeftCorner.X, this.TopLeftCorner.Y, this.Width, this.Height);
        }
        
        public override string ToString()
        {
            return $"cir {this.PointA.X} {this.PointA.Y} {this.PointB.X} {this.PointB.Y} #{this.Pen.Color.Name} {this.Pen.DashStyle} {this.Pen.Width}";
        }
    }
}
