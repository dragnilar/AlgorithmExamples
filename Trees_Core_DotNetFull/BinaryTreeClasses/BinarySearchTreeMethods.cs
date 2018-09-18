namespace Trees_Core_DotNetFull.BinaryTreeClasses
{
    public partial class BinarySearchTree<T>
    {
        /// <summary>
        /// Nullifies the root binary tree node in the tree.
        /// </summary>
        public virtual void Clear()
        {
            _root = null;
            _nodeCount = 0;
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
