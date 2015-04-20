using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSorting
{
    class Domino
    {
        private JInput _input;
        public Domino(JInput myheap)
        {
            _input = myheap;

           // List<string> dominoStrings = new List<string>();
            var resultCombinations = new List<List<JPiece>>(); // TODO: convert to List<Combination>
            string tempString;

            foreach (JPiece piece in _input.pieces)
            {
                //tempString = string.Format("{0}:{1}", piece.left, piece.right);
                //dominoStrings = dominoStrings.Concat(FindStrings(piece,  piece.right)).ToList();
                resultCombinations.AddRange( FindCombinations( new List<JPiece>(){ piece }, piece.right) );
                //tempString = string.Format("{0}:{1}", piece.right, piece.left);
                //dominoStrings = dominoStrings.Concat(FindStrings(piece,  piece.left)).ToList();
                resultCombinations.AddRange( FindCombinations( new List<JPiece>() { piece }, piece.left));
            }

            //remove duplicates
            var resultCombinationsDistinct = RemoveDuplicates(resultCombinations);

            foreach (List<JPiece> combination in resultCombinationsDistinct)
            {
                if (combination.Count > 2)
                     Console.WriteLine( GetCombinationString(combination) );
            }

            ////removing duplicated strings
            //dominoStrings = dominoStrings.Distinct().ToList();

            //Console.WriteLine("Number of combinations: " + dominoStrings.Count.ToString());
            ////Printing all the uniq strings
            //foreach (string str in dominoStrings)
            //{
            //    if (str.Length > 3)//printing only strings with 2 or more pieces
            //    {
            //        Console.WriteLine(str);
            //    }
            //}
            Console.ReadLine();
        }

        private string GetCombinationString(List<JPiece> combination)
        {
            // TODO: implement Combination.ToString()
            throw new NotImplementedException();
        }

        private List<List<JPiece>> RemoveDuplicates(List<List<JPiece>> inputList)
        {
            var resultList = new List<List<JPiece>>();
            // TODO: Implement. hint: one foreach only       

            throw new NotImplementedException();
        }

        private List<List<JPiece>> FindCombinations( List<JPiece> currentPieces, int value )
        {
            List<List<JPiece>> resultList = new List<List<JPiece>>();

            foreach (JPiece piece in _input.pieces)
            {
                //checking if the piece was already been used
                //int indx1 = currentPiece.IndexOf(string.Format("{0}:{1}", piece.left, piece.right));
                //int indx2 = currentPiece.IndexOf(string.Format("{1}:{0}", piece.left, piece.right));

                if(
                    currentPieces.Any(p=>piece.left == p.left && piece.right == p.right) &&
                    currentPieces.Any(p=>piece.right == p.left && piece.left == p.right))
                {
                    if (value == piece.left)
                    {
                        currentPieces.Add(piece);
                        //currentPieces = currentPieces + string.Format("{0}:{1}", piece.left, piece.right);
                        value = piece.right;
                        //newList = newList.Concat(FindStrings(currentPieces, value)).ToList();
                        resultList.AddRange(FindCombinations(currentPieces,value));
                    }
                    else if (value == piece.right)
                    {
                        currentPieces.Add(piece.Reverse());
                        //currentPieces = currentPieces + string.Format("{0}:{1}", piece.right, piece.left);
                        value = piece.left;
                        //newList = newList.Concat(FindStrings(currentPieces, myHeap, value)).ToList();
                        resultList.AddRange(FindCombinations(currentPieces, value));
                    }
                    resultList.Add(currentPieces);
                }

            }
            return resultList;

        }

    }
}
