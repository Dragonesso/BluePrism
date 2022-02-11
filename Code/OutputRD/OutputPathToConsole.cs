using System;
using System.Collections.Generic;
using System.Text;

namespace OutputRD
{
    public class OutputPathToConsole : IOutputPath
    {
        public void PrintResult(IEnumerable<string> wordPath)
        {
            if (wordPath is null)
                Console.WriteLine("No path found");
            else
                foreach (string w in wordPath)
                    Console.WriteLine(w);
        }
    }
}
