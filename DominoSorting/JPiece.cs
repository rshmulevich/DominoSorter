using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSorting 
{
    public class JPiece
    {

        public int left { get; set; }// need to make read only
        public int right { get; set; }// need to make read only


        internal JPiece Reverse()
        {
            JPiece reversed = new JPiece();
            reversed.right = left; 
            reversed.left = right;
            return reversed;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}",left, right);
        }
    }

}
