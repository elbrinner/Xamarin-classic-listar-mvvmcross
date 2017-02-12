using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using Classic.Core.ViewModels;
using Classic.Contants;
using Bankia.IOS.SpecificPlatform;

namespace Classic.IOS
{
    public partial class DetailView : MvxViewController
    {
        public string poster_path;
        public DetailView (IntPtr handle) : base (handle)
        {
        }

        public string Poster_path 
        { 
            get
            {
                return this.poster_path;
            }
            set
            {
                this.poster_path = value;
                this.DownloadImage(Config.imgBig + this.poster_path);
            }
        }

        private void DownloadImage(string url)
        {
            ImageDownloader imgDown = new ImageDownloader();

            imgDown.GetImageEvent += (object sender, EventArgs e) =>
            {
                if(sender != null)
                {
                    this.imageView.Image = UIImage.LoadFromData((NSData)sender);
                }
            };

            imgDown.DownloadImage(url);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.Initialize();
            this.SetBindings();
            this.I18n();
        }

        private void Initialize()
        {
            this.View.LayoutIfNeeded();
        }


        private void SetBindings()
        {
            var set = this.CreateBindingSet<DetailView, DetailViewModel> ();


            set.Bind(this)
               .For(v => v.Poster_path)
                .To(vm => vm.SelectedItem.poster_path);

            set.Bind(this.titleLabel)
                .For(s => s.Text)
               .To(vm => vm.SelectedItem.title);

            set.Bind(this.descLabel)
               .For(s => s.Text)
               .To(vm => vm.SelectedItem.overview);


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