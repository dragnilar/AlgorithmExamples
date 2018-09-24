using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees_Core_DotNetFull.BinaryTreeClasses
{
    public partial class BinarySearchTree<T>
    {
        public virtual IEnumerator<T> GetEnumerator(TraversalMethod traversalMethod)
        {
            switch (traversalMethod)
            {
                case TraversalMethod.PreOrder:
                    return Preorder.GetEnumerator();

                case TraversalMethod.Inorder:
                    return InOrder.GetEnumerator();

                case TraversalMethod.Postorder:
                    return PostOrder.GetEnumerator();
                default:
                    throw new InvalidEnumArgumentException(
                        "The specified Traversal method is not defined in the Traversal Method enumeration.\n Please specify a valid Traversal method.");
            }
        }

        public IEnumerable<T> Preorder
        {
            get
            {

                var nodeToVisit = new Stack<BinaryTreeNode<T>>(_nodeCount); //Per Scott Mitchel, we only need a single stacik here to maintain the correct order for processing the child nodes.
                var currentNode = _root;
                if (currentNode != null)
                {
                    nodeToVisit.Push(currentNode);
                }

                while (nodeToVisit.Count != 0)
                {
                    currentNode = nodeToVisit.Pop();
                    if (currentNode.RightNode != null)
                    {
                        nodeToVisit.Push(currentNode.RightNode);
                    }

                    if (currentNode.LeftNode != null)
                    {
                        nodeToVisit.Push(currentNode.LeftNode);
                    }

                    yield return currentNode.Value;
                }
            }
        }


        public IEnumerable<T> InOrder
        {
            get
            {
                // As with Scott Mitchell's example, this code was taken from here:
                // http://blogs.msdn.com/grantri/archive/2004/04/08/110165.aspx
                Stack<BinaryTreeNode<T>> nodeToVisitStack = new Stack<BinaryTreeNode<T>>(_nodeCount);
                for (BinaryTreeNode<T> currentNode = _root; GetInOrderStatus(currentNode, nodeToVisitStack); currentNode = currentNode.RightNode)
                {
                    while (currentNode != null)
                    {
                        nodeToVisitStack.Push(currentNode);
                        currentNode = currentNode.LeftNode;
                    }

                    currentNode = nodeToVisitStack.Pop();
                    yield return currentNode.Value;
                }
            }
        }

        private static bool GetInOrderStatus(BinaryTreeNode<T> current, Stack<BinaryTreeNode<T>> toVisit)
        {
            return current != null || toVisit.Count != 0;
        }


        public IEnumerable<T> PostOrder
        {
            get
            {
                var nodeToVisitStack = new Stack<BinaryTreeNode<T>>(_nodeCount);
                var nodeHasBeenProcessedStack = new Stack<bool>(_nodeCount);
                var currentNode = _root;
                if (currentNode != null)
                {
                    nodeToVisitStack.Push(currentNode);
                    nodeHasBeenProcessedStack.Push(false);
                    currentNode = currentNode.LeftNode;
                }

                while (nodeToVisitStack.Count != 0)
                {
                    if (currentNode != null)
                    {
                        //Add the current node to the collection and flag it as not processed. Then grab the left child of the current node we are processing.
                        nodeToVisitStack.Push(currentNode); 
                        nodeHasBeenProcessedStack.Push(false);
                        currentNode = currentNode.LeftNode;
                    }

                    else
                    {
                        var isThisNodeProcessed = nodeHasBeenProcessedStack.Pop();
                        var topNodeFromVisitStack = nodeToVisitStack.Pop();
                        if (!isThisNodeProcessed)
                        {
                            nodeToVisitStack.Push(topNodeFromVisitStack);
                            nodeHasBeenProcessedStack.Push(true);
                            currentNode = topNodeFromVisitStack.RightNode;
                        }
                        else
                        {
                            yield return topNodeFromVisitStack.Value;
                        }
                    }
                }
            }
        }
    }
}
