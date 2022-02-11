using Contracts;
using Dijkstra.NET.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphRD
{
    public class GraphPathFinder : IWordsPathFinder
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
            return Graph.GetPath(wordStart, wordEnd);
        }

        MyGraph _Graph;
        
        private MyGraph Graph
        {
            get
            {
                if (_Graph is null)
                    _Graph = new MyGraph(Words, DistanceFunction);
                    
                 return _Graph;
            }
        }
    }
}
