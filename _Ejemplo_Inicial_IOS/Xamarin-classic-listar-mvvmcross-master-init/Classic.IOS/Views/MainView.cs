using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Classic.Core.ViewModels;
using Classic.Dtos;

namespace MvvmCrossIos
{
    public partial class MainView : MvxViewController
    {
        

        public MainView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void Initialize()
        {
            this.View.LayoutIfNeeded();
        }


        private void SetDataSources()
        {
        }


        private void SetBindings()
        {

        }
    }
}