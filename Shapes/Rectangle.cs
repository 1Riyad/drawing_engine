using System.Drawing;

namespace DrawingEngine.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB) {}

        public override void Draw(Graphics graphic)
        {
            graphic.DrawRectangle(this.Pen, TopLeftCorner.X, TopLeftCorner.Y, Width, Height);
        }
        
        public override string ToString()
        {
            return $"rect {this.PointA.X} {this.PointA.Y} {this.PointB.X} {this.PointB.Y} #{this.Pen.Color.Name} {this.Pen.DashStyle} {this.Pen.Width}";
        }
    }
}
