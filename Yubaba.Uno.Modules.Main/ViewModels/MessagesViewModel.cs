using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yubaba.Uno.Services;

namespace Yubaba.Uno.Modules.Main.ViewModels
{
    public class MessagesViewModel
    {
        public MessagesViewModel(IYubaba yubaba)
        {
            Yubaba = yubaba ?? throw new ArgumentNullException(nameof(yubaba));
        }

        public ReadOnlyObservableCollection<Message> Messages => Yubaba.Messages;

        private IYubaba Yubaba { get; }
    }
}
