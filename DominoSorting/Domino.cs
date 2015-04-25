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
        private List<Combination> _result;

        public Domino(JInput myDices)
        {
            
            _input = myDices;
            var resultCombinations = new List<Combination>();

            foreach (JPiece piece in _input.pieces)
            {
                Combination combination = new Combination();
                combination.Add(piece);
                resultCombinations.AddRange(FindCombinations(combination));
                combination = new Combination();
                combination.Add(piece.Reverse());
                resultCombinations.AddRange(FindCombinations(combination));
            }

            //remove duplicates
            _result = RemoveDuplicates(resultCombinations);
            //remove singles
            _result = RemoveSingles(_result);
        }
        
        public void Print()
        {
            Console.WriteLine("Total = " + _result.Count().ToString());
            foreach (Combination combination in _result)
            {
                Console.WriteLine(combination.ToString());
            }
        }

        private List<Combination> RemoveDuplicates(List<Combination> inputList)
        {
            var resultList = new List<Combination>();

            resultList.AddRange(inputList.Distinct().ToList());
            
            return resultList;
            
        }
        private List<Combination> RemoveSingles(List<Combination> inputList)
        {
            List<Combination> resultList = new List<Combination>();

            foreach (Combination combination in inputList)

                if (combination.Count != 1)
                {
                    resultList.Add(combination);
                }
            return resultList;

        }

        private List<Combination> FindCombinations( Combination currentCombination)
        {
            List<Combination> resultList = new List<Combination>();
            resultList.Add(currentCombination);
            foreach (JPiece piece in _input.pieces)
            {
                if(!currentCombination.Any(p=>piece.Equals(p)))
                {

                    if (currentCombination.Last().right == piece.left)
                    {
                        currentCombination.Add(piece);
                        resultList.AddRange(FindCombinations(currentCombination));
                    }
                    if (currentCombination.Last().right == piece.right)
                    {
                        currentCombination.Add(piece.Reverse());
                        resultList.AddRange(FindCombinations(currentCombination));
                    }
                    //resultList.Add(currentCombination);
                }

            }
            return resultList;

        }

    }
}
