using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Trees_Avalonia_Desktop
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void ButtonCreateTree_Click(object s, RoutedEventArgs e)
        {
            DataContext = SetUpTree();
        }

        private AvaloniaList<TreeDataForAvalonia> SetUpTree()
        {
            var MainTree = new TreeDataForAvalonia();
            var parentNode = new TreeDataForAvalonia
            {
                Header = 1,
                ParentNodeId = 0
            };
            parentNode.Children.Add(new TreeDataForAvalonia(1, 2));
            parentNode.Children.Add(new TreeDataForAvalonia(1, 3));
            var childNode1 = new TreeDataForAvalonia(2, 4);
            var childNode2 = new TreeDataForAvalonia(2, 5);
            var childNode3 = new TreeDataForAvalonia(3, 6);
            var childNode4 = new TreeDataForAvalonia(3, 7);
            parentNode.Children[0].Children.Add(childNode1);
            parentNode.Children[0].Children.Add(childNode2);
            parentNode.Children[1].Children.Add(childNode3);
            parentNode.Children[1].Children.Add(childNode4);
            MainTree.Children.Add(parentNode);

            return MainTree.Children;
        }

        public class TreeDataForAvalonia
        {
            public TreeDataForAvalonia()
            {
                Children = new AvaloniaList<TreeDataForAvalonia>();
            }

            public TreeDataForAvalonia(int parentNodeId, int nodeId) : this()
            {
                Header = nodeId;
                ParentNodeId = parentNodeId;
            }

            public int Header { get; set; }
            public int ParentNodeId { get; set; }
            public AvaloniaList<TreeDataForAvalonia> Children { get; set; }
        }
    }
}
