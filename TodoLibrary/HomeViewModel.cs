using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Commands;

public class HomeViewModel : ViewModelBase
{
    private string _buttonText;
    private string _name;
    private string _greetings;

    private int _clickCounter = 0;

    public string ButtonText
    {
        get { return _buttonText; }
        set { SetProperty(ref _buttonText, value); }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (SetProperty(ref _name, value))
            {
                // if the input changed, we need to update the associated label
                Greetings = string.Format("Hello {0}!", value ?? "");
            }
        }
    }

    public string Greetings
    {
        get { return _greetings; }
        set { SetProperty(ref _greetings, value); }
    }

    // Since it will only be affected once, we do not need to raise the PropertyChanged event there
    public ICommand ButtonCommand { get; private set; }

    public HomeViewModel()
    {
        ButtonCommand = new DelegateCommand(ButtonClicked);
        Greetings = "Hello !";

        // initialize button text
        ButtonClicked();
    }

    private void ButtonClicked()
    {
        ButtonText = string.Format("You've clicked {0} times on this button", _clickCounter++);
    }
}