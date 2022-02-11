using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrismTechnicalTest
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
