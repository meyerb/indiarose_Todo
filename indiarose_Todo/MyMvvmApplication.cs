using System;
using System.Collections.Generic;
using Android.App;
using Android.Runtime;
using Storm.Mvvm;
using Storm.Mvvm.Inject;
using TodoLibrary;

namespace indiarose_Todo
{
    [Application]
    public class MyMvvmApplication : ApplicationBase
    {
        public MyMvvmApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            Dictionary<string, Type> d = new Dictionary<string, Type>
            {
                {"HomeViewModel", typeof (HomeActivity)},
                {"CreerTodo", typeof (CreerActivity)}
            };
            base.OnCreate();
            AndroidContainer.CreateInstance<AndroidContainer>(this, d);
        }
    }
}