using System;
using Windows.UI.Xaml;
using System.Reactive.PlatformServices;

namespace Yubaba.Uno.Wasm
{
    public class Program
    {
        private static App _app;

        static int Main(string[] args)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PlatformEnlightenmentProvider.Current.EnableWasm();
#pragma warning restore CS0618 // Type or member is obsolete           
            Windows.UI.Xaml.Application.Start(_ => _app = new App());

            return 0;
        }
    }
}
