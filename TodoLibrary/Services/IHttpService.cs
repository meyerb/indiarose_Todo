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

namespace TodoLibrary.Services
{
    public interface IHttpService
    {
        bool Connection(string login,string pwd);
        bool Register(string login,string pwd);
        bool AddTodo(string title,string description);
        string GetTodos();
        bool EditTodo(string id,string title,string description);
        bool DeleteTodo(string id);
    }
}