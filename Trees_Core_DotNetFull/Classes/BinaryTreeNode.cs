using Trees_Core_DotNetFull.Classes.TreeBase;

namespace Trees_Core_DotNetFull.Classes
{
    /// <summary>
    ///     A binary tree node that provides the ability to store a specified data type as well as left/right child nodes.
    ///     This inherits from tree node, which in turn inherits from .NET's Collection class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T> : TreeNode<T>
    {
        public BinaryTreeNode()
        {
        }

        /// <summary>
        ///     Initializes a new binary tree node of the specified data type.
        /// </summary>
        /// <param name="data"></param>
        public BinaryTreeNode(T data) : base(data, null)
        {
        }

        /// <summary>
        ///     Initializes a new binary tree node of the specified data type and the specified left and right child nodes.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="leftTreeNode"></param>
        /// <param name="rightTreeNode"></param>
        public BinaryTreeNode(T data, BinaryTreeNode<T> leftTreeNode, BinaryTreeNode<T> rightTreeNode)
        {
            Value = data;
            var childrenNodes = new TreeNodeList<T>(2)
            {
                [0] = leftTreeNode,
                [1] = rightTreeNode
            };

            Neighbors = childrenNodes;
        }

        /// <summary>
        ///     The left child node
        /// </summary>
        public BinaryTreeNode<T> LeftNode
        {
            get => (BinaryTreeNode<T>) Neighbors?[0];

            set
            {
                if (Neighbors == null)
                {
                    Neighbors = new TreeNodeList<T>(2);
                }

                Neighbors[0] = value;
            }
        }

        /// <summary>
        ///     The right child node
        /// </summary>
        public BinaryTreeNode<T> RightNode
        {
            get => (BinaryTreeNode<T>)Neighbors?[1];

            set
            {
                if (Neighbors == null)
                {
                    Neighbors = new TreeNodeList<T>(2);
                }

                Neighbors[1] = value;
            }
        }
    }
}