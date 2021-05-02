﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace LimitlessDrawEngine
{
    public class ShapeManager
    {
        private static readonly byte[] Magic_Number = { 200, 30, 6 };
        private static readonly byte[] Version = { 0, 1, 0 };
        private static readonly string ext = ".limitless";

        // close your eyes before running
        // this is untested code
        public static void save(List<Shape> shapes, string filePath)
        {
            filePath = filePath + ext;
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
                    if (shape.GetType() == typeof(Line))
                    {
                        writer.Write("line");
                    }
                    else if (shape.GetType() == typeof(Rectangle))
                    {
                        writer.Write("rectangle");
                    }
                    else if (shape.GetType() == typeof(Circle))
                    {
                        writer.Write("circle");
                    }

                    writer.Write(shape.PointA.X);
                    writer.Write(shape.PointA.Y);

                    writer.Write(shape.PointB.X);
                    writer.Write(shape.PointB.Y);

                    writer.Write(shape.Pen.Color.Name);
                    writer.Write((int)shape.Pen.DashStyle);
                    writer.Write(shape.Pen.Width);
                }

                writer.Close();
            }
        }

        public static List<Shape> load(string filePath)
        {
            filePath = filePath + ext;
            List<Shape> shapes = new();

            if (File.Exists(filePath))
            {
                List<byte> buffer = new();

                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    if(reader.BaseStream.Length < 7)
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
                        Point pointA = new Point(reader.ReadInt32(), reader.ReadInt32());
                        Point pointB = new Point(reader.ReadInt32(), reader.ReadInt32());
                        Pen pen = new Pen(Color.FromName(reader.ReadString()), reader.ReadSingle());

                        Shape shape = null;

                        switch(type)
                        {
                            case "line":
                                shape = new Line(pen, pointA, pointB);
                                break;
                            case "rectangle":
                                shape = new Rectangle(pen, pointA, pointB);
                                break;
                            case "circle":
                                shape = new Circle(pen, pointA, pointB);
                                break;
                        }

                        if (shape != null)
                            shapes.Add(shape);
                    }

                    reader.Close();
                }
            }

            return shapes;
        }
    }
}
