using Bankia.IOS;
using Bankia.IOS.SpecificPlatform;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.Platform;
using UIKit;

namespace MvvmCrossIos
{
    public class Setup : MvxIosSetup
    {
        private MvxApplicationDelegate applicationDelegate;
        private UIWindow window;

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            this.applicationDelegate = applicationDelegate;
            this.window = window;
        }
        
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Classic.Core.App();
        }
        
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        /// <summary>
        /// Creates the presenter.
        /// </summary>
        /// <returns>The presenter.</returns>
        protected override IMvxIosViewPresenter CreatePresenter()
        {
            return new CustomPresenter(this.applicationDelegate, this.window);
        }

        /// <summary>
        /// Registra el ios view creator
        /// </summary>
        /// <param name="container">El container.</param>
        protected override void RegisterIosViewCreator(MvvmCross.iOS.Views.IMvxIosViewsContainer container)
        {
            var cont = new ViewContainer();
            base.RegisterIosViewCreator(cont);
        }


    }
}
