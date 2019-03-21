using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALG_LAB_1;

namespace HeapSort_OP
{
    class MyFileArray : DataArray
    {
        public MyFileArray(string fileName, int n, int seed)
        {
            int[] Data = new int[n];
            length = n;
            Random random = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                Data[i] = random.Next(10000);
            }
            if(File.Exists(fileName))
                File.Delete(fileName);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    for (int i = 0; i < length; i++)
                        writer.Write(Data[i]);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public FileStream fs { get; set; }

        public override int this[int index]
        {
            get
            {
                Byte[] data = new Byte[4];
                fs.Seek(4 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 4);
                int result = BitConverter.ToInt32(data, 0);
                return result;
            }
            set
            {
                Byte[] data = new Byte[4];
                BitConverter.GetBytes(value).CopyTo(data, 0);
                fs.Seek(4 * index, SeekOrigin.Begin);
                fs.Write(data, 0, 4);
            }
        }
    }
}
