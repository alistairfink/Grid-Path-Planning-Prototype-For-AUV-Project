using System;
using System.Collections.Generic;

namespace Grid_Path_Planning_Prototype_For_AUV_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Network Setup
            var nodes = new Dictionary<string, Node>
            {
                { "Node1", new Node("Node 1") },
                { "Node2", new Node("Node 2") },
                { "Node3", new Node("Node 3") },
                { "Node4", new Node("Node 4") },
                { "Node5", new Node("Node 5") },
                { "Node6", new Node("Node 6") },
                { "Node7", new Node("Node 7") },
                { "Node8", new Node("Node 8") },
                { "Node9", new Node("Node 9") },
                { "Node10", new Node("Node 10") },
                { "Node11", new Node("Node 11") },
                { "Node12", new Node("Node 12") },
                { "Node13", new Node("Node 13") },
                { "Node14", new Node("Node 14") },
                { "Node15", new Node("Node 15") },
                { "Node16", new Node("Node 16") },
            };

            nodes["Node1"].Connected = new List<Node> { nodes["Node2"], nodes["Node5"] };
            nodes["Node2"].Connected = new List<Node> { nodes["Node1"], nodes["Node3"], nodes["Node6"] };
            nodes["Node3"].Connected = new List<Node> { nodes["Node2"], nodes["Node7"], nodes["Node4"] };
            nodes["Node4"].Connected = new List<Node> { nodes["Node3"], nodes["Node8"] };
            nodes["Node5"].Connected = new List<Node> { nodes["Node1"], nodes["Node6"], nodes["Node9"] };
            nodes["Node6"].Connected = new List<Node> { nodes["Node2"], nodes["Node5"], nodes["Node7"], nodes["Node10"] };
            nodes["Node7"].Connected = new List<Node> { nodes["Node3"], nodes["Node6"], nodes["Node8"], nodes["Node11"] };
            nodes["Node8"].Connected = new List<Node> { nodes["Node4"], nodes["Node7"], nodes["Node12"] };
            nodes["Node9"].Connected = new List<Node> { nodes["Node5"], nodes["Node10"], nodes["Node13"] };
            nodes["Node10"].Connected = new List<Node> { nodes["Node6"], nodes["Node9"], nodes["Node11"], nodes["Node14"] };
            nodes["Node11"].Connected = new List<Node> { nodes["Node7"], nodes["Node10"], nodes["Node12"], nodes["Node15"] };
            nodes["Node12"].Connected = new List<Node> { nodes["Node8"], nodes["Node11"], nodes["Node16"] };
            nodes["Node13"].Connected = new List<Node> { nodes["Node9"], nodes["Node14"] };
            nodes["Node14"].Connected = new List<Node> { nodes["Node10"], nodes["Node13"], nodes["Node15"] };
            nodes["Node15"].Connected = new List<Node> { nodes["Node11"], nodes["Node14"], nodes["Node16"] };
            nodes["Node16"].Connected = new List<Node> { nodes["Node12"], nodes["Node15"] };

            var invalidNodes = new List<Node> { nodes["Node5"], nodes["Node12"], nodes["Node14"] };
            // var startingNode = args[0];
            var startNode = nodes["Node8"];//nodes[startingNode];
            var totalNodes = 16;
            var path = VisitAllNodes(startNode, invalidNodes, totalNodes);
            Console.WriteLine("Path: ");
            for (int i = path.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(path[i].Name);
            }
            Console.ReadKey();
        }

        private static IList<Node> VisitAllNodes(Node startNode, List<Node> invalid, int total)
        {
            var toVisit = total - invalid.Count;
            var path = new Stack<Node>();
            path.Push(startNode);
            MakePath(path, invalid, toVisit);
            return path.ToArray();
        }

        private static void MakePath(Stack<Node> nodesVisit, List<Node> invalid, int total)
        {
            var currNode = nodesVisit.Peek();
            var maybeNodes = new List<Node>();
            var validNodes = new List<Node>();
            var invalidCount = 0;
            foreach (var valid in currNode.Connected)
            {
                if (!nodesVisit.Contains(valid))
                {
                    if (!invalid.Contains(valid))
                    {
                        validNodes.Add(valid);
                    }
                    else if (invalid.Contains(valid))
                    {
                        maybeNodes.Add(valid);
                    }
                }
                else if (nodesVisit.Contains(valid) && invalid.Contains(valid))
                {
                    invalidCount++;
                }
            }

            if (validNodes.Count > 0)
            {
                foreach (var node in validNodes)
                {
                    nodesVisit.Push(node);
                    MakePath(nodesVisit, invalid, total);
                    if (nodesVisit.Count - invalidCount >= total)
                    {
                        return;
                    }
                    nodesVisit.Pop();
                }
            }
            else
            {
                foreach (var node in maybeNodes)
                {
                    nodesVisit.Push(node);
                    MakePath(nodesVisit, invalid, total);
                    if (nodesVisit.Count - invalidCount >= total)
                    {
                        return;
                    }
                    nodesVisit.Pop();
                }
            }
        }
    }

    class Node
    {
        public string Name { get; set; }
        public List<Node> Connected { get; set; }
        public Node(string name)
        {
            Name = name;
        }
    }
}
