using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSorting
{
    class Domino
    {

        public Domino(JInput myheap)
        {
            List<string> dominoStrings = new List<string>();
            string tempString;

            foreach (JPiece piece in myheap.pieces)
            {
                tempString = string.Format("{0}:{1}", piece.left, piece.right);
                dominoStrings = dominoStrings.Concat(FindStrings(tempString, myheap, piece.right)).ToList();
                tempString = string.Format("{0}:{1}", piece.right, piece.left);
                dominoStrings = dominoStrings.Concat(FindStrings(tempString, myheap, piece.left)).ToList();
            }

            //removing duplicated strings
            dominoStrings = dominoStrings.Distinct().ToList();

            Console.WriteLine("Number of combinations: " + dominoStrings.Count.ToString());
            //Printing all the uniq strings
            foreach (string str in dominoStrings)
            {
                if (str.Length > 3)//printing only strings with 2 or more pieces
                {
                    Console.WriteLine(str);
                }
            }
            Console.ReadLine();
        }


        private List<string> FindStrings(string tmpString, JInput myHeap, int value)
        {
            List<string> newList = new List<string>();
            foreach (JPiece piece in myHeap.pieces)
            {
                //checking if the piece was already been used
                int indx1 = tmpString.IndexOf(string.Format("{0}:{1}", piece.left, piece.right));
                int indx2 = tmpString.IndexOf(string.Format("{1}:{0}", piece.left, piece.right));

                if ((indx1 == -1) && (indx2 == -1))
                {
                    if (value == piece.left)
                    {
                        tmpString = tmpString + string.Format("{0}:{1}", piece.left, piece.right);
                        value = piece.right;
                        newList = newList.Concat(FindStrings(tmpString, myHeap, value)).ToList();
                    }
                    else if (value == piece.right)
                    {
                        tmpString = tmpString + string.Format("{0}:{1}", piece.right, piece.left);
                        value = piece.left;
                        newList = newList.Concat(FindStrings(tmpString, myHeap, value)).ToList();
                    }
                    newList.Add(tmpString);
                }

            }
            return newList;

        }

    }
}
