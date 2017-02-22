using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Classic.Droid.Views
{
    [Activity(Label = "Detalle")]
    public class DetailView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailView);
        }
    }
}
