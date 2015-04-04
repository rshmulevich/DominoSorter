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
            //Node dummy = new Node();
            Top = new Node();
            //Top.LeftVar.Add(dummy);
            //Top.RightVar.Add(dummy);
            
            //foreach (JPiece piece in myheap.pieces)
            //{
            //    Node node = new Node();
                Top.leftValue = myheap.pieces[0].left;
                Top.rightValue = myheap.pieces[0].right;
                myheap.pieces[0].usedFlag = true;
                //Top.LeftVar.Add(node);
                Build(ref Top, ref myheap);
                myheap.pieces[0].usedFlag = false;
            //}
            //Build(ref Top, ref myheap);
            
            //Build();
        }

        private void Build(ref Node myNode, ref JInput myheap)
        {
            foreach(JPiece piece in myheap.pieces)
            {
                if (!piece.usedFlag)//&& ((!myNode.LeftVar.Any())||(!myNode.RightVar.Any())))
                {

                    if (myNode.leftValue == piece.right)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.left;
                        newNode.rightValue = piece.right;
                        myNode.LeftVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }
                    else if (myNode.leftValue == piece.left)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.right;
                        newNode.rightValue = piece.left;
                        myNode.LeftVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }
                    if (myNode.rightValue == piece.left)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.left;
                        newNode.rightValue = piece.right;
                        myNode.RightVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }
                    else if (myNode.rightValue == piece.right)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.right;
                        newNode.rightValue = piece.left;
                        myNode.RightVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }



                    if (myNode.leftValue == piece.right)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.left;
                        newNode.rightValue = piece.right;
                        myNode.LeftVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }
                    else if (myNode.leftValue == piece.left)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.right;
                        newNode.rightValue = piece.left;
                        myNode.LeftVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }
                    if (myNode.rightValue == piece.left)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.left;
                        newNode.rightValue = piece.right;
                        myNode.RightVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }
                    else if (myNode.rightValue == piece.right)
                    {
                        Node newNode = new Node();
                        newNode.leftValue = piece.right;
                        newNode.rightValue = piece.left;
                        myNode.RightVar.Add(newNode);
                        piece.usedFlag = true;
                        Build(ref newNode, ref myheap);
                        piece.usedFlag = false;
                    }


                }

            }
            
        }
        private void addRec(ref Node myNode, ref JPiece heap)
        {
            //foreach ()
            //if (heap)
        }
    }
}
