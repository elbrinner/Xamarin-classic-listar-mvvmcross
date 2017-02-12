using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using Bankia.IOS.Generic;
using Classic.IOS;
using MvvmCross.Binding.BindingContext;
using Classic.Core.ViewModels;
using Classic.Dtos;

namespace MvvmCrossIos
{
    public partial class MainView : MvxViewController
    {
        private SimpleDynamicTableViewSource dataSource;
        private ResultDto selectedItem;

        public MainView (IntPtr handle) : base (handle)
        {
        }

        public ResultDto SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                if(value != null)
                {
                    selectedItem = value;

                    //Ir al detalle
                    DetailView detailView = (DetailView)(UIStoryboard.FromName("DetailView",null).InstantiateViewController("DetailView"));
                    detailView.ViewModel = this.ViewModel;
                    this.NavigationController.PushViewController(detailView, true);
                }

            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.Initialize();
            this.SetDataSources();
            this.SetBindings();
            this.I18n();
        }

        private void Initialize()
        {
            this.View.LayoutIfNeeded();
        }


        private void SetDataSources()
        {
            // Establecemos el DataSource para
            // la tabla y enlazamos la tabla con
            // la cabecera para que gestione el
            // scroll.
            this.dataSource = new SimpleDynamicTableViewSource(
                this.tableView,
                typeof(MovieCell));
        }


        private void SetBindings()
        {
            var set = this.CreateBindingSet<MainView, MainViewModel> ();

            set.Bind(this)
                .For(v => v.SelectedItem)
                .To(vm => vm.SelectedItem);

            set.Bind(this.dataSource)
                .For(s => s.SelectionChangedCommand)
                .To(vm => vm.SelectedItemCommand);

            set.Bind(this.dataSource)
                .For(s => s.ItemsSource)
                .To(vm => vm.ListData.results);

            set.Apply();
        }


        /// <summary>
        /// Internacionaliza los textos de la pantalla.
        /// </summary>
        private void I18n()
        {
        }
    }
}