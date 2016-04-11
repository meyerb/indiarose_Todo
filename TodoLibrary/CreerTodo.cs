using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Android.Media;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Navigation;
using TodoLibrary;

namespace TodoLibrary
{
    public class CreerTodo : ViewModelBase
    {
        [NavigationParameter]
        public ObservableCollection<Todo> Todos { get; set; }

        private string _choicetitle;
        private string _choicedescription;
        public ICommand ButtonCommand { get; private set; }

        public string ChoiceTitle
        {
            get { return _choicetitle; }
            set { _choicetitle = value; }
        }

        public string ChoiceDescription
        {
            get { return _choicedescription; }
            set { _choicedescription = value; }
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
                Todo t = new Todo(ChoiceTitle, ChoiceDescription);
                Todos.Add(t);
                NavigationService.GoBack();
            }
        }
    }
}