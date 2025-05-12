using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DetailWinner.Data;

namespace DetailWinner.ViewModels;

public partial class GamePageViewModel : PageViewModel
{
    public GamePageViewModel()
    {
        PageName = ApplicationPageNames.Game;
    }
}