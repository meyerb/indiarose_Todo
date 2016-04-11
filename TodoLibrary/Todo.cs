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

namespace TodoLibrary
{
    public class Todo : NotifierBase
    {
        private string _title;
        private string _description;

        public string Title { get {return _title;} set { SetProperty(ref _title, value); } }
        public string Dexcription { get { return _description; } set { SetProperty(ref _description, value); } }

        public Todo(string t, string d)
        {
            _title = t;
            _description = d;
        }
    }
}