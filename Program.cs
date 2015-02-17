using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;

namespace BinarySearchTree
{

    public class Node
    {
        public Node(string name, Node parent)
        {
            this.Left = null;
            this.Right = null;
            this.Parent = parent;
            this.Name = name;
        }

        public Node Left { get; set; }
        public Node Right{ get; set; }
        public Node Parent{ get; set; }
        public string Name { get; set; }

        public Node GetRootNode()
        {
            var node = this;
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            return node;
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
            if (root == null)return null;
            if (!root.Any()) return null;
            else
            {
                var firstNodeRoot = firstNode.GetRootNode();
                var secondNodeRoot = secondNode.GetRootNode();
                if (firstNodeRoot.Name != secondNodeRoot.Name) return null;
                else
                {
                    return FindLowestCommonAncestorUsingNode(firstNodeRoot, firstNode, secondNode);            
                }

            }
        }
    }

    internal class Test
    {
        public static void LCATest(Node[] roots, Node fistNode, Node secondNode)
        {
            var LCA1 = Node.FindLowestCommonAncestorUsingNode(roots, fistNode, secondNode);
            var rootNames = "";
            foreach (var root in roots)
            {
                rootNames += root.Name + " ";
            }

            if (LCA1 != null)
            {
                Console.WriteLine("trees are: {0} :: first node:{1}, second node:{2} => result: {3}",
                    rootNames, fistNode.Name, secondNode.Name, LCA1.Name);
            }
            else
            {
                Console.WriteLine("There is no lower common ancestor for such combination:" + "trees are: {0} :: first node:{1}, second node:{2} \r\n", rootNames, fistNode.Name, secondNode.Name);
            }


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* ------------TREES----------
                        a                     |                h      
                   /        \                 |             /     \
                  b          c                |           i        k         
                /   \          \              |
               d     e          f             |
              /                /               |
            z                g                | 
             
            -----------------------------------*/

            //first tree
            Node root1 = new Node("A",null);
            Node bNode = new Node("B",root1);
            Node cNode = new Node("C",root1);
            Node dNode = new Node("D",bNode);
            Node eNode = new Node("E",bNode);
            Node fNode = new Node("F", cNode);
            Node zNode = new Node("Z", dNode);
            Node gNode = new Node("G", fNode);
            root1.Left = bNode;
            root1.Right = cNode;
            bNode.Left = dNode;
            bNode.Right = eNode;
            cNode.Left = fNode;
            dNode.Left = zNode;
            fNode.Left = gNode;

            //second tree
            Node root2 = new Node("H", null);
            Node iNode = new Node("I", root2);
            Node kNode = new Node("K", root2);
            root2.Left = iNode;
            root2.Right = kNode;

            //tests
           Test.LCATest(new Node[] {root1, root2}, bNode, cNode);
            
           Test.LCATest(new Node[] { root1, root2 }, root1, root2);
           Test.LCATest(new Node[] { root1, root2 }, fNode, gNode);
           Test.LCATest(new Node[] { root1, root2 }, zNode, eNode);
           Test.LCATest(new Node[] { root1, root2 }, eNode, dNode);
           Test.LCATest(new Node[] { root1, root2 }, dNode, iNode);
            Console.ReadLine();

        }
    }
}
