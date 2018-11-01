using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Trees_Avalonia_Desktop
{
    public class MainWindow : Window
    {
        public AvaloniaList<TreeDataForAvalonia> TreeData { get; set; }
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("ButtonOpenFolder").Click += delegate
            {
                new OpenFileDialog()
                {
                    Title = "Select A Folder"
                }.ShowAsync((Window) VisualRoot);
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void ButtonCreateTree_Click(object s, RoutedEventArgs e)
        {
            TreeData = SetUpTree();
            DataContext = TreeData;

        }

        public void ButtonOpenFile_Click(object s, RoutedEventArgs e)
        {
            ShowOpenFileDialog();

        }

        public void ButtonExpandTree_Click(object s, RoutedEventArgs e)
        {
            //TODO - Add ability to expand all nodes...
        }

        private async Task ShowOpenFileDialog()
        {
            var dialog = new OpenFileDialog();

            var result = await dialog.ShowAsync().ConfigureAwait(true);

            if (result.Any())
            {
                Console.WriteLine(result[0]);
            }
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
            public bool IsExpanded { get; set; }
        }
    }
}
