using CoreGraphics;
using CoreText;
using CustomIconizeFont.Controls;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace CustomIconizeFont.iOS.Custom.Extensions
{
    public static class PlatformExtensions
    {
        public static UIImage ToUiImage(string icon, string fontFamily, nfloat size)
        {
            var attributedString = new NSAttributedString(icon, new CTStringAttributes
            {
                Font = new CTFont(fontFamily, size),
                ForegroundColorFromContext = true
            });

            var boundSize = attributedString.GetBoundingRect(new CGSize(10000f, 10000f), NSStringDrawingOptions.UsesLineFragmentOrigin, null).Size;

            UIGraphics.BeginImageContextWithOptions(boundSize, false, 0f);
            attributedString.DrawString(new CGRect(0f, 0f, boundSize.Width, boundSize.Height));
            using (var image = UIGraphics.GetImageFromCurrentImageContext())
            {
                UIGraphics.EndImageContext();

                return image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            }
        }

        public static IList<ToolbarItem> GetToolbarItems(this Page page)
        {
            var list = new List<ToolbarItem>(page.ToolbarItems);

            if (page is MasterDetailPage masterDetailPage)
            {
                if (masterDetailPage.IsPresented)
                {
                    if (masterDetailPage.Master != null)
                        list.AddRange(masterDetailPage.Master.GetToolbarItems());
                }
                else if (masterDetailPage.Detail != null)
                {
                    list.AddRange(masterDetailPage.Detail.GetToolbarItems());
                }
            }
            else if (page is IPageContainer<Page> pageContainer)
            {
                if (pageContainer.CurrentPage != null)
                    list.AddRange(pageContainer.CurrentPage.GetToolbarItems());
            }

            return list;
        }

        public static void UpdateToolbarItems(this Page page, UINavigationController controller)
        {
            try
            {
                if (page == null || controller == null)
                    return;

                if (controller.IsBeingDismissed == true)
                    return;

                var navController = controller.VisibleViewController;
                if (navController == null)
                    return;

                if (navController.NavigationItem?.RightBarButtonItems != null)
                {
                    for (var i = 0; i < navController.NavigationItem.RightBarButtonItems.Length; ++i)
                        navController.NavigationItem.RightBarButtonItems[i].Dispose();
                }

                if (navController.ToolbarItems != null)
                {
                    for (var i = 0; i < navController.ToolbarItems.Length; ++i)
                        navController.ToolbarItems[i].Dispose();
                }

                var toolbarItems = page.GetToolbarItems();
                if (toolbarItems == null)
                    return;

                List<UIBarButtonItem> primaries = null;
                List<UIBarButtonItem> secondaries = null;

                foreach (var toolbarItem in toolbarItems)
                {
                    var barButtonItem = toolbarItem.ToUIBarButtonItem(toolbarItem.Order == ToolbarItemOrder.Secondary);
                    if (toolbarItem is IconToolbarItem iconItem)
                    {
                        if (iconItem.IsVisible == false)
                            continue;

                        if (iconItem.Icon != null)
                        {
                            using (var image = ToUiImage(iconItem.Icon.File, iconItem.FontFamily, 22f))
                            {
                                barButtonItem.Image = image;
                                if (iconItem.IconColor != Color.Default)
                                    barButtonItem.TintColor = iconItem.IconColor.ToUIColor();
                            }
                        }
                    }

                    if (toolbarItem.Order == ToolbarItemOrder.Secondary)
                        (secondaries = secondaries ?? new List<UIBarButtonItem>()).Add(barButtonItem);
                    else
                        (primaries = primaries ?? new List<UIBarButtonItem>()).Add(barButtonItem);
                }

                primaries?.Reverse();

                navController.NavigationItem?.SetRightBarButtonItems(
                    primaries?.ToArray() ?? new UIBarButtonItem[0], false);
                navController.ToolbarItems = secondaries?.ToArray() ?? new UIBarButtonItem[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}