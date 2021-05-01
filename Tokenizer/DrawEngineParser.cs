using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LimitlessDrawEngine.Tokenizer
{
    class DrawEngineParser
    {


        protected string Str = "string";
        protected string Number = "number"; 
        //protected string KeyNull = "null";
        protected string KeyComma = "comma";
        protected string KeyWhitespace = "whitespace";
        private Canvas canvas;

        public DrawEngineParser(Canvas canvas)
        {
            this.canvas = canvas;
        } 
        public List<Token> Parse(string ColorString)
        {
            Input input = new Input(ColorString);
            Tokenizer t = new Tokenizer(input, new Tokenizable[] {
                // handler
                new NumberTokenizer(),
                new WhiteSpaceTokenizer(),
                new StringTokenizer(),
                new CommaTokenizer()
            });

            return t.all();
        }


        protected void RemoveWhitespaces(ref List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Type == KeyWhitespace)
                {
                    tokens.RemoveAt(i);
                    i = -1;
                }
            }
        }

        public void ParsingToShape(List<Token> parsedList) {
            RemoveWhitespaces(ref parsedList);
            List<string> shape_types = new List<string> { "line", "rect", "cir" };

            if (parsedList[0].Type != Str) {
                throw new Exception("Invalid shape type"); }

            //else if (parsedList[0].Value == Str && parsedList[0] not in (shape_types))
              //  throw new Exception("Invalid value type,  it must be one of [line, rict, cir]");
            
            else if (parsedList[1].Type != Number)
            {
                throw new Exception("Invalid x for Point1, it must be a number");
            }
            else if (parsedList[2].Type != Number)
            {
                throw new Exception("Invalid y for Point1, it must be a number");
            }
            else if (parsedList[3].Type != Number)
            {
                throw new Exception("Invalid x for Point2, it must be a number");
            }
            else if (parsedList[4].Type != Number)
            {
                throw new Exception("Invalid y for Point2, it must be a number");
            }
            else if (parsedList[5].Type != Str)
            {
                throw new Exception("Invalid color type");
            }
            else if (parsedList[6].Type != Str)
            {
                throw new Exception("Invalid DashStyle type, it must be one of [Dot, Dash,...]");
            }
            else if (parsedList[7].Type != Number)
            {
                throw new Exception("Invalid Pen's width, it must be a number");   
            }
            CreateShape(parsedList);
        }

        protected void CreateShape(List<Token> parsedList)
        {
            switch (parsedList[0].Value) {
                // send data to canvas and call addShape
                case "line":
                    this.canvas.Type = ShapeType.Line;
                    this.canvas.pointA = new System.Drawing.Point(int.Parse(parsedList[1].Value), int.Parse(parsedList[2].Value));
                    this.canvas.pointA = new System.Drawing.Point(int.Parse(parsedList[3].Value), int.Parse(parsedList[4].Value));
                    this.canvas.Pen.Color = System.Drawing.Color.FromName(parsedList[5].Value);
                    switch (parsedList[6].Value.ToLower()) {
                        case "solid":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                            break;
                        case "dot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            break;
                        case "dash":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            break;
                        case "dashdot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            break;
                        case "dashdotdot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                            break;
                    }
                    this.canvas.Pen.Width = int.Parse(parsedList[7].Value);
                    this.canvas.addShape();
                    break;
                case "rect":
                    this.canvas.Type = ShapeType.RectAngle;
                    this.canvas.pointA = new System.Drawing.Point(int.Parse(parsedList[1].Value), int.Parse(parsedList[2].Value));
                    this.canvas.pointA = new System.Drawing.Point(int.Parse(parsedList[3].Value), int.Parse(parsedList[4].Value));
                    this.canvas.Pen.Color = System.Drawing.Color.FromName(parsedList[5].Value);
                    switch (parsedList[6].Value.ToLower())
                    {
                        case "solid":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                            break;
                        case "dot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            break;
                        case "dash":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            break;
                        case "dashdot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            break;
                        case "dashdotdot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                            break;
                    }
                    this.canvas.Pen.Width = int.Parse(parsedList[7].Value);
                    this.canvas.addShape();
                    break;
                case "cir":
                    this.canvas.Type = ShapeType.Circle;
                    this.canvas.pointA = new System.Drawing.Point(int.Parse(parsedList[1].Value), int.Parse(parsedList[2].Value));
                    this.canvas.pointA = new System.Drawing.Point(int.Parse(parsedList[3].Value), int.Parse(parsedList[4].Value));
                    this.canvas.Pen.Color = System.Drawing.Color.FromName(parsedList[5].Value);
                    switch (parsedList[6].Value.ToLower())
                    {
                        case "solid":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                            break;
                        case "dot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            break;
                        case "dash":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            break;
                        case "dashdot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                            break;
                        case "dashdotdot":
                            this.canvas.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                            break;
                    }
                    this.canvas.Pen.Width = int.Parse(parsedList[7].Value);
                    this.canvas.addShape();
                    break;
            }
        }

    }
}
