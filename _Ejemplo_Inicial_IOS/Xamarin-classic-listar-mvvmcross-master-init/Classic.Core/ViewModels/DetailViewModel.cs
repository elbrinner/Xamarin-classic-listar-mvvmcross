﻿using Classic.Dtos;
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
        }
    }
}
