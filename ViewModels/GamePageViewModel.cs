using CommunityToolkit.Mvvm.ComponentModel;
using DetailWinner.Data;
using DetailWinner.Interfaces;
using DetailWinner.Utils;

namespace DetailWinner.ViewModels;

public partial class GamePageViewModel : PageViewModel
{
    private IDetailImageService _detailImageService;
    [ObservableProperty]
    private object _imageSource;
    
    public GamePageViewModel(IDetailImageService detailImageService)
    {
        PageName = ApplicationPageNames.Game;
        
        _detailImageService = detailImageService;
        var detailImage = detailImageService.Images[0];
        
        var imageTransformer = new ImageTransformer(detailImage.ImageUri);
        var zoomedBitmap = imageTransformer.ZoomImage(detailImage.ZoomFactor, detailImage.CenterX, detailImage.CenterY);
        _imageSource = zoomedBitmap;
    }
}