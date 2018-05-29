using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace CustomIconizeFont.iOS.Helpers
{
    public static class FormsViewToNativeiOS
    {
        public static UIView ConvertFormsToNative(this Xamarin.Forms.View view, CGRect size)
        {
            var renderer = Platform.CreateRenderer(view);

            renderer.NativeView.Frame = size;
            //renderer.NativeView.AutosizesSubviews = true;
            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;

            renderer.Element.Layout(size.ToRectangle());
            var nativeView = renderer.NativeView;
            nativeView.SetNeedsLayout();
            //nativeView.SetNeedsDisplayInRect(size);

            return nativeView;
        }
    }
}