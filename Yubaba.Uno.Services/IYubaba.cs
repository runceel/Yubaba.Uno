using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Yubaba.Uno.Services
{
    public interface IYubaba
    {
        ReadOnlyObservableCollection<Message> Messages { get; }
        Task SubmitContractAsync(ContractPaper contractPaper);
        Task RequestIntroductionAsync();
    }
}
