using Android.App;
using Android.OS;
using Storm.Mvvm;
using TodoLibrary;
using TodoLibrary.ViewModel;
namespace indiarose_Todo.Activities
{
    [Activity(Label = "EditDeleteActivity", Icon = "@drawable/icon")]
    public partial class EditDeleteActivity : ActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the home file in layout
            SetContentView(Resource.Layout.EditDelete);
            // Set our view model
            SetViewModel(new EditDeleteTodo());
        }
    }
}