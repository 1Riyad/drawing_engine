using System;
using System.Collections.Generic;
using System.Drawing;

namespace LimitlessDrawEngine
{
    public class Rectangle : Shape
    {
        public Point TopLeftCorner { get; set; }

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

            int xDistance = Math.Max(this.PointA.X, this.PointB.X) - Math.Min(this.PointA.X, this.PointB.X);
            int yDistance = Math.Max(this.PointA.Y, this.PointB.Y) - Math.Min(this.PointA.Y, this.PointB.Y);
            this.TopLeftCorner = new Point(Math.Min(this.PointA.X, this.PointB.X), Math.Min(this.PointA.Y, this.PointB.Y));
            this.Width = xDistance;
            this.Height = yDistance;
        }
        
        public override string ToString()
        {
            return $"rect {this.PointA.X} {this.PointA.Y} {this.PointB.X} {this.PointB.Y} #{this.Pen.Color.Name} {this.Pen.DashStyle} {this.Pen.Width}";
        }
    }
}
