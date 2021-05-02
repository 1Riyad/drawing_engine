using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using LimitlessDrawEngine.Canvas;
using LimitlessDrawEngine.Shapes;
using LimitlessDrawEngine.Tokenizer;
using LimitlessDrawEngine.Utility;

namespace LimitlessDrawEngine
{
    public partial class Form1 : Form
    {
        private Canvas.Canvas canvas;
        bool isDrawing;
        Shape preview;
        Point startPoint;
        private RichTextBox text;
        private StringBuilder sb;
        string inputShape;
        List<string> allSourceCode;

        public Form1()
        {
            canvas = new Canvas.Canvas();
            InitializeComponent();
            this.comboBox3.SelectedIndex = 0;
            sourcePanel.Visible = false;
            this.allSourceCode = new ();
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
                        preview = new Shapes.Rectangle(pen, pointA, pointB);
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
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.drawingCanvas.Visible = true;
            this.sourcePanel.Visible = false;
            this.sourcePanel.Controls.Clear();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.sourcePanel.Visible = true;
        }
        
        private void sourcePanel_Paint(object sender, PaintEventArgs e)
        {
            printingShapesInfo();
            this.textBox1.Visible = true;
        }

        public void printingShapesInfo()
        {
            // Initialize the printing textBox
            text = new RichTextBox();
            text.ReadOnly = true;
            text.Location = new Point(2, 24);
            text.Size = new Size(750, 430);
            text.BackColor = Color.FloralWhite;
            sb = new StringBuilder(text.Text);

            // Initialize the `add` button
            Button b = new Button();
            b.Location = new Point(655, 2);
            //b.BackColor =  Color.White;
            b.Text = "Add";
            b.Click += new EventHandler(AddShapeButton_Click);


            foreach (var shape in canvas.Shapes)
            {
                sb.Append(Environment.NewLine);
                sb.Append(shape.ToString());
                text.Text = sb.ToString();
                //this.allSourceCode.Add(Environment.NewLine);
            }
            // add below to the panel
            sourcePanel.Controls.Add(b);
            sourcePanel.Controls.Add(textBox1);
            sourcePanel.Controls.Add(text);
        }

        private void AddShapeButton_Click(object sender, EventArgs e)
        {
           
            inputShape = textBox1.Text;

            DrawEngineParser d = new DrawEngineParser(this.canvas);
            d.ParsingToShape(d.Parse(inputShape));

            this.textBox1.Clear();
            this.sourcePanel.Controls.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.sourcePanel.Invalidate();
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (var str in canvas.Shapes) {
                allSourceCode.Add(str.ToString());
            }
            ShapeManager.save(this.allSourceCode);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            this.allSourceCode = ShapeManager.load();
            DrawEngineParser d = new DrawEngineParser(this.canvas);

            foreach (var line in allSourceCode)
            {
                d.ParsingToShape(d.Parse(line));
            }
            this.drawingCanvas.Invalidate();
            this.textBox1.Clear();
            this.sourcePanel.Controls.Clear();
        }
    }
}
