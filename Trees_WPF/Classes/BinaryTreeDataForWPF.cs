using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trees_Core_DotNetFull.Annotations;
using Trees_Core_DotNetFull.BinaryTreeClasses;
using Trees_Core_DotNetFull.BinaryTreeClasses.TreeBase;

namespace Trees_WPF.Classes
{
    /// <summary>
    /// This is a very simple class that is being used for a binary search tree that can be used in this WPF application.
    /// TODO - Ideally this should be replaced with a wrapper/adapter of some type that will allow us to reuse the actual Binary Search Tree or Node class in Trees_Core
    /// </summary>
    public class BinaryTreeDataForWPF : INotifyPropertyChanged
    {
        private int _nodeId;
        private int _parentNodeId;
        private bool _isExpanded;

        public BinaryTreeDataForWPF()
        {
            SubItems = new ObservableCollection<BinaryTreeDataForWPF>();
        }

        public BinaryTreeDataForWPF(int parentNodeId, int nodeId) : this()
        {
            _parentNodeId = parentNodeId;
            _nodeId = nodeId;
        }

        public ObservableCollection<BinaryTreeDataForWPF> SubItems { get; set; }

        public int NodeId
        {
            get => _nodeId;
            set
            {
                _nodeId = value;
                OnPropertyChanged(nameof(NodeId));
            }
        }

        public int ParentNodeId
        {
            get => _parentNodeId;
            set
            {
                _parentNodeId = value;
                OnPropertyChanged(nameof(ParentNodeId));
            }
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (value == _isExpanded) return;
                _isExpanded = value;
                OnPropertyChanged(nameof(IsExpanded));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
