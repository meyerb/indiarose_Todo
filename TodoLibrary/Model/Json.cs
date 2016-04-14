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

namespace TodoLibrary.Model
{
    public class Json : NotifierBase
    {
        private bool _ok;
        private string _error;
        private string _resource;

        public bool Ok
        {
            get { return _ok; }
            set { SetProperty(ref _ok, value); }
        }
        public string Error
        {
            get { return _error; }
            set { SetProperty(ref _error, value); }
        }
        public string Resource
        {
            get { return _resource; }
            set { SetProperty(ref _resource, value); }
        }
    }
}