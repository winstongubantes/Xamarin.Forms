using System;
using System.Collections.Generic;
using System.Globalization;
using Android.Content;
using Android.Support.Design.Widget;
using CustomIconizeFont.Controls;
using CustomIconizeFont.Droid.Custom.Renderers;
using CustomIconizeFont.Droid.Custom.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(FlatTabbedPage), typeof(IconTabbedPageRenderer))]
namespace CustomIconizeFont.Droid.Custom.Renderers
{
    /// <summary>
    /// Defines the <see cref="IconTabbedPageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.TabbedPageRenderer" />
    public class IconTabbedPageRenderer : TabbedPageRenderer
    {
        private readonly List<String> _icons = new List<String>();

        public IconTabbedPageRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            UpdateTabbedIcons(Context);

            base.OnAttachedToWindow();
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{TabbedPage}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            _icons.Clear();
            if (e.NewElement != null)
            {
                foreach (var page in e.NewElement.Children)
                {
                    if (page.Icon != null)
                    {
                        _icons.Add(page.Icon.File);
                        page.Icon = null;
                    }
                }
            }

            base.OnElementChanged(e);
        }

        /// <summary>
        /// Updates the tabbed icons.
        /// </summary>
        private void UpdateTabbedIcons(Context context)
        {
            var tabLayout = FindViewById<TabLayout>(Iconize.TabLayoutId);
            if (tabLayout == null || tabLayout.TabCount == 0)
                return;

            var element = (FlatTabbedPage)this.Element;

            for (var i = 0; i < tabLayout.TabCount; i++)
            {
                var tab = tabLayout.GetTabAt(i);

                if (_icons != null && i < _icons.Count)
                {
                    var iconKey = _icons[i];

                    int.TryParse($"{element.FontSize}", out var fontSize);

                    var drawable = new IconDrawable(context, iconKey, element.FontFamily).Color(Color.White.ToAndroid()).SizeDp(fontSize);

                    tab.SetIcon(drawable);
                }
            }
        }
    }
}