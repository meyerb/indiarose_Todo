using System.Collections.ObjectModel;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Inject;
using Storm.Mvvm.Navigation;
using TodoLibrary.Model;
using TodoLibrary.Services;

namespace TodoLibrary.ViewModel
{
    public class CreerTodo : ViewModelBase
    {
        private string _choicetitle;
        private string _choicedescription;
        public ICommand ButtonCommand { get; private set; }

        public ITodoService TodoService => LazyResolver<ITodoService>.Service;
        public IHttpService HttpService => LazyResolver<IHttpService>.Service;

        public string ChoiceTitle
        {
            get { return _choicetitle; }
            set { SetProperty(ref _choicetitle, value); }
        }

        public string ChoiceDescription
        {
            get { return _choicedescription; }
            set { SetProperty(ref _choicedescription, value); }
        }

        public CreerTodo()
        {
            ChoiceTitle = "";
            ChoiceTitle = "";
            ButtonCommand = new DelegateCommand(ButtonClicked);
        }

        private void ButtonClicked()
        {
            if (!ChoiceTitle.Equals("") && !ChoiceDescription.Equals(""))
            {
                TodoService.Add(new Todo(ChoiceTitle, ChoiceDescription));
                HttpService.AddTodo(ChoiceTitle, ChoiceDescription);
                NavigationService.GoBack();
            }
        }
    }
}