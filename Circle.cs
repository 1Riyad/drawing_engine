using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessDrawEngine
{
    public class Circle : Shape
    {
        public Point TopLeftCorner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Circle(Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB)
        {
            this.update();
        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawEllipse(this.Pen, this.TopLeftCorner.X, this.TopLeftCorner.Y, this.Width, this.Height);
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
