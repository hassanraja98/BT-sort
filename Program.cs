using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
       //initializing node
        public class Node
        {
            public int key;
            public Node left;
            public Node right;
        }
        //Making Class 
        public static class GM
        {

            static int Main()
            {
                // Providing elements for array to be sorted
                int[] arr = { 3, 8, 4, 1, 6 };


                Tsort(arr, arr.Length);

                for (int k = 0; k < arr.Length; k++)
                {
                    Console.Write(arr[k]);
                    Console.Write(" ");
                }

                return 0;
            }

            // For NEw Node
            public static Node nN(int item)
            {
                Node tempr = new Node();
                tempr.key = item;
                tempr.left = tempr.right = null;
                return tempr;
            }


            public static void tostoreSorted(Node root, int[] arr, ref int i)
            {
                if (root != null)
                {
                    tostoreSorted(root.left, arr, ref i);
                    arr[i++] = root.key;
                    tostoreSorted(root.right, arr, ref i);
                }
            }

            //inserting arrays to be sorted
            public static Node inserting(Node node, int key)
            {
                // if there is no element add new node with the given element
                if (node == null)
                {
                    return nN(key);
                }

                // if the given element is less than root, shift it towards left
                if (key < node.key)
                {
                    node.left = inserting(node.left, key);
                }
                    // if the given element is greater than root , shift it towards right
                else if (key > node.key)
                {
                    node.right = inserting(node.right, key);
                }


                return node;
            }

            // converting binary tree to binary search tree.
            public static void Tsort(int[] arr, int n)
            {
                Node root = null;


                root = inserting(root, arr[0]);
                for (int i = 1; i < n; i++)
                {
                    inserting(root, arr[i]);
                }


                int j = 0;
                tostoreSorted(root, arr, ref j);
            }



        }
    }
}
