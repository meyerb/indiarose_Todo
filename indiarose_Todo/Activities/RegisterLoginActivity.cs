using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Storm.Mvvm;
using TodoLibrary.ViewModel;

namespace indiarose_Todo.Activities
{
    [Activity(Label = "RegisterLoginActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class RegisterLoginActivity : ActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the home file in layout
            SetContentView(Resource.Layout.RegisterLogin);
            // Set our view model
            SetViewModel(new RegisterLoginViewModel());
        }
    }
}