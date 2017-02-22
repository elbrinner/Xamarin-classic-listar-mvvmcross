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
        private bool isBusy;

        /// <summary>
        /// Indicado de inicio y fin de las llamadas al servicio.
        /// Ponemos a true antes de llamar un servicio y a false despúes de la llamada
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.isBusy = value;
                if(this.isBusy)
                {
                    this.activityIndicator.Hidden = false;
                }
                else
                { 
                    this.activityIndicator.Hidden = true;
                }
            }
        }

        public MainView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.Initialize();
            this.SetDataSources();
            this.SetBindings();
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

            set.Bind(this.dataSource)
                .For(s => s.SelectionChangedCommand)
                .To(vm => vm.SelectedItemCommand);

            set.Bind(this.dataSource)
                .For(s => s.ItemsSource)
                .To(vm => vm.ListData.results);

            set.Bind(this)
                .For(s => s.IsBusy)
               .To(vm => vm.IsBusy);
            
            set.Apply();
        }
    }
}