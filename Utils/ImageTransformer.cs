using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using SkiaSharp;

namespace DetailWinner.Utils;

public class ImageTransformer
{
    private SKBitmap? _skBitmap;
    private SKSurface? _skSurface;
    
    public Bitmap? ImageBitmap { get; private set; }

    public ImageTransformer(Uri uri) => LoadImage(uri);
    
    public void LoadImage(Uri uri)
    {
        _skBitmap?.Dispose();
        _skSurface?.Dispose();
        using var stream = AssetLoader.Open(uri);
        using var skStream = new SKManagedStream(stream);
        _skBitmap = SKBitmap.Decode(skStream) ?? throw new Exception("Failed to load image.");

        _skSurface = SKSurface.Create(new SKImageInfo(_skBitmap.Width, _skBitmap.Height));
    }
    public Bitmap ZoomImage(float zoomFactor, float centerX = -1, float centerY = -1)
    {
        if (_skBitmap == null || _skSurface == null) throw new Exception("Image is not initialized.");
        
        int width = _skBitmap.Width;
        int height = _skBitmap.Height;

        int scaledWidth = (int)(width * zoomFactor);
        int scaledHeight = (int)(height * zoomFactor);
        
        //Center on the edge if coords too big
        if (centerX > width) centerX = width;
        if (centerY > height) centerY = height;

        // Center on the middle if optional params not provided/negative
        if (centerX < 0) centerX = (scaledWidth / 2f) / zoomFactor;
        if (centerY < 0) centerY = (scaledHeight / 2f) / zoomFactor;
        
        // Calculate offset to center the zoom
        float offsetX = centerX * zoomFactor - (width / 2f);
        float offsetY = centerY * zoomFactor - (height / 2f);
        
        var canvas = _skSurface.Canvas;
        canvas.Clear(SKColors.Transparent);

        // Draw the image scaled, but offset so it fills only the center part
        var destRect = new SKRect(-offsetX, -offsetY, scaledWidth - offsetX, scaledHeight - offsetY);
        canvas.DrawBitmap(_skBitmap, destRect);

        using var snapshot = _skSurface.Snapshot();
        using var data = snapshot.Encode(SKEncodedImageFormat.Png, 100);
        using var ms = new MemoryStream();
        data.SaveTo(ms);
        ms.Seek(0, SeekOrigin.Begin);

        ImageBitmap = new Bitmap(ms); // Avalonia bitmap
        return ImageBitmap;
    }
}