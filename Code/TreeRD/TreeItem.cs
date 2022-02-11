using System;
using System.Collections.Generic;
using System.Text;

namespace TreeRD
{
    public class TreeItem
    {
        public TreeItem(string word, int distanceRoot, int distanceFinal)
        {
            Word = word;
            DistanceRoot = distanceRoot;
            DistanceFinal = distanceFinal;
        }

        public TreeItem Parent { get; set; }

        public string Word;

        public int DistanceRoot = 0;
        public int DistanceFinal = 0;

        public List<TreeItem> Children = new List<TreeItem>();

    }
}
