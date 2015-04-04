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
        public bool usedFlag { get; set; }

        //public void Print(IEnumerable<JPiece> mypieces, string delimiter) // "->"
        //{
        //    foreach (JPiece pcs in mypieces)
        //    {
        //        Console.Write(string.Format("{0}:{1} --> "), pcs.left, pcs.right);
        //    }
        //}
    }

   

}
