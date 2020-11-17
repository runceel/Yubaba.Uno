using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Yubaba.Uno.Infrastructures;
using Yubaba.Uno.Modules.Main.ViewModels;
using Yubaba.Uno.Modules.Main.Views;

namespace Yubaba.Uno.Modules.Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();

            regionManager.RequestNavigate(RegionNames.LogRegion, ViewNames.MessagesView);
            regionManager.RequestNavigate(RegionNames.ContractRegion, ViewNames.ContractView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MessagesView, MessagesViewModel>();
            containerRegistry.RegisterForNavigation<ContractView, ContractViewModel>();
        }
    }
}
