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

        public Form1()
        {
            canvas = new Canvas();

            InitializeComponent();
        }

        private void drawingCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            canvas.draw(graphic);
        }

        private void drawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.canvas.pointA.X = e.X;
            this.canvas.pointA.Y = e.Y;
        }

        private void drawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.canvas.pointB.X = e.X;
            this.canvas.pointB.Y = e.Y;
            this.canvas.Pen.DashStyle = this.getDashStyle();

            this.canvas.addShape();

            this.drawingCanvas.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.canvas.Pen.Width = (float) this.numericUpDown1.Value;
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            updateColor();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.canvas.Type = ShapeType.Line;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.canvas.Type = ShapeType.RectAngle;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.canvas.Type = ShapeType.Circle;
        }

        private void updateColor()
        {
            ColorDialog colorPicker = new ColorDialog();

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                this.panel3.BackColor = colorPicker.Color;
                this.canvas.Pen.Color = colorPicker.Color;
            }
        }

        private DashStyle getDashStyle()
        {
            switch (this.comboBox3.SelectedIndex)
            {
                case 0:
                    return DashStyle.Solid;
                case 1:
                    return DashStyle.Dot;
                case 2:
                    return DashStyle.Dash;
                case 3:
                    return DashStyle.DashDot;
                case 4:
                    return DashStyle.DashDotDot;
            }

            return DashStyle.Solid;
        }
    }
}
