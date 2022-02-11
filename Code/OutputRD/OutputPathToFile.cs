using System;
using System.Collections.Generic;
using System.IO;

namespace OutputRD
{
    public class OutputPathToFile : IOutputPath
    {

        private string OutputFile { get; set; }


        public OutputPathToFile(string file)
        {
            OutputFile = file;
        }

        public void PrintResult(IEnumerable<string> wordPath)
        {
            if (wordPath is null) return;

            File.WriteAllText(OutputFile, string.Join(Environment.NewLine, wordPath));
        }
    }
}
