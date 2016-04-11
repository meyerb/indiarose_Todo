using System;
using Android.App;
using Android.Runtime;
using Storm.Mvvm;
using Storm.Mvvm.Inject;

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
            base.OnCreate();
            AndroidContainer.CreateInstance<AndroidContainer>(this, null);
        }
    }
}