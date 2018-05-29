using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using CustomIconizeFont.Controls;
using CustomIconizeFont.Droid.Custom.Listeners;
using CustomIconizeFont.Droid.Custom.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace CustomIconizeFont.Droid.Custom.Extensions
{
    public static class PlatformExtensions
    {
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

        private static Drawable GetToolbarItemDrawable(this ToolbarItem toolbarItem, Context context)
        {
            if (String.IsNullOrWhiteSpace(toolbarItem.Icon))
                return null;

            if (!(toolbarItem is IconToolbarItem iconItem))
                return context.GetDrawable(toolbarItem.Icon.File);

            var drawable = new IconDrawable(context, iconItem.Icon.File, iconItem.FontFamily);

            if (iconItem.IconColor != Color.Default)
                drawable = drawable.Color(iconItem.IconColor.ToAndroid());

            return drawable.ActionBarSize();
        }

        public static void UpdateToolbarItems(this Page page, Android.Views.View view)
        {
            var toolbar = view.FindViewById<Toolbar>(Iconize.ToolbarId);
            if (toolbar == null)
                return;

            toolbar.Menu.Clear();

            var toolbarItems = page.GetToolbarItems();
            if (toolbarItems == null)
                return;

            foreach (var toolbarItem in toolbarItems)
            {
                if (((toolbarItem as IconToolbarItem)?.IsVisible ?? true) == false)
                    continue;

                var menuItem = toolbar.Menu.Add(toolbarItem.Text);
                menuItem.SetOnMenuItemClickListener(new MenuClickListener(toolbarItem.Activate));

                var icon = toolbarItem.GetToolbarItemDrawable(toolbar.Context);
                if (icon != null)
                    menuItem.SetIcon(icon);

                if (toolbarItem.Order != ToolbarItemOrder.Secondary)
                    menuItem.SetShowAsAction(ShowAsAction.Always);
            }

            if (!(page is FlatNavigationPage navPage)) return;

            if (navPage.Logo != null)
            {
                toolbar.Logo = view.Context.GetDrawable(navPage.Logo);
                //toolbar.Logo.SetLayoutDirection(LayoutDirection.Ltr);
            }  
        }
    }
}