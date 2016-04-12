using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Navigation;
using Storm.Mvvm.Services;
using TodoLibrary.Model;

namespace TodoLibrary.ViewModel
{
    public class EditDeleteTodo : ViewModelBase
    {
        [NavigationParameter]
        public ObservableCollection<Todo> Todos { get; set; }

        [NavigationParameter]
        public Todo TestObject { get; set; }

        public ICommand ButtonEdit { get; private set; }
        public ICommand ButtonDelete { get; private set; }

        private string _title;
        private string _description;

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

        public EditDeleteTodo()
        {
            ButtonDelete = new DelegateCommand(DeleteClicked);
            ButtonEdit = new DelegateCommand(EditClicked);
        }

        public override void OnNavigatedTo(NavigationArgs e, string parametersKey)
        {
            base.OnNavigatedTo(e, parametersKey);
            Title = TestObject.Title;
            Description = TestObject.Description;
        }

        private void DeleteClicked()
        {
            Todos.Remove(TestObject as Todo);
            NavigationService.GoBack();
        }
        private void EditClicked()
        {
            int pos=Todos.IndexOf(TestObject);
            Todos.Insert(pos, new Todo(Title, Description));
            Todos.RemoveAt(pos+1);
            NavigationService.GoBack();
        }
    }
}