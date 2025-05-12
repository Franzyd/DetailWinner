using System;
using System.IO;
using Avalonia.Controls;
using DetailWinner.Utils;

namespace DetailWinner.Views;

public partial class GamePageView : UserControl
{
    public GamePageView()
    {
        InitializeComponent();

        var uri = new Uri("avares://DetailWinner/Assets/Images/Alice Margatroid.png");
        var imageTransformer = new ImageTransformer(uri);
        var zoomedBitmap = imageTransformer.ZoomImage(2);
        ImageView.Source = zoomedBitmap;
    }
}