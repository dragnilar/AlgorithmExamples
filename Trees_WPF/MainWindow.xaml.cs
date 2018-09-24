using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Trees_WPF.Classes;

namespace Trees_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BinaryTreeDataForWPF> MainTree;
        private int NumberOfChildNodes = 25;

        public MainWindow()
        {
            InitializeComponent();
            HookUpEvents();
        }

        private void HookUpEvents()
        {
            ButtonCreateTree.Click += ButtonCreateTreeOnClick;
            ButtonExpandAll.Click += ButtonExpandAllOnClick;
        }

        /// <summary>
        /// Simple test method for expanding all nodes on the xaml tree.
        /// TODO - Replace with a method that traverses the nodes and sets "IsExpanded" to true without having to hard-code it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExpandAllOnClick(object sender, RoutedEventArgs e)
        {
            MainTree[0].IsExpanded = true;
            MainTree[0].SubItems[0].IsExpanded = true;
            MainTree[0].SubItems[1].IsExpanded = true;
            MainTree[0].SubItems[0].SubItems[0].IsExpanded = true;
            MainTree[0].SubItems[0].SubItems[1].IsExpanded = true;
            MainTree[0].SubItems[1].SubItems[0].IsExpanded = true;
            MainTree[0].SubItems[1].SubItems[1].IsExpanded = true;

        }

        private void ButtonCreateTreeOnClick(object sender, RoutedEventArgs e)
        {
            GenerateTree();

        }

        /// <summary>
        /// A simple test to generate tree data.
        /// TODO - Replace this with a method that is actually dynamic, hopefully one that will eventually utilize a real wrapper for the tree node classes...
        /// </summary>
        private void GenerateTree()
        {
            MainTree = new ObservableCollection<BinaryTreeDataForWPF>();
            var parentNode = new BinaryTreeDataForWPF()
            {
                NodeId = 1,
                ParentNodeId = 0
            };
            parentNode.SubItems.Add(new BinaryTreeDataForWPF(1, 2));
            parentNode.SubItems.Add(new BinaryTreeDataForWPF(1, 3));
            var childNode1 = new BinaryTreeDataForWPF(2, 4);
            var childNode2 = new BinaryTreeDataForWPF(2, 5);
            var childNode3 = new BinaryTreeDataForWPF(3, 6);
            var childNode4 = new BinaryTreeDataForWPF(3, 7);
            parentNode.SubItems[0].SubItems.Add(childNode1);
            parentNode.SubItems[0].SubItems.Add(childNode2);
            parentNode.SubItems[1].SubItems.Add(childNode3);
            parentNode.SubItems[1].SubItems.Add(childNode4);
            MainTree.Add(parentNode);
            TreeViewMain.ItemsSource = MainTree;



        }

    }
}
