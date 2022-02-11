using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeRD
{
    public class TreePathFinder : IWordsPathFinder
    {
        IEnumerable<string> Words { get; set; }
        Func<string, string, int> DistanceFunction { get; set; }

        public void Initialize(IEnumerable<string> words, Func<string, string, int> distance)
        {
            Words = words;
            DistanceFunction = distance;
        }

        public IEnumerable<string> GetPath(string wordStart, string wordEnd)
        {
            wordStart = wordStart.ToUpper();
            wordEnd = wordEnd.ToUpper();

            int totalDistance = DistanceFunction(wordStart, wordEnd);

            Dictionary<string, TreeItem> words = new Dictionary<string, TreeItem>();

            foreach (string word in Words)
            {
                if (words.ContainsKey(word)) continue;

                words.Add(word, new TreeItem(word, DistanceFunction(word, wordStart), DistanceFunction(word, wordEnd)));
            }

            TreeItem root = new TreeItem(wordStart, 0, 0);
            for (int i = 1; i < totalDistance; i++)
            {
                foreach (var w in words.Values.Where(x => x.DistanceRoot == i && x.DistanceFinal == totalDistance - i))
                {
                    InsertWordInTree(root, w);
                }
            }

            TreeItem finalLeaf = new TreeItem(wordEnd, totalDistance, 0);


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
                return solution;
            }

            return null;
        }

        private bool InsertWordInTree(TreeItem root, TreeItem leaf)
        {
            if (DistanceFunction(root.Word.ToUpper(), leaf.Word.ToUpper()) == 1)
            {
                leaf.Parent = root;
                root.Children.Add(leaf);
                return true;
            }


            foreach (TreeItem w in root.Children)
                if (InsertWordInTree(w, leaf)) return true;

            return false;
        }

    }
}
