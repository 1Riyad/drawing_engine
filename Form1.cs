﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LimitlessDrawEngine
{
    public partial class Form1 : Form
    {
        private Canvas canvas;
        bool isDrawing;
        Shape preview;
        Point startPoint;


        public Form1()
        {
            canvas = new Canvas();
            InitializeComponent();
            this.comboBox3.SelectedIndex = 0;
        }

        private void drawingCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            canvas.draw(graphic);
            
            if (preview != null)
            {
                preview.Draw(graphic);
            }
        }

        private void drawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = new Point(e.X,e.Y);
            this.canvas.MouseDown(new Point(e.X, e.Y));

            if (this.canvas.SelectedShape != null)
            {
                if (!this.canvas.SelectedShape.Contains(startPoint))
                {
                    this.canvas.SelectedShape.isSelected = false;
                    this.canvas.SelectedShape = null;
                    return;
                }
                
                this.numericUpDown1.Value = (decimal)this.canvas.SelectedShape.Pen.Width;
                this.panel3.BackColor = this.canvas.SelectedShape.Pen.Color;
                this.comboBox3.SelectedIndex = (int)this.canvas.SelectedShape.Pen.DashStyle;
            }
            else if (this.canvas.Mode != CursorMode.Selection)
            {
                isDrawing = true;
                this.canvas.Pen.Color = this.panel3.BackColor;
                Point pointA = new Point(e.X, e.Y);
                Point pointB = new Point(e.X, e.Y);
                Pen pen; 
            }

            this.drawingCanvas.Invalidate();
        }



        private void drawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.canvas.IsMouseDown = false;
            isDrawing = false;
            preview = null;
            this.canvas.ResizeMode = false;

            this.canvas.pointB.X = e.X;
            this.canvas.pointB.Y = e.Y;
            this.canvas.Pen.DashStyle = (DashStyle) this.comboBox3.SelectedIndex;
  

            if (!this.selectShape.Checked)
                this.canvas.addShape();
            
            this.drawingCanvas.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.canvas.Pen.Width = (float) this.numericUpDown1.Value;

            if(this.canvas.SelectedShape != null)
            {
                this.canvas.SelectedShape.Pen.Width = (float)this.numericUpDown1.Value;
                this.drawingCanvas.Invalidate();
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            updateColor();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.canvas.SelectedShapeType = ShapeType.Line;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.canvas.SelectedShapeType = ShapeType.RectAngle;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.canvas.SelectedShapeType = ShapeType.Circle;
        }

        private void updateColor()
        {
            ColorDialog colorPicker = new ColorDialog();

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                this.panel3.BackColor = colorPicker.Color;
                this.canvas.Pen.Color = colorPicker.Color;
                
                if(this.canvas.SelectedShape != null)
                {
                    this.canvas.SelectedShape.Pen.Color = colorPicker.Color;
                    this.drawingCanvas.Invalidate();
                }
            }
        }

        private void selectShape_CheckedChanged(object sender, EventArgs e)
        {
            if(this.selectShape.Checked)
            {
                this.canvas.Mode = CursorMode.Selection;
                return;
            }

            if(this.canvas.SelectedShape != null)
            {
                this.canvas.SelectedShape.isSelected = false;
                this.canvas.SelectedShape = null;
                this.canvas.Mode = CursorMode.Drawing;
                this.drawingCanvas.Invalidate();
                return;
            }

            this.canvas.Mode = CursorMode.Drawing;
        }

        private void drawingCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if(this.canvas.Mode == CursorMode.Selection)
                this.canvas.toggleSelection(new Point(e.X, e.Y));

            if (this.canvas.SelectedShape != null)
            {
                this.numericUpDown1.Value = (decimal)this.canvas.SelectedShape.Pen.Width;
                this.panel3.BackColor = this.canvas.SelectedShape.Pen.Color;
                this.comboBox3.SelectedIndex = (int)this.canvas.SelectedShape.Pen.DashStyle;
                this.drawingCanvas.Invalidate();
            }
        }

        private void drawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && this.canvas.SelectedShape == null)
            {
                Point pointA = startPoint;
                Point pointB = new Point(e.X, e.Y);
                Pen pen = new Pen(this.canvas.Pen.Brush, this.canvas.Pen.Width);
                pen.DashStyle = this.canvas.Pen.DashStyle;
                
                switch (this.canvas.SelectedShapeType)
                {
                    case ShapeType.Line:
                        pen = new Pen(this.canvas.Pen.Brush, this.canvas.Pen.Width);
                        pen.DashStyle = this.canvas.Pen.DashStyle;
                        preview = new Line(pen, pointA, pointB);
                        break;
                    case ShapeType.RectAngle:
                        pen = new Pen(this.canvas.Pen.Brush, this.canvas.Pen.Width);
                        pen.DashStyle = this.canvas.Pen.DashStyle;
                        preview = new Rectangle(pen, pointA, pointB);
                        break;
                    case ShapeType.Circle:
                        pen = new Pen(this.canvas.Pen.Brush, this.canvas.Pen.Width);
                        pen.DashStyle = this.canvas.Pen.DashStyle;
                        preview = new Circle(pen, pointA, pointB);
                        break;
                }
                
                this.drawingCanvas.Invalidate();
            }
            else if(this.canvas.MouseMove(new Point(e.X, e.Y)))
            {
                this.drawingCanvas.Invalidate();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.canvas.SelectedShape != null)
            {
                this.canvas.SelectedShape.Pen.DashStyle = (DashStyle)this.comboBox3.SelectedIndex;
                this.drawingCanvas.Invalidate();
            }
        }
    }
}
