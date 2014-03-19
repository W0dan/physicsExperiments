using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhysicsExperiments.Resources
{
    public static class ResourceProvider
    {
        public static ImageDrawing GetImage(ImageName imageName, Rect position)
        {
            return new ImageDrawing(GetImage(imageName), position);
        }

        public static ImageSource GetImage(ImageName imageName)
        {
            var oUri = new Uri("pack://application:,,,/PhysicsExperiments;component/" + imageName, UriKind.RelativeOrAbsolute);
            return BitmapFrame.Create(oUri);
        }
    }
}