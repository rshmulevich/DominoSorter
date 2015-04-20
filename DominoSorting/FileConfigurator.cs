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
        // TODO: What is this? remaining of tree project? 
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

            if (confFileLines.Length < 1)
            {

                throw new ApplicationException("File is empty");
            }

            foreach (string line in confFileLines)
            {
                string key;
                string val;
                string[] lineParts;

                lineParts = line.Split('=');

                if (!line.Contains("="))
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

            Configuration confg = new Configuration(dictionary["Path"]);

            return confg;
        }

        
    }

   
}
