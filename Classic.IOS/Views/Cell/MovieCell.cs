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

        static MovieCell()
        {
            Nib = UINib.FromName("MovieCell", NSBundle.MainBundle);
        }

        protected MovieCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            this.DelayBind(this.SetBindings);
        }

        /// <summary>
        /// Awakes from nib.
        /// </summary>
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.SelectionStyle = UITableViewCellSelectionStyle.None;
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
            
            set.Apply();
        }

    }
}
