using System;
using System.Linq;
using CoreGraphics;
using CustomIconizeFont.Controls;
using CustomIconizeFont.iOS.Custom.Extensions;
using CustomIconizeFont.iOS.Custom.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlatNavigationPage), typeof(FlatNavigationRenderer))]
namespace CustomIconizeFont.iOS.Custom.Renderers
{
    public class FlatNavigationRenderer : NavigationRenderer
    {
        public override void ViewWillAppear(Boolean animated)
        {
            base.ViewWillAppear(animated);

            MessagingCenter.Subscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage, OnUpdateToolbarItems);
            OnUpdateToolbarItems(this);
            SetNavigationIcon();
        }

        public override void ViewWillDisappear(Boolean animated)
        {
            MessagingCenter.Unsubscribe<Object>(this, IconToolbarItem.UpdateToolbarItemsMessage);

            base.ViewWillDisappear(animated);
        }

        private void OnUpdateToolbarItems(Object sender)
        {
            (Element as NavigationPage)?.UpdateToolbarItems(this);
        }

        private void SetNavigationIcon()
        {
            var element = (FlatNavigationPage)this.Element;

            if(element.Icon == null) return;

            var image = UIImage.FromBundle(element.Icon.File);
            var imageView = new UIImageView(new CGRect(0, 0, image.Size.Width, 40));
            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            imageView.Image = image; //image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);

            TopViewController.NavigationItem.TitleView = imageView;
        }
    }
}