using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
