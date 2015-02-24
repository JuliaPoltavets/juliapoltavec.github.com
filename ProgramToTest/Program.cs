using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSTree;

namespace ProgramToTest
{
    class Program
    {
        static void Main(string[] args)
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


        }
    }
}
