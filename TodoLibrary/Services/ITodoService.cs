using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TodoLibrary.Model;

namespace TodoLibrary.Services
{
    public interface ITodoService
    {
        void StartTodos();

        void StartTodos(ObservableCollection<Todo> c);

        void Initiate();

        void Add(Todo nt);

        void Insert(int nti, Todo ntTodo);

        void Remove(Todo nt);

        void RemoveAt(int nt);

        int IndexOf(Todo nt);
    }
}