using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitlessDrawEngine
{
    public class Canvas
    {
        public Graphics Graphic { get; set; }
        public List<Shape> Shapes { get; set; }
        public Color CurrentColor { get; set; }
        public PictureBox CurrentColorDisplay { get; set; }
        public ShapeType Type { get; set; }
        public Shape SelectedShape { get; set; }

        public Canvas(Graphics Graphic)
        {
            this.Graphic = Graphic;
            this.Shapes = new();
        }

        public void addShape()
        {

        }

        public void removeShape(Shape shape)
        {

        }

        public void draw()
        {
            // for loop and call shape.draw
        }
    }
}
