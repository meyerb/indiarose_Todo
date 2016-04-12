using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using Storm.Mvvm.Navigation;
using Storm.Mvvm.Services;
using TodoLibrary.Model;
using TodoLibrary.Services;

namespace TodoLibrary.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private int _index;
        private Todo _testobject;

        public int Index
        {
            get { return _index; }
            set { SetProperty(ref _index, value); }
        }

        public Todo TestObject
        {
            get { return _testobject; }
            set { SetProperty(ref _testobject, value); }
        }

        [NavigationParameter]


        // Since it will only be affected once, we do not need to raise the PropertyChanged event there
        public ICommand ButtonCommand { get; private set; }
        public ICommand ButtonSelection { get; private set; }

        public HomeViewModel()
        {
            ButtonCommand = new DelegateCommand(ButtonClicked);
            ButtonSelection = new DelegateCommand(ButtonSelected);
            TodoService.StartTodos();
        }

        public override void OnNavigatedTo(NavigationArgs e, string parametersKey)
        {
            base.OnNavigatedTo(e, parametersKey);
            TodoService.Initiate();
        }

        private void ButtonClicked()
        {
            NavigationService.Navigate("CreerTodo");
        }

        private void ButtonSelected()
        {
            if(TestObject!=null)
                NavigationService.Navigate("EditDeleteTodo", new Dictionary<string, object>
                {
                    { "TestObject", TestObject }
                } );
        }
    }
}