using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG_LAB_1
{
    class MyDataList : DataList
    {
        private sealed class Node
        {
            public Node Next { get; set; }
            public int Data { get; set; }

            public Node(int data)
            {
                this.Data = data;
            }
        }

        Node head;
        Node prev;
        Node current;

        public MyDataList()
        {
            head = null;
            prev = null;
            current = null;
        }
        

        public MyDataList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            head = new Node(rand.Next(10000));
            current = head;

            for (int i = 1; i < length; i++)
            {
                prev = current;
                current.Next = new Node(rand.Next(10000));
                current = current.Next;
            }
            current.Next = null;
        }

        public override int Get(int index)
        {
            Node node = head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Data;
        }

        public override void Set(int index, int data)
        {
            Node node = head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            node.Data = data;
        }

        public override int Min()
        {
            int min = head.Data;
            for (Node node = head.Next; node != null; node = node.Next)
            {
                if (node.Data < min)
                {
                    min = node.Data;
                }
            }
            return min;
        }

        public override int Max()
        {
            int max = head.Data;
            for (Node node = head.Next; node != null; node = node.Next)
            {
                if (node.Data > max)
                {
                    max = node.Data;
                }
            }
            return max;
        }

        public override void Change(int data)
        {
            if (current == null)
                return;
            current.Data = data;
        }


        public override int Head()
        {
            current = head;
            prev = null;
            return current.Data;
        }

        public override int Current()
        {
            if (current == null)
                return 0;
            return current.Data;
        }

        public override int Next()
        {
            if (current.Next == null)
                return 0;
            else
            {
                prev = current;
                current = current.Next;
                return current.Data;   
            }

        }
    }
}
