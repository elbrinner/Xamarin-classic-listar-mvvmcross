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
                }

                this.RaisePropertyChanged(() => this.SelectedItem);

            }
        }

        

        private IMvxCommand selectedItemCommand;
        public IMvxCommand SelectedItemCommand
        {
            get
            {
                selectedItemCommand = selectedItemCommand ?? new MvxCommand<ResultDto>(ItemClick);

                return selectedItemCommand;
            }

        }

        private void ItemClick(ResultDto item)
        {
            this.SelectedItem = item;  
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

        public async void Init()
        {
            this.IsBusy = true;
            try
            {
                var url = new Uri(string.Format(CultureInfo.InvariantCulture, Classic.Contants.Config.baseUrl, Contants.Config.param1));
                var cliente = new HttpClient();
                var result = await cliente.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
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
                this.IsBusy = false;
            }

        }
    }
}
