using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSorting
{
    class Domino
    {
        private Node Top;

        public Domino(JInput myheap)
        {
            List<string> dominoStrings = new List<string>();
            string tempString;

            //Top = new Node(0,0);
            //initializing top pieces
            foreach (JPiece piece in myheap.pieces)
            {
                Node node = new Node(piece.left, piece.right);

                piece.usedFlag = true;
                Top.LeftVar.Add(node);
                Build(ref node, ref myheap);
                piece.usedFlag = false;
            }
        }

        private void Build(ref Node myNode, ref JInput myheap)
        {
            foreach(JPiece piece in myheap.pieces)
            {
                if (!piece.usedFlag)//check if the piece already in use
                {

                    if (myNode.leftValue == piece.right)
                    {
                        piece.usedFlag = true;
                        addPiece(ref myNode, piece.left, piece.right, true, ref myheap);
                        piece.usedFlag = false;
                    }
                    else if (myNode.leftValue == piece.left)
                    {
                        piece.usedFlag = true;
                        addPiece(ref myNode, piece.right, piece.left, true, ref myheap);
                        piece.usedFlag = false;
                    }
                    if (myNode.rightValue == piece.left)
                    {
                        piece.usedFlag = true;
                        addPiece(ref myNode, piece.left, piece.right, false, ref myheap);
                        piece.usedFlag = false;
                    }
                    else if (myNode.rightValue == piece.right)
                    {
                        piece.usedFlag = true;
                        addPiece(ref myNode, piece.right, piece.left, false, ref myheap);
                        piece.usedFlag = false;
                    }
                }

            }
            
        }

        //adding piece to the tree
        private void addPiece(ref Node myNode, int left, int right, bool LeftToRight, ref JInput myheap)
        {
            Node newNode = new Node();
            newNode.leftValue = left;
            newNode.rightValue = right;
            if (LeftToRight)
                myNode.LeftVar.Add(newNode);
            else
                myNode.RightVar.Add(newNode);

            Build(ref newNode, ref myheap);
            
        }

        public void Print()
        {
            recPrint(Top);
        }

        private void recPrint(Node node)
        {
            if (node != null)
            {
                foreach (Node myNode in node.LeftVar)
                {
                    recPrint(myNode);
                }
            }
            if ((node.leftValue != 0) || (node.rightValue != 0))
                Console.Write(string.Format(" {0}:{1}", node.leftValue, node.rightValue));
            if (node != null)
            {
                foreach (Node myNode in node.RightVar)
                {
                    recPrint(myNode);
                }
            }
            if ((node.leftValue != 0) || (node.rightValue != 0))
                    Console.Write(string.Format(" {1}:{0}", node.leftValue, node.rightValue));
            Console.WriteLine("");

        }
    }
}
