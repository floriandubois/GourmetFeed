using Instaply.GourmetFeed.Models.Core;
using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Instaply.GourmetFeed.Common.Converters
{
    public class ImageUrlBuilderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";

            return new BitmapImage(new Uri(string.Concat(ApplicationContext.ImagesRootUrl, "/", value.ToString())));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
