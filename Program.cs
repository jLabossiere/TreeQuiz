using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node6 = new Node<int>(3);
            Node<int> node5 = new Node<int>(6);
            Node<int> node4 = new Node<int>(4);
            Node<int> node3 = new Node<int>(3, null, node6);            
            Node<int> node2 = new Node<int>(10, node4, node5);            
            Node<int> root = new Node<int>(26, node2, node3);

            Console.WriteLine(PrintByLevel(root));
            Console.ReadLine();
        }
        public class Node<T>
        {
            public T Data;
            public Node<T> LNode;
            public Node<T> RNode;

            public Node(T data)
            {
                this.Data = data;
            }

            public Node(T data, Node<T> left, Node<T> right)
            {
                this.Data = data;
                this.LNode = left;
                this.RNode = right;
            }
        }
        static int SumTree(Node<int> root)
        {
            if(root == null)
            {
                return 0;
            }

            return root.Data + SumTree(root.LNode) + SumTree(root.RNode) ;
        }

        static bool IsCalcualtionsTree(Node<int> node)
        {
            if (node == null) return true;
            int SumLeft = SumTree(node.LNode);
            int SumRight = SumTree(node.RNode);

            bool isCalc;

            if(SumLeft == 0 && SumRight == 0)
            {
                isCalc = true;
            } else
            {
                isCalc = ((SumLeft + SumRight) == node.Data);
            }

            return isCalc && IsCalcualtionsTree(node.LNode) && IsCalcualtionsTree(node.RNode);
        }

        static string PrintByLevel(Node<int> root)
        {
            Queue<Node<int>> nodes = new Queue<Node<int>>();
            string ReturnString = "";

            nodes.Enqueue(root);

            while(nodes.Count > 0)
            {
                var CurrentNode = nodes.Dequeue();
                ReturnString += CurrentNode.Data + " ";

                if (CurrentNode.LNode != null) nodes.Enqueue(CurrentNode.LNode);
                if (CurrentNode.RNode != null) nodes.Enqueue(CurrentNode.RNode);
            }

            return ReturnString;
        }
    }
}
