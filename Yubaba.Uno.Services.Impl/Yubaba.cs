using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Yubaba.Uno.Services.Impl
{
    public class Yubaba : IYubaba
    {
        private readonly ObservableCollection<Message> _messages = new ObservableCollection<Message>();
        public ReadOnlyObservableCollection<Message> Messages { get; }
        public Task SubmitContractAsync(ContractPaper contractPaper)
        {
            _messages.Clear();
            var signatureSign = new StringInfo(contractPaper.SignatureSign);
            var newName = signatureSign.SubstringByTextElements(new Random().Next(signatureSign.LengthInTextElements), 1);
            AddMessage("フン。");
            AddMessage($"{contractPaper.SignatureSign}というのかい。");
            AddMessage("贅沢な名だねぇ。");
            AddMessage($"今からお前の名前は{newName}だ。");
            AddMessage($"いいかい。{newName}だよ。");
            AddMessage($"分かったら返事をするんだ、{newName}!!");
            return Task.CompletedTask;
        }

        public Task RequestIntroductionAsync()
        {
            _messages.Clear();
            AddMessage("契約書だよ。");
            AddMessage("そこに名前を書きな。");
            return Task.CompletedTask;
        }

        public Yubaba()
        {
            Messages = new ReadOnlyObservableCollection<Message>(_messages);
        }

        private void AddMessage(string message) => _messages.Add(new Message(message));
    }
}
