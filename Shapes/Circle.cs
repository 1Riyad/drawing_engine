using System.Drawing;

namespace LimitlessDrawEngine
{
    public class Circle : Shape
    {
        public Circle(Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB) {}

        public override void Draw(Graphics graphic)
        {
            graphic.DrawEllipse(this.Pen, this.TopLeftCorner.X, this.TopLeftCorner.Y, this.Width, this.Height);
        }
    }
}
