using Classic.Dtos;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic.Core.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private ResultDto selectedItem;
        public string image;

        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.RaisePropertyChanged(() => this.Image);

            }
        }

        public ResultDto SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                 selectedItem = value;
                //Notificamos la lista que se ha realizado un cambio con RaisePropertyChanged
                this.RaisePropertyChanged(() => this.SelectedItem); 
            }
        }

        //Recuperamos el parametro enviado de la pantalla anterior y volvemos a asignar
        public void Init(ResultDto seleted)
        {
            this.SelectedItem = seleted;
            this.Image = seleted.backdrop_path == null ? Contants.Config.imgBig + seleted.poster_path : Contants.Config.imgBig + seleted.backdrop_path ;

        }
          private IMvxCommand backCommand;

        /// <summary>
        /// commando a aplicar en la lista al seleccionar un elemento.
        /// </summary>
        public IMvxCommand BackCommand
        {
            get
            {
                backCommand = backCommand ?? new MvxCommand(NavegacionBack);

                return backCommand;
            }

        }

        private void NavegacionBack()
        {
            this.ShowViewModel<MainViewModel>();
        }
    
    }
}
