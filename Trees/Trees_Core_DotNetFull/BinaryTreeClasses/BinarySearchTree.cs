using System.Collections;
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
    public partial class BinarySearchTree<T> : IEnumerable<T>
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
        /// The root binary tree node
        /// </summary>
        public BinaryTreeNode<T> Root
        {
            get => _root;
            set => _root = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator(TraversalMethod.Inorder);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
