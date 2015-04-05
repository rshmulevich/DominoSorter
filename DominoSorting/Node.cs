using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSorting
{
    public class Node
    {
        public int leftValue;
        public int rightValue;
        public List<Node> LeftVar;
        public List<Node> RightVar;

        public Node()
        {

            LeftVar = new List<Node>();
            RightVar = new List<Node>();

        }
    }
}
