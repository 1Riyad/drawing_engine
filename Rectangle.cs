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
        public override void Draw(Graphics graphic)
        {
            
        }

        public Rectangle(Point pointA, Point pointB)
        {
            this.pointA = pointA;
            this.pointB = pointB;
        }
    }
}
