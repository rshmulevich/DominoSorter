using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;


namespace DominoSorting
{
    public class Configuration
    {
        

       
        public string Path  { get; private set; }
        
        public Configuration(string path)
        {
            
            Path = path;
        }

       

    }

    
}
