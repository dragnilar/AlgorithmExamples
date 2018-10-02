using System;

using MonkeyApp_UWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MonkeyApp_UWP.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
