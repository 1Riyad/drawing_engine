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

            int xDistance = Math.Max(this.PointA.X, this.PointB.X) - Math.Min(this.PointA.X, this.PointB.X);
            int yDistance = Math.Max(this.PointA.Y, this.PointB.Y) - Math.Min(this.PointA.Y, this.PointB.Y);
            this.TopLeftCorner = new Point(Math.Min(this.PointA.X, this.PointB.X), Math.Min(this.PointA.Y, this.PointB.Y));
            this.Width = xDistance;
            this.Height = yDistance;
        }

        public override string ToString()
        {
            return $"cir {this.PointA.X} {this.PointA.Y} {this.PointB.X} {this.PointB.Y} #{this.Pen.Color.Name} {this.Pen.DashStyle} {this.Pen.Width}";
        }
    }
}
