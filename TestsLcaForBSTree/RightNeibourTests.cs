using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSTree;
using NUnit.Framework;

namespace TestsLcaForBSTree
{
    public class TestSetNeighbour
    {
        public Node Node;
        public Node NodesNeighbour;
        public TestSetNeighbour(Node node, Node neighbour)
        {
            this.Node = node;
            this.NodesNeighbour = neighbour;
        }
    }


    [TestFixture]
    class RightNeibourTests
    {
        static Dictionary<string, TestSetNeighbour> testSetNeighbour = new Dictionary<string, TestSetNeighbour>();
        static KeyValuePair<Node,int> nodeToStart;
        [TestFixtureSetUp]
        public void Init()
        {
            /*
                        a             
                   /        \  
                  b          c          
                /   \          \ 
               d     e          f 
             */
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

            Node.SetNodesRightNeighbour(root1, 0);

            testSetNeighbour.Add("test1",new TestSetNeighbour(root1,null));
            testSetNeighbour.Add("test2",new TestSetNeighbour(cNode,null));
            testSetNeighbour.Add("test3",new TestSetNeighbour(bNode,cNode));
            testSetNeighbour.Add("test4",new TestSetNeighbour(eNode,fNode));
            testSetNeighbour.Add("test5",new TestSetNeighbour(dNode,eNode));

        }

        [Test]
        [TestCase("test1")]
        [TestCase("test2")]
        [TestCase("test3")]
        [TestCase("test4")]
        [TestCase("test5")]
        public void Test(string setName)
        {
            var node = testSetNeighbour[setName].Node;
            var expectedNeighbour = testSetNeighbour[setName].NodesNeighbour;

            var actualNeighbour = Node.GetNodeNeighbour(node);

            Assert.AreEqual(expectedNeighbour,actualNeighbour);


        }
    }
}
