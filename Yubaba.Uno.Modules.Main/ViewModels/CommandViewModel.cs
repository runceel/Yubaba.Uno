using Prism.Events;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Yubaba.Uno.Infrastructures.Events;
using Yubaba.Uno.Services;

namespace Yubaba.Uno.Modules.Main.ViewModels
{
    public class CommandViewModel : IDestructible
    {
        private CompositeDisposable Disposables { get; } = new CompositeDisposable();
        public AsyncReactiveCommand InitCommand { get; }
        private IYubaba Yubaba { get; }
        private IEventAggregator EventAggregator { get; }

        public CommandViewModel(IYubaba yubaba, IEventAggregator eventAggregator)
        {
            Yubaba = yubaba ?? throw new ArgumentNullException(nameof(yubaba));
            EventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            InitCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () =>
                {
                    await Yubaba.RequestIntroductionAsync();
                    EventAggregator.GetEvent<ResetEvent>().Publish();
                })
                .AddTo(Disposables);
        }

        public void Destroy() => Disposables.Dispose();
    }
}
