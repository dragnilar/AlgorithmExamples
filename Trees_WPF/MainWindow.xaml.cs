using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trees_Core_DotNetFull.BinaryTreeClasses;

namespace Trees_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BinarySearchTree<int> MainTree { get; set; }
        private int TreeNodesCount = 26;
        public MainWindow()
        {
            InitializeComponent();
            HookUpEvents();
        }

        private void HookUpEvents()
        {
            ButtonClickMe.Click += ButtonClickMeOnClick;
        }

        private void ButtonClickMeOnClick(object sender, RoutedEventArgs e)
        {
            GenerateTree();
            TreeViewMain.ItemsSource = MainTree;

        }

        private void GenerateTree()
        {
            MainTree = new BinarySearchTree<int>();
            for (int i = 1; i <= TreeNodesCount; i++)
            {
                MainTree.AddNewNode(i);
            }
        }
    }
}
