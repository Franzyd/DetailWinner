using CommunityToolkit.Mvvm.ComponentModel;
using DetailWinner.Data;

namespace DetailWinner.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPageNames _pageName;
}