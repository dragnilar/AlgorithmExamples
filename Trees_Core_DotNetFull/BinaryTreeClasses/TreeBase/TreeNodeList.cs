using System.Collections.ObjectModel;
using System.Linq;

namespace Trees_Core_DotNetFull.BinaryTreeClasses.TreeBase
{
    /// <summary>
    /// A collection of tree node lists; inherits from System.Collections.ObjectModel.Collection to provide basic collection functionality.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNodeList<T> : Collection<TreeNode<T>>
    {
        public TreeNodeList() : base()
        {

        }

        /// <summary>
        /// Initializes the tree node list with the specified number of nodes.
        /// </summary>
        /// <param name="initialSize"></param>
        public TreeNodeList(int initialSize)
        {
            for (var i = 0; i < initialSize; i++)
            {
                Items.Add(default(TreeNode<T>));
            }
        }

        /// <summary>
        /// Returns the specified node in the list that matches the requested value or null if nothing is found.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode<T> FindByValue(T value)
        {
            return Items.FirstOrDefault(node => node.Value.Equals(value));
        }
    }
}
