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
        public Point TopLeftCorner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB)
        {
            this.update();
        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawRectangle(this.Pen, TopLeftCorner.X, TopLeftCorner.Y, Width, Height);
        }

        public override void update()
        {
            base.update();

            int xDistance = Math.Max(this.pointA.X, this.pointB.X) - Math.Min(this.pointA.X, this.pointB.X);
            int yDistance = Math.Max(this.pointA.Y, this.pointB.Y) - Math.Min(this.pointA.Y, this.pointB.Y);
            this.TopLeftCorner = new Point(Math.Min(this.pointA.X, this.pointB.X), Math.Min(this.pointA.Y, this.pointB.Y));
            this.Width = xDistance;
            this.Height = yDistance;
        }
    }
}
