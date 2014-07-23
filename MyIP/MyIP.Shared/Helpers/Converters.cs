using System;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MyIP.Helpers
{
    public class NetworkConnectivityToBackgroundBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is NetworkConnectivityLevel)
            {
                NetworkConnectivityLevel s = (NetworkConnectivityLevel)value;
                switch (s)
                {
                    case NetworkConnectivityLevel.InternetAccess:
                        return (SolidColorBrush)(App.Current.Resources["InternetConnectivityBrush"]);
                    case NetworkConnectivityLevel.ConstrainedInternetAccess:
                        return (SolidColorBrush)(App.Current.Resources["LimitedConnectivityBrush"]);
                    case NetworkConnectivityLevel.LocalAccess:
                        return (SolidColorBrush)(App.Current.Resources["LimitedConnectivityBrush"]);
                    default:
                        return (SolidColorBrush)(App.Current.Resources["NoneConnectivityBrush"]);
                }
            }
            else
            {
                        return (SolidColorBrush)(App.Current.Resources["NoneConnectivityBrush"]);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
