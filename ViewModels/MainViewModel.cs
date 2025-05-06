using CommunityToolkit.Mvvm.ComponentModel;

namespace DetailWinner.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;
    
    private readonly HomePageViewModel _homePage = new ();

    public MainViewModel()
    {
        CurrentPage = _homePage;
    }
}