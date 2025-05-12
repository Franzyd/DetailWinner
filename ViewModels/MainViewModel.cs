using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DetailWinner.Data;
using DetailWinner.Factories;

namespace DetailWinner.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly PageFactory _pageFactory;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(GamePageIsActive))]
    private PageViewModel _currentPage = null!;
    
    public bool HomePageIsActive => CurrentPage.PageName == ApplicationPageNames.Home;
    public bool GamePageIsActive => CurrentPage.PageName == ApplicationPageNames.Game;

    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;

        // GoToHome();
        GoToGame();
    }

    [RelayCommand]
    private void GoToHome() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Home);
    [RelayCommand]
    private void GoToGame() => CurrentPage = _pageFactory.GetPageViewModel(ApplicationPageNames.Game);
}