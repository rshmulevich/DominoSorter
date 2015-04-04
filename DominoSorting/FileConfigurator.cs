using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;


namespace DominoSorting
{

    public class FileConfigurator:IConfigurator
    {
        private const int POS_ROOT       = 0;
        private const int POS_TREE_SIZE  = 1;
        private const int POS_PATH       = 2;
        private const int POS_LEFT_INC   = 3;
        private const int POS_RIGHT_INC  = 4;

        private string _file;

        public FileConfigurator(string file)
        {
            _file = file;

        }

        public Configuration Read()
        {
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dir = System.IO.Path.GetDirectoryName(location);

            string[] confFileLines = File.ReadAllLines(Path.Combine(dir, _file));


            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (string line in confFileLines)
            {
                string key;
                string val;
                string[] lineParts;

                lineParts = line.Split('=');

                if (lineParts.Length < 2)
                {
                    continue;
                    //throw new ApplicationException("wrong input format");
                }

                key = lineParts[0].Trim();

                if (lineParts.Length > 1)
                {
                    val = lineParts[1].Trim();
                }
                else
                    val = "";
                dictionary.Add(key, val);

            }

            Configuration cfg = new Configuration(
                
                dictionary["Path"]);

            return cfg;
        }

        
    }

   
}
