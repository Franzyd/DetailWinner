using DetailWinner.Data;
using DetailWinner.Interfaces;
using DetailWinner.Utils;

namespace DetailWinner.ViewModels;

public partial class HomePageViewModel : PageViewModel
{
    public required IDetailImageService DetailImageService { get; set; }
    
    public HomePageViewModel()
    {
        PageName = ApplicationPageNames.Home;
    }
}