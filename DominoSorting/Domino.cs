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
                //Node node = new Node(piece.left, piece.right);
                tempString = string.Format("{0}:{1}",piece.left,piece.right);
                //piece.usedFlag = true;
                //dominoStrings.Add( tempString);
                dominoStrings = dominoStrings.Concat(FindStrings(tempString, myheap, piece.right)).ToList();
                tempString = string.Format("{0}:{1}", piece.right, piece.left);
                //dominoStrings.Add( tempString);
                dominoStrings = dominoStrings.Concat(FindStrings(tempString, myheap, piece.left)).ToList();
                //piece.usedFlag = false;

                

            }

            dominoStrings = dominoStrings.Distinct().ToList();
            foreach (string str in dominoStrings)
            {
                if (str.Length > 3)
                {
                    Console.WriteLine(str);
                }
            }

            Console.ReadLine();

        }


        private List<string> FindStrings(string newString, JInput myHeap, int value)
        {
            List<string> newList = new List<string>();
            foreach (JPiece piece in myHeap.pieces)
            {

                int indx1 = newString.IndexOf(string.Format("{0}:{1}", piece.left, piece.right));
                int indx2 = newString.IndexOf(string.Format("{1}:{0}", piece.left, piece.right));

                if ((indx1 == -1) && (indx2 == -1))
                {
                    if (value == piece.left)
                    {
                        newString = newString + string.Format("{0}:{1}", piece.left, piece.right);
                        //piece.usedFlag = true;
                        value = piece.right;
                        newList = newList.Concat(FindStrings(newString, myHeap, value)).ToList();
                    }
                    else if (value == piece.right)
                    {
                        newString = newString + string.Format("{0}:{1}", piece.right, piece.left);
                        //piece.usedFlag = true;
                        value = piece.left;
                        newList = newList.Concat(FindStrings(newString, myHeap, value)).ToList();
                    }
                    newList.Add(newString);
                }
                
            }
            //foreach (JPiece piece in myHeap.pieces)
            //    if (!(piece.right == value) && !(piece.left == value))
            //        piece.usedFlag = false;
            //    else
            //        piece.usedFlag = true;

            return newList;

        }

    }
}
