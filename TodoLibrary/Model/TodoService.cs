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
using TodoLibrary.Services;
using Android.Service;

namespace TodoLibrary.Model
{
    public class TodoService : ITodoService
    {
        ObservableCollection<Todo> _todos;

        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set { _todos = value; }
        }

        public void StartTodos()
        {
            Todos = new ObservableCollection<Todo>();
        }

        public void StartTodos(ObservableCollection<Todo> c)
        {
            Todos = c;
        }

        public void Initiate()
        {
            Todos.Add(new Todo("","",""));
            Todos.RemoveAt(Todos.Count-1);
        }

        public void Add(Todo nt)
        {
            Todos.Add(nt);
        }

        public void Insert(int nti, Todo ntTodo)
        {
            Todos.Insert(nti,ntTodo);
        }

        public void Remove(Todo nt)
        {
            Todos.Remove(nt);
        }

        public void RemoveAt(int nt)
        {
            Todos.RemoveAt(nt);
        }

        public int IndexOf(Todo nt)
        {
            return Todos.IndexOf(nt);
        }
    }
}