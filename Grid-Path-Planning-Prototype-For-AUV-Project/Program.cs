using System;
using System.Collections.Generic;

namespace Grid_Path_Planning_Prototype_For_AUV_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Network Setup
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            var node6 = new Node();
            var node7 = new Node();
            var node8 = new Node();
            var node9 = new Node();
            var node10 = new Node();
            var node11 = new Node();
            var node12 = new Node();
            var node13 = new Node();
            var node14 = new Node();
            var node15 = new Node();
            var node16 = new Node();

            node1.Connected = new List<Node> { node2, node5 };
            node2.Connected = new List<Node> { node1, node3, node6 };
            node3.Connected = new List<Node> { node2, node7, node4 };
            node4.Connected = new List<Node> { node3, node8};
            node5.Connected = new List<Node> { node1, node6, node9 };
            node6.Connected = new List<Node> { node2, node5, node7, node10 };
            node7.Connected = new List<Node> { node3, node6, node8, node11 };
            node8.Connected = new List<Node> { node4, node7, node12};
            node9.Connected = new List<Node> { node5, node10, node13 };
            node10.Connected = new List<Node> { node6, node9, node11, node14 };
            node11.Connected = new List<Node> { node7, node10, node12, node15 };
            node12.Connected = new List<Node> { node8, node11, node16 };
            node13.Connected = new List<Node> { node9, node14 };
            node14.Connected = new List<Node> { node10, node13, node15 };
            node15.Connected = new List<Node> { node11, node14, node16 };
            node16.Connected = new List<Node> { node12, node15 };

            Console.WriteLine("Hello World!");
        }
    }
    class Node
    {
        public List<Node> Connected { get; set; }
    }
}
