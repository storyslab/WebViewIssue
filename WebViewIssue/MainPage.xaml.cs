using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WebViewIssue
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += AppBackRequested;
        }

        private void AppBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
                return;

            // If we can go back and the event has not already been handled, do so.
            if (!rootFrame.CanGoBack || e.Handled)
                return;

            e.Handled = true;

            rootFrame.GoBack();
        }

        private void VideoOne_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WebViewPage), new Dictionary<string, string>
            {
                { "site" , "https://www.youtube.com/watch?v=up863eQKGUI" }
            });
        }

        private void VideoTwo_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WebViewPage), new Dictionary<string, string>
            {
                { "site" , "https://www.youtube.com/watch?v=MAtayYbOL-o" }
            });
        }

        private void VideoThree_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WebViewPage), new Dictionary<string, string>
            {
                { "site" , "https://www.youtube.com/watch?v=UQ-RTZCOQn0" }
            });
        }
    }
}
