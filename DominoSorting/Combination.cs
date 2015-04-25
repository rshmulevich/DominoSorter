using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSorting
{
    class Combination:List<JPiece>
    {

        public override string ToString()
        {
            string combinationString = "";
            foreach(JPiece piece in this)
            {
                combinationString = string.Format(combinationString + "{0}:{1}", piece.left, piece.right);
            }
            return combinationString;
        }
        
    }
}
