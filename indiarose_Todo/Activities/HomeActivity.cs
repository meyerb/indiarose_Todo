using Android.App;
using Android.Content;
using Android.OS;
using Storm.Mvvm;
using TodoLibrary;
using TodoLibrary.Services;
using TodoLibrary.ViewModel;

namespace indiarose_Todo.Activities
{
    [Activity(Label = "HomeActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class HomeActivity : ActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the home file in layout
            SetContentView(Resource.Layout.Home);
            // Set our view model
            SetViewModel(new HomeViewModel());
        }
    }
}