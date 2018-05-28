using System;
using Android.Content;
using Android.Content.Res;
using CustomIconizeFont.Controls;
using CustomIconizeFont.Droid.Custom.Extensions;
using CustomIconizeFont.Droid.Custom.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(FlatNavigationPage), typeof(FlatNavigationPageRenderer))]
namespace CustomIconizeFont.Droid.Custom.Renderers
{
    /// <summary>
    /// Defines the <see cref="FlatNavigationPageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer" />
    public class FlatNavigationPageRenderer : NavigationPageRenderer
    {
        private Orientation _orientation = Orientation.Portrait;

#pragma warning disable 1591
        public FlatNavigationPageRenderer(Context context) : base(context)
#pragma warning restore 1591
        {
            
        }

        /// <summary>
        /// Called when [attached to window].
        /// </summary>
        protected override void OnAttachedToWindow()
        {
            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);
            OnUpdateToolbarItems(this);

            InitListeners();
            base.OnAttachedToWindow();
        }

        /// <summary>
        /// Called when the current configuration of the resources being used
        /// by the application have changed.
        /// </summary>
        /// <param name="newConfig">The new resource configuration.</param>
        /// <remarks>
        /// <para tool="javadoc-to-mdoc">Called when the current configuration of the resources being used
        /// by the application have changed.  You can use this to decide when
        /// to reload resources that can changed based on orientation and other
        /// configuration characterstics.  You only need to use this if you are
        /// not relying on the normal <c><see cref="T:Android.App.Activity" /></c> mechanism of
        /// recreating the activity instance upon a configuration change.</para>
        /// <para tool="javadoc-to-mdoc">
        ///   <format type="text/html">
        ///     <a href="http://developer.android.com/reference/android/view/View.html#onConfigurationChanged(android.content.res.Configuration)" target="_blank">[Android Documentation]</a>
        ///   </format>
        /// </para>
        /// </remarks>
        /// <since version="Added in API level 8" />
        protected override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            if (newConfig.Orientation != _orientation)
            {
                _orientation = newConfig.Orientation;
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    OnUpdateToolbarItems(this);
                    return false;
                });
            }
        }

        /// <summary>
        /// Called when [detached from window].
        /// </summary>
        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();

            DestroyListeners();
            MessagingCenter.Unsubscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage);
        }

        /// <summary>
        /// Called when [update toolbar items].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnUpdateToolbarItems(Object sender)
        {
            Element?.UpdateToolbarItems(this);
        }

        /// <summary>
        /// Initializes the event listeners.
        /// </summary>
        private void InitListeners()
        {
            if(Element == null) return;
            Element.Popped += OnNavigation;
            Element.PoppedToRoot += OnNavigation;
            Element.Pushed += OnNavigation;
        }

        private void DestroyListeners()
        {
            if (Element == null) return;
            Element.Popped -= OnNavigation;
            Element.PoppedToRoot -= OnNavigation;
            Element.Pushed -= OnNavigation;
        }

        /// <summary>
        /// Called when [navigation].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnNavigation(Object sender, NavigationEventArgs e)
        {
            MessagingCenter.Send(sender, IconToolbarItem.UpdateToolbarItemsMessage);
        }
    }
}