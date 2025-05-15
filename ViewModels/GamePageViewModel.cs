using System.Collections.Generic;
using DetailWinner.Data;
using DetailWinner.Interfaces;

namespace DetailWinner.ViewModels;

public partial class GamePageViewModel : PageViewModel
{
    private IDetailImageService detailImageService;
    
    public GamePageViewModel(IDetailImageService detailImageService)
    {
        PageName = ApplicationPageNames.Game;
        
        this.detailImageService = detailImageService;
    }
}