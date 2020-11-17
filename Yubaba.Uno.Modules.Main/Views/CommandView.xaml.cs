using Windows.UI.Xaml.Controls;
using Yubaba.Uno.Modules.Main.ViewModels;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Yubaba.Uno.Modules.Main.Views
{
    public sealed partial class CommandView : UserControl
    {
        private CommandViewModel ViewModel => (CommandViewModel)DataContext;
        public CommandView()
        {
            this.InitializeComponent();
        }
    }
}
