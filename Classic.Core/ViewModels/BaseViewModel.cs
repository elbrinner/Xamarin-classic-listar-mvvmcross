using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
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
                     this.RaisePropertyChanged(() => this.IsBusy);
                
            }
        }


    }
}
