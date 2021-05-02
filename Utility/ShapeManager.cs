using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LimitlessDrawEngine
{
    public class ShapeManager
    {
        private static readonly byte[] Magic_Number = { 200, 30, 6 };
        private static readonly byte[] Version = { 0, 1, 0 };
        //private static readonly string extension = ".drw";

        public static void save(List<string> sourceCode)
        {
            FileMode mode = FileMode.Create;
            string fileName = "";
            string path = @"C:\";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = path;
            saveFileDialog1.Filter = "drw files (*.drw)|*.drw";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
            }

            if (File.Exists(fileName))
                mode = FileMode.Open;

            using (FileStream fs = new FileStream(fileName, mode)) //FileStream fs = File.Create(path)
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(Magic_Number[0]);
                    writer.Write(Magic_Number[1]);
                    writer.Write(Magic_Number[2]);

                    writer.Write(Version[0]);
                    writer.Write(Version[1]);
                    writer.Write(Version[2]);

                    writer.Write(sourceCode.Count);

                    foreach (var text in sourceCode)
                    {
                        writer.Write(text);
                    }

                    writer.Close();
                }
            }
        }

        public static List<string> load()
        {
            string filePath = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "drw files (*.drw)|*.drw";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }

            List<string> sourceCode = new();

            if (File.Exists(filePath))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    if (reader.BaseStream.Length < 7)
                    {
                        reader.Close();
                        throw new Exception("Error wrong file format");
                    }

                    for (int i = 0; i < 3; i++)
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

                    for (int i = 0; i < count; i++)
                    {
                        sourceCode.Add(reader.ReadString());
                    }

                    reader.Close();
                }
            }
            //MessageBox.Show(String.Join("\n", sourceCode));

            return sourceCode;
        }
    }
}