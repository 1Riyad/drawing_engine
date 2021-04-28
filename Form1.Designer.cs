
namespace LimitlessDrawEngine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.selectShape = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.shapes = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingCanvas = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.selectShape);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.shapes);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 70);
            this.panel1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(69, 29);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(77, 27);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // selectShape
            // 
            this.selectShape.AutoSize = true;
            this.selectShape.Location = new System.Drawing.Point(769, 34);
            this.selectShape.Name = "selectShape";
            this.selectShape.Size = new System.Drawing.Size(18, 17);
            this.selectShape.TabIndex = 10;
            this.selectShape.UseVisualStyleBackColor = true;
            this.selectShape.CheckedChanged += new System.EventHandler(this.selectShape_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(666, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Shape:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(537, 28);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 28);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(499, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 28);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(461, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 28);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // shapes
            // 
            this.shapes.AutoSize = true;
            this.shapes.Location = new System.Drawing.Point(398, 31);
            this.shapes.Name = "shapes";
            this.shapes.Size = new System.Drawing.Size(59, 20);
            this.shapes.TabIndex = 5;
            this.shapes.Text = "Shapes:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(152, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 28);
            this.panel3.TabIndex = 4;
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Solid",
            "Dot",
            "Dash",
            "DashDot",
            "DashDotDot"});
            this.comboBox3.Location = new System.Drawing.Point(187, 27);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(80, 28);
            this.comboBox3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pen:";
            // 
            // drawingCanvas
            // 
            this.drawingCanvas.BackColor = System.Drawing.Color.White;
            this.drawingCanvas.Location = new System.Drawing.Point(12, 102);
            this.drawingCanvas.Name = "drawingCanvas";
            this.drawingCanvas.Size = new System.Drawing.Size(858, 611);
            this.drawingCanvas.TabIndex = 1;
            this.drawingCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingCanvas_Paint);
            this.drawingCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawingCanvas_MouseClick);
            this.drawingCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingCanvas_MouseDown);
            this.drawingCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingCanvas_MouseMove);
            this.drawingCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingCanvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 725);
            this.Controls.Add(this.drawingCanvas);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Limitless Draw Engine 2000";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel drawingCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox selectShape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label shapes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

