using System.Collections.ObjectModel;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;
using TodoLibrary;

public class HomeViewModel : ViewModelBase
{
    private ObservableCollection<Todo> _todos;
    private int _index;

    public int Index
    {
        get { return _index; }
        set { SetProperty(ref _index, value); }
    }

    public ObservableCollection<Todo> Todos { get { return _todos;} set { _todos = value; } }

    // Since it will only be affected once, we do not need to raise the PropertyChanged event there
    public ICommand ButtonCommand { get; private set; }

    public HomeViewModel()
    {
        ButtonCommand = new DelegateCommand(ButtonClicked);
        Todos=new ObservableCollection<Todo>();
        Todo t1=new Todo("aa","bb");
        Todos.Add(t1);
        Todo t2 = new Todo("cc", "dd");
        Todos.Add(t2);
    }

    private void ButtonClicked()
    {
        Todos.Add(new Todo("ccc","sss"));
        //base.NavigationService.Navigate("HomeViewModel");
    }
}