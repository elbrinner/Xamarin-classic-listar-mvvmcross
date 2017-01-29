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
