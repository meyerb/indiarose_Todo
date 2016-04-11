using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Navigation;
using Storm.Mvvm.Services;

namespace TodoLibrary
{
    public class Todo : NotifierBase
    {
        private string _title;
        private string _description;

        public string Title { get {return _title;} set { SetProperty(ref _title, value); } }
        public string Description { get { return _description; } set { SetProperty(ref _description, value); } }

        public Todo(string t, string d)
        {
            _title = t;
            _description = d;
        }
    }
}