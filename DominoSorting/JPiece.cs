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
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to JPiece return false.
            JPiece p = obj as JPiece;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return ((left == p.left) && (right == p.right)) || ((left == p.right) && (right == p.left));

        }
    }

}
