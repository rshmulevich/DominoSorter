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
            string jsonString; 
            IConfigurator configuration;

            configuration = new FileConfigurator("conf.txt");

            var sourceFile = configuration.Read();

            try
            {
                jsonString = System.IO.File.ReadAllText(sourceFile.Path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't read file, error:" + e.Message);
                return;
            }
            var collectionOfDices = JsonConvert.DeserializeObject<JInput>(jsonString);//reading the json data string

            # endregion Parse Json file

            //Printing the Dominos
            Domino myDomino = new Domino(collectionOfDices);
            myDomino.Print();
            Console.ReadLine();
        }
    }
}
