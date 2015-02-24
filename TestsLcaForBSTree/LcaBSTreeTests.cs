using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BSTree;

namespace BinaryTreeTestsLCA
{
    public class TestSetNodes
    {
        public Node FirstNode;
        public Node SecondNode;
        public Node ResultNode;
        public TestSetNodes(Node first, Node second, Node result)
        {
            this.FirstNode = first;
            this.SecondNode = second;
            this.ResultNode = result;
        }
    }

    [TestFixture]
    public class LcaTests
    {
        static Dictionary<string, TestSetNodes> testSetLca = new Dictionary<string, TestSetNodes>();
        static Node[] roots;

        [TestFixtureSetUp]
        public void Init()
        {
            //creating a predefined tree
            /* ------------TREES----------
                        a                     |                h      
                   /        \                 |             /     \
                  b          c                |           i        k         
                /   \          \              |
               d     e          f             |
              | 
             
            -----------------------------------*/

            //first tree
            Node root1 = new Node("A", null);
            Node bNode = new Node("B", root1);
            Node cNode = new Node("C", root1);
            Node dNode = new Node("D", bNode);
            Node eNode = new Node("E", bNode);
            Node fNode = new Node("F", cNode);
            root1.Left = bNode;
            root1.Right = cNode;
            bNode.Left = dNode;
            bNode.Right = eNode;
            cNode.Right = fNode;


            //second tree
            Node root2 = new Node("H", null);
            Node iNode = new Node("I", root2);
            Node kNode = new Node("K", root2);
            root2.Left = iNode;
            root2.Right = kNode;

            roots = new Node[] { root1, root2 };
            testSetLca.Add("test1",new TestSetNodes(root1,root2,null));
            testSetLca.Add("test2", new TestSetNodes(eNode, dNode, bNode));
            testSetLca.Add("test3", new TestSetNodes(dNode, iNode, null));

        }

        [Test]
        [TestCase("test1")]
        [TestCase("test2")]
        [TestCase("test3")]

        public void Test(string setName)
        {
            var currentSet = testSetLca[setName];
            var firstNode = currentSet.FirstNode;
            var secondNode = currentSet.SecondNode;
            var resultNode = currentSet.ResultNode;

            var LCA1 = Node.FindLowestCommonAncestorUsingNode(roots, firstNode, secondNode);

            Assert.AreEqual(resultNode, LCA1, "LCA was found incorrectly for node " + firstNode.Name + " and node " + secondNode.Name);

        }

    }
}
