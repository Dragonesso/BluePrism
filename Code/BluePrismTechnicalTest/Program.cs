
using Contracts;
using GraphRD;
using LoadDictionary;
using OutputRD;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TreeRD;

namespace BluePrismTechnicalTest
{
    class Program
    {
        
        static void Main(string[] args)
        {


            if (args != null && args.Length == 2)
            {
                ILoadDictionary dictionaryReader = new LoadFromFile(args[1]);
                string dictionaryFile = args[1];

                switch (args[0].ToUpper())
                {
                    case "-TREE":
                        StartProcessing(dictionaryReader, new TreePathFinder());
                        break;
                    case "-GRAPH":
                        StartProcessing(dictionaryReader, new GraphPathFinder());
                        break;
                }
            }
            else
                Console.WriteLine("<usage>\n-[graph|tree] [dictionary file]");
        }

        static void StartProcessing( ILoadDictionary dictionaryReader, IWordsPathFinder pathFinder)
        {
            Worker worker = new Worker(dictionaryReader, pathFinder);
            while(true)
            {

                Console.WriteLine("word1;word2[;output file]");
                string[] args = Console.ReadLine().Split(';');

                args = args.Where(x => x.Trim().Length > 0).ToArray();

                if (args.Length == 2)
                    worker.PrintPath(args[0], args[1], new OutputPathToConsole());
                else if (args.Length > 2)
                    worker.PrintPath(args[0], args[1], new OutputPathToFile(args[2]));
                else
                    return;
            }
        }
    }
}
