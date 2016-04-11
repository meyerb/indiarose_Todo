using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Navigation;
using TodoLibrary;

namespace TodoLibrary
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Todo> _todos;
        private int _index;

        public int Index
        {
            get { return _index; }
            set { SetProperty(ref _index, value); }
        }

        [NavigationParameter]
        public ObservableCollection<Todo> Todos
        {
            get { return _todos; }
            set { _todos = value; }
        }

        // Since it will only be affected once, we do not need to raise the PropertyChanged event there
        public ICommand ButtonCommand { get; private set; }

        public HomeViewModel()
        {
            ButtonCommand = new DelegateCommand(ButtonClicked);
            Todos = new ObservableCollection<Todo>();
            Todo t1 = new Todo("aaffffffff", "bb");
            Todos.Add(t1);
            Todo t2 = new Todo("ccfffffff", "dd");
            Todos.Add(t2);
        }

        private void ButtonClicked()
        {
            NavigationService.Navigate("CreerTodo", new Dictionary<string, object>() {{"Todos", Todos}});
        }
    }
}