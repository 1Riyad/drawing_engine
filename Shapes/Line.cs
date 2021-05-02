using System.Drawing;

namespace LimitlessDrawEngine
{
    public class Line : Shape
    {
        public Line (Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB) {}

        public override void Draw(Graphics graphic)
        {
            graphic.DrawLine(this.Pen, PointA, PointB);
        }
    }
}
