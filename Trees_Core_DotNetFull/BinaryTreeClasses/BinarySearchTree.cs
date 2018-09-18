using System.Collections.Generic;
using Trees_Core_DotNetFull.BinaryTreeClasses;

namespace Trees_Core_DotNetFull.BinaryTreeClasses
{
    /// <summary>
    /// Represents a binary tree that we can perform searches and other functionality against. Exposes methods that allows you to clear it.
    /// Default value for the root  Binary Tree Node is always null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>This is a slightly refactored version of Scott Mitchell's example of a Binary Search Tree taken from MSDN at the
    /// following address https://msdn.microsoft.com/en-us/library/ms379572(v=vs.80).aspx
    /// The original source code is difficult to come by, it is recommended that you check the wayback machine here:                  
    /// https://web.archive.org/web/20070104094452if_/http://download.microsoft.com:80/download/5/0/f/50f7b985-990b-4154-ac21-518bfe16f887/DataStructures20.msi
    /// </remarks>
    public partial class BinarySearchTree<T>
    {
        private BinaryTreeNode<T> _root;
        private IComparer<T> _comparer = Comparer<T>.Default;
        private int _nodeCount;


        /// <summary>
        /// Creates a new binary tree with a null binary tree root. This will use the default comparer of the type specified for the tree's data.
        /// </summary>
        public BinarySearchTree() { }

        /// <summary>
        /// Creates a new Binary Tree with a null binary tree root and the specified comparer.
        /// </summary>
        public BinarySearchTree(IComparer<T> comparer)
        {
            _comparer = comparer;

        }

        /// <summary>
        /// Nullifies the root binary tree node in the tree.
        /// </summary>
        public virtual void Clear()
        {
            _root = null;
            _nodeCount = 0;
        }

        /// <summary>
        /// The root binary tree node
        /// </summary>
        public BinaryTreeNode<T> Root
        {
            get => _root;
            set => _root = value;
        }

        /// <summary>
        /// Returns true if the supplied value is contained within the tree. Otherwise returns false.
        /// </summary>
        /// <param name="data">The value to search for within the tree.</param>
        /// <returns>True if data is in the tree; otherwise false.</returns>
        public bool ContainsData(T data)
        {
            var currentNode = _root;
            while (currentNode != null)
            {
                var result = _comparer.Compare(currentNode.Value, data);
                if (result == 0)
                {
                    return true;
                }

                if (result > 0)
                {
                    currentNode = currentNode.LeftNode;
                }
                else if (result < 0)
                {
                    currentNode = currentNode.RightNode;
                }
            }

            return false;


        }


        /// <summary>
        /// Adds a new node to the binary tree using the specified value. If the value already exists, add does not do anything to the tree.
        /// </summary>
        /// <param name="data">The value you wish to add to the tree.</param>
        public virtual void AddNewNode(T data)
        {
            var newNode = new BinaryTreeNode<T>(data);

            BinaryTreeNode<T> currentNode = Root;
            var parentNode = GetParentAndCurrentNodesForAdd(data, currentNode);

            _nodeCount++;
            if (parentNode == null)
            {
                _root = newNode;
            }
            else
            {
                var addResult = _comparer.Compare(parentNode.Value, data);
                if (addResult > 0)
                {
                    parentNode.LeftNode = newNode;
                }
                else
                {
                    parentNode.RightNode = newNode;
                }
            }

        }

        private BinaryTreeNode<T> GetParentAndCurrentNodesForAdd(T data, BinaryTreeNode<T> currentNode)
        {
            BinaryTreeNode<T> parentNode = null;
            while (currentNode != null)
            {
                var addResult = _comparer.Compare(currentNode.Value, data);
                if (addResult == 0)
                {
                    return parentNode;
                }

                if (addResult > 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.LeftNode;
                }

                else if (addResult < 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.RightNode;
                }
            }

            return parentNode;
        }
    }
}
