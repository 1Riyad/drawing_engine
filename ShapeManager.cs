using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessDrawEngine
{
    public class ShapeManager
    {
        private static readonly byte[] Magic_Number = { 26, 26, 26 };
        private static readonly byte[] Version = { 0, 1, 0 };

        // close your eyes before running
        // this is untested code
        public static void save(List<Shape> shapes, string filePath)
        {
            filePath = filePath + ".limitless";
            FileMode mode = FileMode.Create;

            if (File.Exists(filePath))
                mode = FileMode.Open;

            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, mode)))
            {
                writer.Write(Magic_Number[0]);
                writer.Write(Magic_Number[1]);
                writer.Write(Magic_Number[2]);

                writer.Write(Version[0]);
                writer.Write(Version[1]);
                writer.Write(Version[2]);

                writer.Write(shapes.Count);

                foreach(var shape in shapes)
                {
                    if(shape.GetType() == typeof(Line))
                    {
                        Line line = (Line)shape;
                        writer.Write("line");
                        writer.Write(line.pointA.X);
                        writer.Write(line.pointA.Y);

                        writer.Write(line.pointB.X);
                        writer.Write(line.pointB.Y);

                        writer.Write(line.Pen.Color.Name);
                        writer.Write((int)line.Pen.DashStyle);
                        writer.Write(line.Pen.Width);
                    }
                    else if(shape.GetType() == typeof(Rectangle))
                    {
                        Rectangle rectangle = (Rectangle)shape;
                        writer.Write("rectangle");
                        writer.Write(rectangle.pointA.X);
                        writer.Write(rectangle.pointA.Y);

                        writer.Write(rectangle.pointB.X);
                        writer.Write(rectangle.pointB.Y);

                        writer.Write(rectangle.Pen.Color.Name);
                        writer.Write((int)rectangle.Pen.DashStyle);
                    }
                    else if (shape.GetType() == typeof(Circle))
                    {
                        Circle circle = (Circle)shape;
                        writer.Write("circle");
                        writer.Write(circle.pointA.X);
                        writer.Write(circle.pointA.Y);

                        writer.Write(circle.pointB.X);
                        writer.Write(circle.pointB.Y);

                        writer.Write(circle.Pen.Color.Name);
                        writer.Write((int)circle.Pen.DashStyle);
                    }
                }

                writer.Close();
            }
        }

        public static List<Shape> load(string filePath)
        {
            filePath = filePath + ".limitless";
            List<Shape> shapes = new();

            if (File.Exists(filePath))
            {
                List<byte> buffer = new();

                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    if(reader.BaseStream.Length < 10)
                    {
                        reader.Close();
                        throw new Exception("Error wrong file format");
                    }

                    for(int i = 0; i < 3; i++)
                    {
                        if (reader.ReadByte() != Magic_Number[i])
                        {
                            reader.Close();
                            throw new Exception("Error wrong file format");
                        }
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (reader.ReadByte() != Version[i])
                        {
                            reader.Close();
                            throw new Exception("Error wrong file format");
                        }
                    }

                    int count = reader.ReadInt32();

                    for(int i = 0; i < count; i++)
                    {
                        string type = reader.ReadString();

                        switch(type)
                        {
                            case "line":
                                Line line = loadLine(reader);
                                shapes.Add(line);
                                break;
                            case "rectangle":
                                Rectangle rectangle = loadRectangle(reader);
                                shapes.Add(rectangle);
                                break;
                            case "circle":
                                Circle circle = loadCircle(reader);
                                shapes.Add(circle);
                                break;
                        }
                    }

                    reader.Close();
                }
            }

            return shapes;
        }

        private static Line loadLine(BinaryReader reader)
        {
            Point pointA = new Point(reader.ReadInt32(), reader.ReadInt32());
            Point pointB = new Point(reader.ReadInt32(), reader.ReadInt32());
            Pen pen = new Pen(Color.FromName(reader.ReadString()), reader.ReadSingle());

            return new Line(pen, pointA, pointB);
        }

        private static Rectangle loadRectangle(BinaryReader reader)
        {
            Point pointA = new Point(reader.ReadInt32(), reader.ReadInt32());
            Point pointB = new Point(reader.ReadInt32(), reader.ReadInt32());
            Pen pen = new Pen(Color.FromName(reader.ReadString()), reader.ReadSingle());

            return new Rectangle(pen, pointA, pointB);
        }

        private static Circle loadCircle(BinaryReader reader)
        {
            Point pointA = new Point(reader.ReadInt32(), reader.ReadInt32());
            Point pointB = new Point(reader.ReadInt32(), reader.ReadInt32());
            Pen pen = new Pen(Color.FromName(reader.ReadString()), reader.ReadSingle());

            return new Circle(pen, pointA, pointB);
        }
    }
}
