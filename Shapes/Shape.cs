﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LimitlessDrawEngine
{
    public abstract class Shape
    {
        public Pen Pen { get; set; }
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point Center { get; set; }
        public Color Color { get; set; }
        public bool isSelected { get; set; }
        public System.Drawing.Rectangle Selection { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<System.Drawing.Rectangle> ResizeControls = new();
        
        public Shape(Pen pen, Point pointA, Point pointB)
        {
            this.Pen = pen;
            this.PointA = pointA;
            this.PointB = pointB;

            this.update();
        }

        public abstract void Draw(Graphics graphic);

        public void DrawSelection(Graphics graphic)
        {
            Pen selectionPen = new Pen(Brushes.Red, 2);
            selectionPen.DashStyle = DashStyle.Dash;

            if (this is Line)
            {
                graphic.FillEllipse(Brushes.Red, this.ResizeControls[0]);
                graphic.FillEllipse(Brushes.Red, this.ResizeControls[1]);
                return;
            }
            
            graphic.DrawRectangle(selectionPen, this.Selection);
            
            graphic.FillEllipse(Brushes.Red, this.ResizeControls[0]);
            graphic.FillEllipse(Brushes.Red, this.ResizeControls[1]);
            graphic.FillEllipse(Brushes.Red, this.ResizeControls[2]);
            graphic.FillEllipse(Brushes.Red, this.ResizeControls[3]);
        }

        public bool Contains(Point point)
        {
            var contains = false;

            using (var gp = new GraphicsPath())
            {
                gp.AddRectangle(Selection);
                contains = gp.IsVisible(point);
            }

            return contains;
        }
        
        public bool ResizeControlContains(Point mousePoint, out Direction direction)
        {
            direction = Direction.UP;

            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(this.ResizeControls[0]);

                if (gp.IsVisible(mousePoint))
                {
                    direction = this.ResizeControls[0].Y > this.ResizeControls[2].Y ? Direction.UP : Direction.DOWN;
                    return true;
                }
            }
            
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(this.ResizeControls[2]);

                if (gp.IsVisible(mousePoint))
                {
                    direction = this.ResizeControls[2].Y > this.ResizeControls[0].Y ? Direction.UP : Direction.DOWN;
                    return true;
                }
            }
            
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(this.ResizeControls[1]);

                if (gp.IsVisible(mousePoint))
                {
                    direction = this.ResizeControls[1].X > this.ResizeControls[3].X ? Direction.RIGHT : Direction.LEFT;
                    return true;
                }
            }
            
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(this.ResizeControls[3]);

                if (gp.IsVisible(mousePoint))
                {
                    direction = this.ResizeControls[3].Y > this.ResizeControls[1].Y ? Direction.RIGHT : Direction.LEFT;
                    return true;
                }
            }
            
            return false;
        }

        public virtual void update()
        {
            int outline = 5;
            int width = Math.Max(this.PointA.X, this.PointB.X) - Math.Min(this.PointA.X, this.PointB.X);
            int height = Math.Max(this.PointA.Y, this.PointB.Y) - Math.Min(this.PointA.Y, this.PointB.Y);
            
            this.Width = width;
            this.Height = height;

            Point topLeftCornet = new Point(Math.Min(this.PointA.X, this.PointB.X) - outline, Math.Min(this.PointA.Y, this.PointB.Y) - outline);
            this.Selection = new System.Drawing.Rectangle(topLeftCornet, new Size(width + (outline * 2), height + (outline * 2)));

            int x = Math.Min(this.PointA.X, this.PointB.X) + (this.Width / 2);
            int y = Math.Min(this.PointA.Y, this.PointB.Y) + (this.Height / 2);
            this.Center = new Point(x, y);

            int x1, x2, x3, x4;
            int y1, y2, y3, y4;
            
            int resizeControlWidth = 8;
            
            if (this is Line)
            {
                x1 = this.PointA.X - (resizeControlWidth / 2);
                x2 = this.PointB.X - (resizeControlWidth / 2);

                y1 = this.PointA.Y - (resizeControlWidth / 2);
                y2 = this.PointB.Y - (resizeControlWidth / 2);
                
                ResizeControls.Add(new System.Drawing.Rectangle(x1, y1, resizeControlWidth, resizeControlWidth));
                ResizeControls.Add(new System.Drawing.Rectangle(x2, y2, resizeControlWidth, resizeControlWidth));
                return;
            }
            
            x1 = this.Center.X - (resizeControlWidth / 2);
            x3 = this.Center.X - (resizeControlWidth / 2);
            x2 = this.Center.X + (this.Selection.Width / 2) - (resizeControlWidth / 2);
            x4 = this.Center.X - (this.Selection.Width / 2) - (resizeControlWidth / 2);

            y1 = this.Center.Y - (this.Selection.Height / 2) - (resizeControlWidth / 2);
            y3 = this.Center.Y + (this.Selection.Height / 2) - (resizeControlWidth / 2);
            y2 = this.Center.Y - (resizeControlWidth / 2);
            y4 = this.Center.Y - (resizeControlWidth / 2);
            
            ResizeControls.Add(new System.Drawing.Rectangle(x1, y1, resizeControlWidth, resizeControlWidth));
            ResizeControls.Add(new System.Drawing.Rectangle(x2, y2, resizeControlWidth, resizeControlWidth));
            ResizeControls.Add(new System.Drawing.Rectangle(x3, y3, resizeControlWidth, resizeControlWidth));
            ResizeControls.Add(new System.Drawing.Rectangle(x4, y4, resizeControlWidth, resizeControlWidth));
        }

        public void move(int x, int y)
        {
            this.PointA = new Point(this.PointA.X + x, this.PointA.Y + y);
            this.PointB = new Point(this.PointB.X + x, this.PointB.Y + y);
            
            update();
        }
        
        public void resize(Direction direction, int value)
        {
            // resize

            update();
        }
    }
}