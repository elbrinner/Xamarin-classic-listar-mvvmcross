using MvvmCross.WindowsUWP.Platform;
using MvvmCross.Core.ViewModels;
using Windows.UI.Xaml.Controls;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Visibility.WindowsCommon;
using MvvmCross.WindowsUWP.Views;
using MvvmCross.BindingEx.WindowsCommon;

namespace Classic.UWP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxPluginManager CreatePluginManager()
        {
             Mvx.RegisterType<IMvxNativeVisibility,  IMvxNativeVisibility>();
            return base.CreatePluginManager();
        }

    }

}
