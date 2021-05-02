using System.Drawing;

namespace DrawingEngine.Shapes
{
    public class Line : Shape
    {
        public Line (Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB) {}

        public override void Draw(Graphics graphic)
        {
            graphic.DrawLine(this.Pen, PointA, PointB);
        }
        
        public override string ToString()
        {
            return $"line {this.PointA.X} {this.PointA.Y} {this.PointB.X} {this.PointB.Y} #{this.Pen.Color.Name} {this.Pen.DashStyle} {this.Pen.Width}";
        }
    }
}
