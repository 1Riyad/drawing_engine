﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessDrawEngine
{
    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public Point pointA { get; set; }
        public Point pointB { get; set; }
        public Color Color { get; set; }
        public bool isSelected { get; set; }
        
        public Shape(Pen pen, Point pointA, Point pointB)
        {
            this.Pen = pen;
            this.pointA = pointA;
            this.pointB = pointB;
        }

        public abstract void Draw(Graphics graphic);
    }
}