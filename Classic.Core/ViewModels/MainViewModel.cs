using Classic.Dtos;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Classic.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ResultResponseDto listData;
        private ResultDto selectedItem;

        public MainViewModel()
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
                if (value != null)
                {
                    selectedItem = value;
                    this.ShowViewModel<DetailViewModel>(value);
                }

                this.RaisePropertyChanged(() => this.SelectedItem);

            }
        }

        

        private IMvxCommand selectedItemCommand;

        /// <summary>
        /// commando a aplicar en la lista al seleccionar un elemento.
        /// </summary>
        public IMvxCommand SelectedItemCommand
        {
            get
            {
                selectedItemCommand = selectedItemCommand ?? new MvxCommand<ResultDto>(ItemClick);

                return selectedItemCommand;
            }

        }

        /// <summary>
        /// Navegación al otro ViewModel con el elemento de la lista seleccionado 
        /// </summary>
        /// <param name="item">Item seleccionado en la lista</param>
        private void ItemClick(ResultDto item)
        {
            //Navegamos y pasamos por parametro el item seleccionado
            this.ShowViewModel<DetailViewModel>(item);
        }

        public ResultResponseDto ListData
        {
            get
            {
                return this.listData;
            }

            set
            {
                this.listData = value;
                this.RaisePropertyChanged(() => this.ListData);
            }
        }

        /// <summary>
        /// Al cargar el ViewModel entra por aqui.
        /// </summary>
        public async void Init()
        {
            //Llamaremos un servicio, usamos IsBusy a true
            //para mostrar un indicador que algo se esta cargando en pantalla
            this.IsBusy = true;
            try
            {
                //url del servicio
                var url = new Uri(string.Format(CultureInfo.InvariantCulture, Classic.Contants.Config.baseUrl, Contants.Config.param1));
                var cliente = new HttpClient();
                //hacemos una petición get al servicio
                var result = await cliente.GetAsync(url);
                // Si la respuesta es correcta seguimos
                if (result.IsSuccessStatusCode)
                {
                    //Recuperamos el contenido
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        /*
                        Deserializamos los datos y asignamos a nuestra propiedad publica.
                        Observacion: Aqui lo ideal seria crea una entidad y 
                        un mapper para transformar los datos y tratar.
                        */
                        this.ListData = JsonConvert.DeserializeObject<ResultResponseDto>(content);
                    }

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                //Ponemos a false quitando el elemento de carga en la vista.
                this.IsBusy = false;
            }

        }
    }
}
