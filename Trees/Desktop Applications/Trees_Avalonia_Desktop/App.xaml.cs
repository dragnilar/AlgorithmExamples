using Avalonia;
using Avalonia.Markup.Xaml;

namespace Trees_Avalonia_Desktop
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
