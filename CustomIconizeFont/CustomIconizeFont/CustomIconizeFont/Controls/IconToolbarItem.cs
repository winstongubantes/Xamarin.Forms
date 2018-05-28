using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CustomIconizeFont.Controls
{
    public class IconToolbarItem : ToolbarItem
    {
        public const string UpdateToolbarItemsMessage = "Iconize.UpdateToolbarItems";

        public static BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconToolbarItem), default(Color));
        public static BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(Boolean), typeof(IconToolbarItem), true);
        public static BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(IconToolbarItem), null);

        public Color IconColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public Boolean IsVisible
        {
            get => (Boolean)GetValue(IsVisibleProperty);
            set => SetValue(IsVisibleProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public IconToolbarItem()
        {
            PropertyChanged += OnPropertyChanged;
        }

        private void OnCanExecuteChanged(object sender, EventArgs e)
        {
            MessagingCenter.Send(sender, UpdateToolbarItemsMessage);
        }

        private void OnPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            MessagingCenter.Send(sender, UpdateToolbarItemsMessage);

            if (e.PropertyName == nameof(Command))
            {
                if (Command != null)
                {
                    Command.CanExecuteChanged += OnCanExecuteChanged;
                }
            }
        }
    }
}