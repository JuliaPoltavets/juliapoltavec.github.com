using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTree
{
    public class Node
    {
        public Node(string name, Node parent)
        {
            this.Left = null;
            this.Right = null;
            this.Parent = parent;
            this.Name = name;
            this.Neighbour = null;
        }

        public Node Left { get; set; }
        public Node Right{ get; set; }
        public Node Parent{ get; set; }
        public string Name { get; set; }
        public Node Neighbour { get; set; }

        private static List<Node> currentLevelNode = new List<Node>() ;
        
        public Node GetRootNode()
        {
            var node = this;
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            return node;
        }

        public static Node GetNodeNeighbour(Node node)
        {
            return node.Neighbour;
        }

        public List<Node> GetNodesChildren
        {
            get
            {
                var children = new List<Node>();
                if (this.Left != null) children.Add(this.Left);
                if (this.Right != null) children.Add(this.Right);
                return children;
            }
        }
        public static List<Node> GetAllChildren(Node node, List<Node> res)
        {
            var nodeChildren = node.GetNodesChildren; 
            foreach (var n in nodeChildren)
            {
                res.Add(n);
                GetAllChildren(n, res);

            }
            return res;
        }

        public static Node FindLowestCommonAncestorUsingNode(Node root, Node firstNode, Node secondNode)
        {
  
               if (root == null)
               return null;

                if (root == firstNode || root == secondNode)
                    return root;

                Node leftSideNode = FindLowestCommonAncestorUsingNode(root.Left, firstNode, secondNode);
                Node rightSideNode = FindLowestCommonAncestorUsingNode(root.Right, firstNode, secondNode);

                if (leftSideNode != null && rightSideNode != null)
                    return root;

                if (leftSideNode != null)
                    return leftSideNode;
                else
                    return rightSideNode;
         
        }

        public static Node FindLowestCommonAncestorUsingNode(Node[] root, Node firstNode, Node secondNode)
        {
            if (root == null) return null;
            if (!root.Any()) return null;
            else
            {
                var firstNodeRoot = firstNode.GetRootNode();
                var secondNodeRoot = secondNode.GetRootNode();
                if (firstNodeRoot!= secondNodeRoot) return null;
                else
                {
                    return FindLowestCommonAncestorUsingNode(firstNodeRoot, firstNode, secondNode);
                }

            }
        }

        public static void SetNodesRightNeighbour(Node node, int level)
        {
            if (node == null) return;
            while (level >= currentLevelNode.Count)
            {
                currentLevelNode.Add(null);
            }
            node.Neighbour = currentLevelNode[level];
            currentLevelNode[level] = node;

            SetNodesRightNeighbour(node.Right,level+1);
            SetNodesRightNeighbour(node.Left,level+1);
        }

    }
}
