namespace Trees_Core_DotNetFull.BinaryTreeClasses
{
    //TODO - Consider simplifying/refactoring the delete method since it is currently very long winded
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

        #region Add Node Method(s)
        /// <summary>
        /// Adds a new node to the binary tree using the specified value. If the value already exists, add does not do anything to the tree.
        /// </summary>
        /// <param name="data">The value you wish to add to the tree.</param>
        public virtual void AddNewNode(T data)
        {
            var searchResult = GetNodeToAddData(data, Root);
            if (searchResult.nodeExists)
            {
                return;
            }

            AddNodeToTree(data, searchResult.nodeToAdd);
        }

        private (BinaryTreeNode<T> nodeToAdd, bool nodeExists) GetNodeToAddData(T data, BinaryTreeNode<T> currentNode)
        {
            BinaryTreeNode<T> parentNode = null;
            while (currentNode != null)
            {
                var addResult = _comparer.Compare(currentNode.Value, data);
                if (addResult == 0)
                {
                    return (parentNode, true);
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

            return (parentNode, false);
        }

        private void AddNodeToTree(T data, BinaryTreeNode<T> nodeToAdd)
        {
            var newNode = new BinaryTreeNode<T>(data);
            _nodeCount++;
            if (nodeToAdd == null)
            {
                _root = newNode;
            }
            else
            {
                var addResult = _comparer.Compare(nodeToAdd.Value, data);
                if (addResult > 0)
                {
                    nodeToAdd.LeftNode = newNode;
                }
                else
                {
                    nodeToAdd.RightNode = newNode;
                }
            }
        }
        #endregion

        #region Delete Node Methods

        /// <summary>
        /// Deletes a node from the tree and rearranges it. Returns true if the node was deleted, returns false if the node is not present in the tree.
        /// </summary>
        /// <param name="data">Data to delete from the tree</param>
        /// <returns>True if data exists in tree and was deleted, false if data was not found and no delete occurred</returns>
        public bool DeleteNode(T data)
        {
            if (_root == null)
            {
                return false;
            }
            var searchResult = GetNodeForDeleteOperation(data, Root);

            if (searchResult.nodeIsNotInTree)
            {
                return false;
            }

            DeleteNodeAndReorganizeTree(searchResult.parentNode, searchResult.currentNode);

            return true;

        }

        private (BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode, bool nodeIsNotInTree) GetNodeForDeleteOperation(T data, BinaryTreeNode<T> currentNode)
        {
            BinaryTreeNode<T> parentNode = null;
            var deleteResult = _comparer.Compare(currentNode.Value, data);
            while (deleteResult != 0) //Loop until we break out of the loop or travel through the tree until we run out of nodes
            {

                if (deleteResult > 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.LeftNode;
                }
                else if (deleteResult < 0)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.RightNode;
                }

                if (currentNode == null) //We ran out of nodes, return false signifying that the data isn't in the tree
                {
                    return (parentNode, null, true);
                }

                deleteResult = _comparer.Compare(currentNode.Value, data);
            }

            return (parentNode, currentNode, false); //We broke out of the loop, the result is in the tree
        }

        private void DeleteNodeAndReorganizeTree(BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode)
        {
            _nodeCount--;

            if (currentNode.RightNode == null)
            {
                MoveCurrentLeftNodeToParentPositionForDelete(parentNode, currentNode);
            }
            else if (currentNode.RightNode.LeftNode == null)
            {
                MoveCurrentRightChildToParentPositionForDelete(parentNode, currentNode);
            }
            else
            {
                MoveCurrentRightChildsLeftMostDescendentToParentPositionForDelete(parentNode, currentNode);
                
            }

            //remove the current node after clearing the tree
            currentNode.LeftNode = currentNode.RightNode = null;
            currentNode = null;
        }

        private void MoveCurrentLeftNodeToParentPositionForDelete(BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode)
        {
            //current node has no right child, then currents left becomes the node pointed to by the parent
            if (parentNode == null)
            {
                Root = currentNode.LeftNode;
            }
            else
            {
                var comparisonResult = _comparer.Compare(parentNode.Value, currentNode.Value);
                if (comparisonResult > 0)
                {
                    parentNode.LeftNode = currentNode.LeftNode;
                }
                else if (comparisonResult < 0)
                {
                    parentNode.RightNode = currentNode.LeftNode;
                }
            }
        }

        private void MoveCurrentRightChildToParentPositionForDelete(BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode)
        {
            //Current's right has no left child, the currents right child replaces the current in the tree
            currentNode.RightNode.LeftNode = currentNode.LeftNode;

            if (parentNode == null)
                Root = currentNode.RightNode;
            else
            {
                var comparisonResult = _comparer.Compare(parentNode.Value, currentNode.Value);
                if (comparisonResult > 0)
                    // parent.Value > current.Value, so make current's right child a left child of parent
                    parentNode.LeftNode = currentNode.RightNode;
                else if (comparisonResult < 0)
                    // parent.Value < current.Value, so make current's right child a right child of parent
                    parentNode.RightNode = currentNode.RightNode;
            }
        }

        private void MoveCurrentRightChildsLeftMostDescendentToParentPositionForDelete(BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode)
        {
            //Currents right child has a left child, replace current with current's right child's left most descendent
            var leftMostCurrent = currentNode.RightNode.LeftNode;
            var leftMostParent = currentNode.RightNode;

            while (leftMostCurrent.LeftNode != null)
            {
                leftMostParent = leftMostCurrent;
                leftMostCurrent = leftMostCurrent.LeftNode;
            }

            leftMostParent.LeftNode = leftMostCurrent.RightNode;
            leftMostCurrent.LeftNode = currentNode.LeftNode;
            leftMostCurrent.RightNode = currentNode.RightNode;

            if (parentNode == null)
            {
                Root = leftMostCurrent;
            }
            else
            {
                AssignLeftMostCurrentToParentNode(parentNode, currentNode, leftMostCurrent);
            }
        }

        private void AssignLeftMostCurrentToParentNode(BinaryTreeNode<T> parentNode, BinaryTreeNode<T> currentNode,
            BinaryTreeNode<T> leftMostCurrent)
        {
            var comparisonResult = _comparer.Compare(parentNode.Value, currentNode.Value);
            if (comparisonResult > 0)
            {
                parentNode.LeftNode = leftMostCurrent;
            }
            else if (comparisonResult < 0)
            {
                parentNode.RightNode = leftMostCurrent;
            }
        }

        #endregion
    }
}
