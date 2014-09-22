using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Instaply.GourmetFeed.Common.Converters
{
    public class InvertBooleanConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool res = false;
            if (!bool.TryParse(value.ToString(),out res))
            {
                return false;
            }
            return !res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class BooleanToVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool res = false;
            if (!bool.TryParse(value.ToString(),out res))
            {
                return Visibility.Collapsed;
            }
            return res ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
