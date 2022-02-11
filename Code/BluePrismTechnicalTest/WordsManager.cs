using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrismTechnicalTest
{
    public static class WordsManager
    {
        public static bool RunTree(string dictionaryFile, string startWord, string endWord, string outputFile)
        {

            startWord = startWord.ToUpper();
            endWord = endWord.ToUpper();

            List<string> lines = GetLinesFromDictionary(dictionaryFile);

            ValidateWords(startWord, endWord, lines);

            int totalDistance = WordsDistance(startWord, endWord);

            Dictionary<string, TreeItem> words = new Dictionary<string, TreeItem>();

            foreach (string word in lines)
            {
                if (words.ContainsKey(word)) continue;

                words.Add(word, new TreeItem(word, WordsDistance(word, startWord), WordsDistance(word, endWord)));
            }

            TreeItem root = new TreeItem(startWord, 0, 0);
            for (int i = 1; i < totalDistance; i++)
            {
                foreach (var w in words.Values.Where(x => x.DistanceRoot == i && x.DistanceFinal == totalDistance - i))
                {
                    InsertWordInTree(root, w);
                }
            }

            TreeItem finalLeaf = new TreeItem(endWord, totalDistance, 0);


            if (InsertWordInTree(root, finalLeaf))
            {
                List<string> solution = new List<string>();
                TreeItem aux = finalLeaf;
                while (aux != null)
                {
                    solution.Add(aux.Word);
                    aux = aux.Parent;
                }
                //output 
                solution.Reverse();
                WriteOutput(outputFile, solution);
                return true;
            }
            else
                throw new Exception($"There's not a path from {startWord} to {endWord}");
        }

        static void WriteOutput(string outputFile, List<string> solution)
        {
            File.WriteAllText(outputFile, string.Join(Environment.NewLine, solution));
        }

        static int WordsDistance(string word1, string word2)
        {
            int distance = 0;
            for (int c = 0; c < word1.Length; c++)
                if (word1[c] != word2[c]) distance++;

            return distance;
        }

        static bool InsertWordInTree(TreeItem root, TreeItem leaf)
        {
            if (leaf.DistanceRoot - 1 == root.DistanceRoot && WordsDistance(root.Word.ToUpper(), leaf.Word.ToUpper()) == 1)
            {
                leaf.Parent = root;
                root.Children.Add(leaf);
                return true;
            }

            foreach (TreeItem w in root.Children)
                if (InsertWordInTree(w, leaf)) return true;

            return false;
        }

        
        

        

        private static List<string> GetLinesFromDictionary(string dictionaryFile)
        {
            if (!File.Exists(dictionaryFile))
            {
                throw new FileNotFoundException($"Dictionary file not found at {dictionaryFile}");
            }

            List<string> values = System.IO.File.ReadAllLines(dictionaryFile).Where(w => w.Length == 4).Select(x => x.ToUpper()).ToList();

            if (values is null || values.Count() == 0)
                throw new FileLoadException("File is empty of 4 letter words");

            return values;

        }

        public static bool ValidateWords(string startWord, string endWord, List<string> dictionary = null)
        {
            if (startWord.Length != 4 || endWord.Length != 4)

                throw new Exception($"Start and end word must be 4 letters long");

            else if (startWord == endWord)

                throw new Exception($"Start and end word must be different");

            else if (dictionary != null)
            {
                if (!dictionary.Contains(startWord))
                    throw new Exception($"Start word not in the dictionary");
                else if (!dictionary.Contains(endWord))
                    throw new Exception($"End word not in the dictionary");
            }

            return true;
        }
    }
}
