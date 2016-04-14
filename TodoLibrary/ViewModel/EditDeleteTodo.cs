using System.Windows.Input;
using Newtonsoft.Json;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Inject;
using Storm.Mvvm.Navigation;
using Storm.Mvvm.Services;
using TodoLibrary.Model;
using TodoLibrary.Services;

namespace TodoLibrary.ViewModel
{
    public class EditDeleteTodo : ViewModelBase
    {
        [NavigationParameter]
        public Todo TestObject { get; set; }

        public ICommand ButtonEdit { get; private set; }
        public ICommand ButtonDelete { get; private set; }

        public ITodoService TodoService => LazyResolver<ITodoService>.Service;
        public IHttpService HttpService => LazyResolver<IHttpService>.Service;

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
            TodoService.Remove(TestObject);
            HttpService.DeleteTodo(TestObject.Id);
            NavigationService.GoBack();
        }
        private void EditClicked()
        {
            int pos = TodoService.IndexOf(TestObject);
            string res=HttpService.EditTodo(TestObject.Id, Title, Description);
            Todo nt = JsonConvert.DeserializeObject<Todo>(res);
            TodoService.Insert(pos, nt);
            TodoService.RemoveAt(pos + 1);
            NavigationService.GoBack();
        }
    }
}