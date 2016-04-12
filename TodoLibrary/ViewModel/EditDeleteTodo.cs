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
        public object TestObject { get; set; }

        public ICommand ButtonEdit { get; private set; }
        public ICommand ButtonDelete { get; private set; }

        private string _title;
        private string _description;
        private Todo _todoselect;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private Todo TodoSelect
        {
            get { return _todoselect; }
            set { SetProperty(ref _todoselect, value); }
        }

        public EditDeleteTodo()
        {
            ButtonDelete = new DelegateCommand(DeleteClicked);
            ButtonEdit = new DelegateCommand(EditClicked);
            TodoSelect = TestObject as Todo;
            if (TodoSelect != null)
            {
                Title = TodoSelect.Title;
                Description = TodoSelect.Description;
            }
            else
            {
                Title = "TitreRandom";
                Description = "DescriptionRandom";
            }
        }

        private void DeleteClicked()
        {
            Todos.Remove(TestObject as Todo);
            NavigationService.GoBack();
        }
        private void EditClicked()
        {
            //NavigationService.Navigate("EditTodo", new Dictionary<string, object>() { { "TestObject", TestObject }, { "Todos", Todos } });
        }
    }
}