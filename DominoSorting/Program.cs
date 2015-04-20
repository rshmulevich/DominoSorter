using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace DominoSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            # region Parse Json file
            string _text; //TODO: do not prefix local variables with _ or make them capital like Config. all lower case starting camel, e.g. "myConfig"
            IConfigurator Cnfg;

            Cnfg = new FileConfigurator("conf.txt");
            // TODO: incorrectly named variable type is Configuration ?
            var jsonFile = Cnfg.Read();

            try
            {
                _text = System.IO.File.ReadAllText(jsonFile.Path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't read file, error:" + e.Message);
                return;
            }
            // TODO: I would name this variable "pieces" for clarity. Heap is the term that is not applicable in this context
            var heap = JsonConvert.DeserializeObject<JInput>(_text);//reading the json data string

            # endregion Parse Json file

            //Printing the Dominos
            Domino myDomino = new Domino(heap);
            // TODO: What code below suppose to do?
            JPiece pi = new JPiece();
            pi.left = 0;

        }
    }
}
