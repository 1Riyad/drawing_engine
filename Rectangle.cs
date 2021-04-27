using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessDrawEngine
{
    public class Rectangle : Shape
    {
        public Rectangle(Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB) {}

        public override void Draw(Graphics graphic)
        {
            int xDistance = Math.Max(this.pointA.X, this.pointB.X) - Math.Min(this.pointA.X, this.pointB.X);
            int yDistance = Math.Max(this.pointA.Y, this.pointB.Y) - Math.Min(this.pointA.Y, this.pointB.Y);
            Point point = new Point(Math.Min(this.pointA.X, this.pointB.X), Math.Min(this.pointA.Y, this.pointB.Y));
            int width = xDistance;
            int height = yDistance;

            graphic.DrawRectangle(this.Pen, point.X, point.Y, width, height);
        }
    }
}
