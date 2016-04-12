using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Navigation;
using TodoLibrary.Model;

namespace TodoLibrary.ViewModel
{
    public class EditDeleteTodo : ViewModelBase
    {
        [NavigationParameter]
        public ObservableCollection<Todo> Todos { get; set; }

        [NavigationParameter]
        public Todo TodoActual { get; set; }

        public ICommand ButtonEdit { get; private set; }
        public ICommand ButtonDelete { get; private set; }

        public EditDeleteTodo(Todo t)
        {
            TodoActual = t;
            ButtonDelete = new DelegateCommand(DeleteClicked);
            ButtonEdit = new DelegateCommand(EditClicked);
        }

        private void DeleteClicked()
        {
            Todos.Remove(TodoActual);
            NavigationService.GoBack();
        }
        private void EditClicked()
        {
            NavigationService.Navigate("EditTodo", new Dictionary<string, object>() { { "TodoActual", TodoActual }, { "Todos", Todos } });
        }
    }
}