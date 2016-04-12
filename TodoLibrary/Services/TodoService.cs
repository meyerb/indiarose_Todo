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
using Android.Service;
using TodoLibrary.Model;

namespace TodoLibrary.Services
{
    [Service]
    public class TodoService : Service
    {
        static private ObservableCollection<Todo> _todos;

        static public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set { _todos=value; }
        }

        public static void StartTodos()
        {
        Todos = new ObservableCollection<Todo>
            {
                new Todo("aaffffffff", "bb"),
                new Todo("ccfffffff", "dd")
            };
        }

        public static void Initiate()
        {
            Todos.Add(new Todo("", ""));
            Todos.RemoveAt(Todos.Count - 1);
        }

        public static void Add(Todo nt)
        {
            Todos.Add(nt);
        }

        public static void Insert(int nti,Todo ntTodo)
        {
            Todos.Insert(nti,ntTodo);
        }

        public static void Remove(Todo nt)
        {
            Todos.Remove(nt);
        }

        public static void RemoveAt(int nt)
        {
            Todos.RemoveAt(nt);
        }

        public static int IndexOf(Todo nt)
        {
            return Todos.IndexOf(nt);
        }

        public override IBinder OnBind(Intent intent)
        {
            return new Binder();
        }
    }
}