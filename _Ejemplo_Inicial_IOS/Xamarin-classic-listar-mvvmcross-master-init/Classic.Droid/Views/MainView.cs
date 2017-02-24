using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Classic.Droid.Views
{
    [Activity(Label = "Listado de peliculas")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}
