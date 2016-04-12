using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;

namespace TodoLibrary.Model
{
    public class Todo : NotifierBase
    {
        private string _title;
        private string _description;
        public ICommand ButtonCommand { get; private set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string Dexcription
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public Todo(string t, string d)
        {
            _title = t;
            _description = d;
            ButtonCommand = new DelegateCommand(ButtonEdit);
        }

        private void ButtonEdit()
        {
        }
    }
}