using System;
using System.Collections.Generic;
using CustomIconizeFont.Controls;
using CustomIconizeFont.iOS.Custom.Extensions;
using CustomIconizeFont.iOS.Custom.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlatTabbedPage), typeof(FlatTabbedPageRenderer))]
namespace CustomIconizeFont.iOS.Custom.Renderers
{
    public class FlatTabbedPageRenderer : TabbedRenderer
    {
        private readonly List<string> _icons = new List<string>();
        private string _fontFamily ;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            _icons.Clear();
            if (e.NewElement != null)
            {
                _fontFamily = ((FlatTabbedPage) e.NewElement).FontFamily;
                foreach (var page in ((TabbedPage)e.NewElement).Children)
                {
                    _icons.Add(page.Icon.File);
                    page.Icon = null;
                }
            }

            base.OnElementChanged(e);
        }

        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);

            foreach (var tab in TabBar.Items)
            {
                var icon = _icons?[(Int32) tab.Tag];
                using (var image = PlatformExtensions.ToUiImage(icon, _fontFamily, 25f))
                {
                    tab.Image = image;
                    tab.SelectedImage = image;
                }
            }
        }
    }
}