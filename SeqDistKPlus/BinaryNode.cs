using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqDistKPlus
{
    public class BinaryNode
    {
        public BinaryNode leftChild;
        public BinaryNode rightChild;
        public double combound;
        public string value;

        public int depth
        {
            get
            {
                if (value == null)
                    return Math.Max(leftChild.depth, rightChild.depth) + 1;
                else
                    return 1;
            }
        }

        public int childCount
        {
            get
            {
                if (value == null)
                    return leftChild.childCount + rightChild.childCount;
                else return 1;
            }
        }

        private static int j = 10;
        private int k = 10;

        public BinaryNode()
        {
            j += 1;
            k = j;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return k.ToString();
                return $"({leftChild},{rightChild})";
            }
            else
            {
                return value;
            }
        }
    }
}
