using System;
using System.Collections.Generic;
using System.Drawing;

namespace LimitlessDrawEngine
{
    public class Rectangle : Shape
    {
        public Rectangle(Pen pen, Point pointA, Point pointB) : base(pen, pointA, pointB) {}

        public override void Draw(Graphics graphic)
        {
            graphic.DrawRectangle(this.Pen, TopLeftCorner.X, TopLeftCorner.Y, Width, Height);
        }
    }
}
