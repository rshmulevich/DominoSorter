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

        public Domino(ref JInput myheap)
        {
           
            Top = new Node();
            //initializing top pieces
            foreach (JPiece piece in myheap.pieces)
            {
                Node node = new Node();
                node.leftValue = piece.left;
                node.rightValue = piece.right;
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
    }
}
