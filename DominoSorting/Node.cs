using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSorting
{
    public class Node
    {
        public int leftValue{get; private set;}
        public int rightValue { get; private set; }
        public List<Node> Variants { get; private set; }

        public Node(int left, int right)
        {
            leftValue = left;
            rightValue = right;
            Variants = new List<Node>();
        }
    }
}
