using System;
using System.Collections.Generic;
using Android.App;
using Android.Runtime;
using indiarose_Todo.Activities;
using Storm.Mvvm;
using Storm.Mvvm.Inject;
using TodoLibrary;
using TodoLibrary.Model;
using TodoLibrary.Services;

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
                {"CreerTodo", typeof (CreerActivity)},
                {"EditDeleteTodo" , typeof(EditDeleteActivity)},
                {"RegisterLoginViewModel" ,typeof(RegisterLoginActivity)}
            };
            base.OnCreate();
            AndroidContainer.CreateInstance<AndroidContainer>(this, d);
            AndroidContainer.GetInstance().RegisterInstance<ITodoService>(new TodoService());
            AndroidContainer.GetInstance().RegisterInstance<IHttpService>(new HttpService());
        }
    }
}