using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluePrismTechnicalTest
{
    public class GraphRDOld : Graph<string,string>
    {

        private Dictionary<string, uint> Nodes = new Dictionary<string, uint>();
        private Dictionary<uint,string> NodesKeys = new Dictionary<uint, string>();
        public new void AddNode(string nodeValue)
        {
            if (Nodes.ContainsKey(nodeValue)) return;
            uint nodeKey = base.AddNode(nodeValue);
            Nodes.Add(nodeValue, nodeKey);
            NodesKeys.Add(nodeKey,nodeValue);
        }

        public void Connect(string node1, string node2)
        {
            uint nodeKey1 = Nodes[node1];
            uint nodeKey2 = Nodes[node2];

            base.Connect(nodeKey1, nodeKey2, 1, null);
            base.Connect(nodeKey2, nodeKey1, 1, null);
        }

        public List<string> GetPath(string node1, string node2)
        {

            uint nodeKey1 = Nodes[node1];
            uint nodeKey2 = Nodes[node2];

            ShortestPathResult result = this.Dijkstra(nodeKey1, nodeKey2); //result contains the shortest path
            
            var path = result.GetPath().ToList();

            if (path.Count > 0)
                return path.Select(x => NodesKeys[x]).ToList();

            return null;
        }
        
    }
}
