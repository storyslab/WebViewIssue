using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WebViewIssue
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewPage()
        {
            this.InitializeComponent();

            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                // always try to go back within the WebView first, then try the frame!
                if (WebViewer.CanGoBack)
                {
                    WebViewer.GoBack();
                    a.Handled = true;
                }
                else
                {
                    WebViewer.NavigateToString("<html>Unloaded.</html>");
                    WebViewer.NavigateToString("");
                    var source = WebViewer.Source; // is cleared to null
                }
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var site = (e.Parameter as Dictionary<string, string>)["site"];
            WebViewer.Navigate(new Uri(site));
        }
    }
}
