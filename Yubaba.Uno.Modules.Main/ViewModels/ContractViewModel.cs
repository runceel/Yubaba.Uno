﻿using Prism.Events;
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
    public class ContractViewModel : IDestructible
    {
        private CompositeDisposable Disposables { get; } = new CompositeDisposable();
        public AsyncReactiveCommand SubmitCommand { get; }
        public ReactivePropertySlim<string> SignatureSign { get; } = new ReactivePropertySlim<string>();
        private IYubaba Yubaba { get; }
        private IEventAggregator EventAggregator { get; }

        public ContractViewModel(IYubaba yubaba, IEventAggregator eventAggregator)
        {
            Yubaba = yubaba ?? throw new ArgumentNullException(nameof(yubaba));
            EventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            SubmitCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () => await Yubaba.SubmitContractAsync(new ContractPaper(SignatureSign.Value)))
                .AddTo(Disposables);

            EventAggregator.GetEvent<ResetEvent>()
                .Subscribe(() => SignatureSign.Value = "")
                .AddTo(Disposables);
        }

        public void Destroy() => Disposables.Dispose();
    }
}
