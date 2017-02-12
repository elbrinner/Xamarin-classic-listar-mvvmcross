using System;
using Bankia.IOS.SpecificPlatform;
using Classic.Contants;
using Classic.Dtos;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Classic.IOS
{
    public partial class MovieCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString ("MovieCell");
        public static readonly UINib Nib;
        public string poster_path;

        static MovieCell()
        {
            Nib = UINib.FromName("MovieCell", NSBundle.MainBundle);
        }

        protected MovieCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        /// <summary>
        /// Awakes from nib.
        /// </summary>
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.SetBindings();
            this.SelectionStyle = UITableViewCellSelectionStyle.None;

            this.ContentView.BackgroundColor = UIColor.Clear;
            this.BackgroundColor = UIColor.Clear;
        }

        /// <summary>
        /// Sets the bindings.
        /// </summary>
        private void SetBindings()
        {
            var set = this.CreateBindingSet<MovieCell, ResultDto> ();

            set.Bind(this.titleLabel)
                .For(v => v.Text)
               .To(item => item.title);

            set.Bind(this.descLabel)
                .For(v => v.Text)
               .To(item => item.overview);

            set.Bind(this)
               .For(v => v.Poster_path)
                .To(item => item.poster_path);
            
            set.Apply();
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

    }
}
