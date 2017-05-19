using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin.Abstractions.Events.Inbound;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HybridApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            SetHighchartsWebviewCallbackAndEvents();

            SetCalendarWebviewCallbackAndEvents();
        }

        private void SetCalendarWebviewCallbackAndEvents()
        {
            //This will be triggered by webview
            CalendarWebView.RegisterLocalCallback("selectdate", (str) =>
            {
                DisplayAlert("Selected Date", str, "OK");
            });


            CalendarWebView.OnNavigationStarted += OnNavigationStarted;
            CalendarWebView.OnNavigationCompleted += OnNavigationCompleted;
            CalendarWebView.OnContentLoaded += OnContentLoaded;
            CalendarWebView.OnJavascriptResponse += OnJavascriptResponse;
        }

        private void SetHighchartsWebviewCallbackAndEvents()
        {
            //This will be triggered by webview
            HighchartsWebView.RegisterLocalCallback("afterload", (str) =>
            {
                Debug.WriteLine(str);
            });


            HighchartsWebView.OnNavigationStarted += OnNavigationStarted;
            HighchartsWebView.OnNavigationCompleted += OnNavigationCompleted;
            HighchartsWebView.OnContentLoaded += OnContentLoaded;
            HighchartsWebView.OnJavascriptResponse += OnJavascriptResponse;
        }

        private void OnJavascriptResponse(JavascriptResponseDelegate eventObj)
        {
            Debug.WriteLine(string.Format("Javascript: {0}", eventObj.Data));
        }

        private void OnContentLoaded(ContentLoadedDelegate eventObj)
        {
            Debug.WriteLine(string.Format("Load Complete: {0}", eventObj.Sender.Source));
        }

        private void OnNavigationCompleted(NavigationCompletedDelegate eventObj)
        {
            Debug.WriteLine(string.Format("Navigation has been commited: {0}", eventObj.Uri));
        }

        private NavigationRequestedDelegate OnNavigationStarted(NavigationRequestedDelegate eventObj)
        {
            if (eventObj.Uri == "www.somebadwebsite.com")
                eventObj.Cancel = true;

            return eventObj;
        }
    }
}