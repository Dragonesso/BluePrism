using Contracts;
using LoadDictionary;
using OutputRD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrismTechnicalTest
{
    public class Worker
    {
        readonly IWordsPathFinder _finder;
        public Worker(ILoadDictionary dictionaryLoader, IWordsPathFinder finder)
        {
            _finder = finder;
            finder.Initialize(dictionaryLoader.GetWords(new Filters() { WordLen = 4, OnlyLetters = true}), WordsDistance);
        }

        public void PrintPath(string startWord, string endWord, IOutputPath outputWriter)
        {
            outputWriter.PrintResult(_finder.GetPath(startWord, endWord));
        }

        public int WordsDistance(string word1, string word2)
        {
            int distance = 0;
            for (int c = 0; c < word1.Length; c++)
                if (word1[c] != word2[c]) distance++;

            return distance;
        }

    }
}
