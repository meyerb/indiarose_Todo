using Android.App;
using Android.OS;
using Storm.Mvvm;
using TodoLibrary;

namespace indiarose_Todo
{
    [Activity(Label = "CreerActivity", Icon = "@drawable/icon")]
    public partial class CreerActivity : ActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the home file in layout
            SetContentView(Resource.Layout.Home);
            // Set our view model
            SetViewModel(new CreerTodo());
        }
    }
}