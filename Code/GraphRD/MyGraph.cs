using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphRD
{
    internal class MyGraph : Graph<string, string>
    {

        private Dictionary<string, uint> Nodes = new Dictionary<string, uint>();
        private Dictionary<uint, string> NodesKeys = new Dictionary<uint, string>();

        internal MyGraph(IEnumerable<string> nodes, Func<string, string, int> distanceFunction)
        {
            foreach (string node in nodes)
                AddNode(node);


            int iNode = 0;
            string[] nodesArray = nodes.ToArray();
            while (iNode < nodesArray.Length)
            {
                string word1 = nodesArray[iNode];
                for (int aux = iNode + 1; aux < nodesArray.Length; aux++)
                {
                    string word2 = nodesArray[aux];

                    if (distanceFunction(word1, word2) == 1)
                    {
                        Connect(word1, word2);
                    }
                }
                iNode++;
            }
        }

        private void Connect(string node1, string node2)
        {
            uint nodeKey1 = Nodes[node1];
            uint nodeKey2 = Nodes[node2];

            base.Connect(nodeKey1, nodeKey2, 1, null);
            base.Connect(nodeKey2, nodeKey1, 1, null);
        }

        private new void AddNode(string nodeValue)
        {
            if (Nodes.ContainsKey(nodeValue)) return;
            uint nodeKey = base.AddNode(nodeValue);
            Nodes.Add(nodeValue, nodeKey);
            NodesKeys.Add(nodeKey, nodeValue);
        }

        internal IEnumerable<string> GetPath(string node1, string node2)
        {

            uint nodeKey1 = Nodes[node1];
            uint nodeKey2 = Nodes[node2];

            ShortestPathResult result = this.Dijkstra(nodeKey1, nodeKey2); //result contains the shortest path

            var path = result.GetPath();

            if (path.Count() > 0)
                return path.Select(x => NodesKeys[x]);

            return null;
        }

    }
}

