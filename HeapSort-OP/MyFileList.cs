using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALG_LAB_1;

namespace HeapSort_OP
{
    class MyFileList : DataList
    {
        private int prevvious;
        private int current;
        private int next;
        private string fileName;

        public MyFileList(string fileName, int n, int seed)
        {
            this.fileName = fileName;
            length = n;
            Random random = new Random(seed);
            if (File.Exists(fileName))
                File.Delete(fileName);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write(4);
                    for (int i = 0; i < length; i++)
                    {
                        writer.Write(random.Next(10000));
                        writer.Write((i + 1) * 8 + 4);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public FileStream fs { get; set; }
        public override int Head()
        {
            Byte[] data = new byte[8];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            current = BitConverter.ToInt32(data, 0);
            prevvious = -1;
            fs.Seek(current, SeekOrigin.Begin);
            fs.Read(data, 0, 8);
            int result = BitConverter.ToInt32(data, 0);
            next = BitConverter.ToInt32(data, 4);
            return result;
        }

        public override int Next()
        {
            Byte[] data = new Byte[8];
            fs.Seek(next, SeekOrigin.Begin);
            fs.Read(data, 0, 8);
            prevvious = current;
            current = next;
            int result = BitConverter.ToInt32(data, 0);
            next = BitConverter.ToInt32(data, 4);

            if (next == 0)
            {
                current = -1;
                return 0;
            }

            return result;
        }

        public override int Get(int index)
        {
            Byte[] data = new Byte[4];
            fs.Seek(8 * (index) + 4, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            return BitConverter.ToInt32(data, 0);
        }

        public override void Set(int index, int data)
        {
            Byte[] d = new Byte[4];
            fs.Seek(8 * (index) + 4, SeekOrigin.Begin);
            BitConverter.GetBytes(data).CopyTo(d, 0);
            fs.Write(d, 0, 4);
        }

        public override int Min()
        {
            Byte[] data = new Byte[4];
            fs.Seek(4, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            int minValue = BitConverter.ToInt32(data, 0);

            for (Head(); current != -1; Next())
            {
                if (Current() < minValue)
                {
                    minValue = Current();
                }
            }

            return minValue;
        }

        public override int Max()
        {
            Byte[] data = new Byte[4];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            int maxValue = BitConverter.ToInt32(data, 0);

            for (Head(); current != -1; Next())
            {
                if (Current() > maxValue)
                {
                    maxValue = Current();
                }
            }

            return maxValue;
        }

        public override int Current()
        {
            Byte[] data = new Byte[4];
            fs.Seek(current, SeekOrigin.Begin);
            fs.Read(data, 0, 4);
            return BitConverter.ToInt32(data, 0);
        }

        public override void Change(int data)
        {
            Byte[] d = BitConverter.GetBytes(data);
            fs.Seek(current, SeekOrigin.Begin);
            fs.Write(d, 0, 4);
        }
    }
}
