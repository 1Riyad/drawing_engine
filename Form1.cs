using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessDrawEngine
{
    public partial class Form1 : Form
    {
        private Canvas canvas;
        private List<Shape> shapesList;

        // Canvas
        public ShapeType Type { get; set; }
        public Pen Pen { get; set; }
        public Shape SelectedShape { get; set; }

        // line code
        private Point pointA = new Point(0, 0);
        private Point pointB = new Point(0, 0);

        public Form1()
        {
            this.shapesList = new();
            this.Pen = new Pen(Brushes.Black, 2);
            Type = ShapeType.Line;

            InitializeComponent();
        }

        private void drawingCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;

            foreach(var shape in this.shapesList)
            {
                if(shape.GetType() == typeof(Line))
                {
                    graphic.DrawLine(shape.Pen, shape.pointA, shape.pointB);
                }
                else if (shape.GetType() == typeof(Rectangle))
                {
                    int xDistance = Math.Max(shape.pointA.X, shape.pointB.X) - Math.Min(shape.pointA.X, shape.pointB.X);
                    int yDistance = Math.Max(shape.pointA.Y, shape.pointB.Y) - Math.Min(shape.pointA.Y, shape.pointB.Y);
                    Point point = new Point(Math.Min(shape.pointA.X, shape.pointB.X) + (xDistance / 2), Math.Min(shape.pointA.Y, shape.pointB.Y) + (yDistance / 2));
                    int width = xDistance;
                    int height = yDistance;
                    graphic.DrawRectangle(shape.Pen, point.X, point.Y, width, height);
                }
                else if (shape.GetType() == typeof(Circle))
                {
                    int xDistance = Math.Max(shape.pointA.X, shape.pointB.X) - Math.Min(shape.pointA.X, shape.pointB.X);
                    int yDistance = Math.Max(shape.pointA.Y, shape.pointB.Y) - Math.Min(shape.pointA.Y, shape.pointB.Y);
                    Point point = new Point(Math.Min(shape.pointA.X, shape.pointB.X) + (xDistance / 2), Math.Min(shape.pointA.Y, shape.pointB.Y) + (yDistance / 2));
                    int width = xDistance;
                    int height = yDistance;

                    graphic.DrawEllipse(shape.Pen, point.X, point.Y, width, height);
                }
            }
        }

        private void drawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            pointA.X = e.X;
            pointA.Y = e.Y;
        }

        private void drawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            pointB.X = e.X;
            pointB.Y = e.Y;

            this.Pen.DashStyle = this.getDashStyle();

            switch(this.Type)
            {
                case ShapeType.Line:
                    Line line = new Line(pointA, pointB);
                    line.Pen = new Pen(this.Pen.Brush, this.Pen.Width);
                    this.shapesList.Add(line);
                    break;
                case ShapeType.RectAngle:
                    Rectangle rectangle = new Rectangle(pointA, pointB);
                    rectangle.Pen = new Pen(this.Pen.Brush, this.Pen.Width);
                    this.shapesList.Add(rectangle);
                    break;
                case ShapeType.Circle:
                    Circle circle = new Circle(pointA, pointB);
                    circle.Pen = new Pen(this.Pen.Brush, this.Pen.Width);
                    this.shapesList.Add(circle);
                    break;
            }

            this.drawingCanvas.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.Pen.Width = (float) this.numericUpDown1.Value;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                this.panel3.BackColor = colorPicker.Color;
                this.Pen.Color = colorPicker.Color;
            }
        }

        private DashStyle getDashStyle()
        {
            DashStyle result = DashStyle.Solid;

            switch (this.comboBox3.SelectedIndex)
            {
                case 0:
                    result = DashStyle.Solid;
                    break;
                case 1:
                    result = DashStyle.Dot;
                    break;
                case 2:
                    result = DashStyle.Dash;
                    break;
                case 3:
                    result = DashStyle.DashDot;
                    break;
                case 4:
                    result = DashStyle.DashDotDot;
                    break;
            }

            return result;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Type = ShapeType.Line;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Type = ShapeType.RectAngle;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Type = ShapeType.Circle;
        }
    }
}
