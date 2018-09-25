namespace Trees_Core_DotNetFull.BinaryTreeClasses.TreeBase
{
    /// <summary>
    /// A tree node that stores data and also houses a TreeNodeList that contains its children
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        private T _data;
        private TreeNodeList<T> _neighbors = null;

        public TreeNode()
        {

        }

        /// <summary>
        /// Creates a new tree node of the specified data/type and selected neighbors (if supplied)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="neighbors"></param>
        public TreeNode(T data, TreeNodeList<T> neighbors = null)
        {
            _data = data;
            _neighbors = neighbors;
        }

        /// <summary>
        /// Contains the data stored in the node of the type specified by YOU
        /// </summary>
        public T Value
        {
            get => _data;
            set => _data = value;
        }

        /// <summary>
        /// Represents the neighbors of THIS tree node
        /// </summary>
        protected TreeNodeList<T> Neighbors
        {
            get => _neighbors;
            set => _neighbors = value;
        }



    }
}
