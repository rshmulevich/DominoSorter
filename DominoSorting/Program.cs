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
            string _text;

            IConfigurator Cnfg = new FileConfigurator("conf.txt");
            var jsonFile = Cnfg.Read();

            try
            {
                _text = System.IO.File.ReadAllText(jsonFile.Path);
            }
            catch (Exception e)
            {
                Console.WriteLine( "Can't read file, error:" + e.Message);
                return;
            }

            var heap = JsonConvert.DeserializeObject<JInput>(_text);//reading the json data string

            # endregion Parse Json file


            Domino myDomino = new Domino(heap);

            myDomino.Print();
            Console.ReadLine();

        }
    }
}
