using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Xamarin.Forms;

namespace FloatingActionButton.Views
{
    public partial class FloatingButtonPage : ContentPage
    {
        private bool _isOpenMenu = false;
        private double _originalLeft;
        private double _originalWidth;

        public FloatingButtonPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitializeButton();
            InitializeGestureCommands();
        }

        private void InitializeGestureCommands()
        {
            ButtonLayout.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ToggleActionBarMenu)
            });

            GoogleButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ToggleActionBarMenu)
            });

            FbButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ToggleActionBarMenu)
            });

            TwitterButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ToggleActionBarMenu)
            });

            LinkedButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ToggleActionBarMenu)
            });

            TelegramButton.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(ToggleActionBarMenu)
            });
        }

        private void InitializeButton()
        {
            Task.Delay(600).ContinueWith(t =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ButtonLayout.TranslationX = (Width / 2) - ButtonLayout.Height;
                    AnimateButtonOut();
                });
            });
        }

        private  void ToggleActionBarMenu()
        {
            if (!_isOpenMenu)
            {
                OpenMenu();

                _isOpenMenu = true;
            }
            else
            {
                CloseMenu();

                _isOpenMenu = false;
            }
        }

        private void CloseMenu()
        {
            MenuLayout.TranslateTo(0, MenuLayout.Height, 20);
            MenuLayout.FadeTo(0.2);

            AnimateBlueBarOut().ContinueWith(t =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    BlueBarLayout.TranslationY = BlueBarLayout.Height;
                    ButtonLayout.IsVisible = true;

                    AnimateButtonOut();
                });
            });
        }

        private void OpenMenu()
        {
            AnimateButtonIn().ContinueWith(e =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    BlueBarLayout.TranslationY = 0;
                    ButtonLayout.IsVisible = false;

                    AnimateBlueBarIn().ContinueWith(t =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            MenuLayout.TranslateTo(0, 0);
                            MenuLayout.FadeTo(0.75);
                        });
                    });
                });
            });
        }

        private Task AnimateButtonIn()
        {
            return ButtonLayout.TranslateTo(0, 0, 150);
        }

        private Task AnimateButtonOut()
        {
            var y =  - 30;
            var x = (Width / 2) - ButtonLayout.Height;

            return ButtonLayout.TranslateTo(x, y, 150);
        }

        private Task AnimateBlueBarIn()
        {
            var r = BlueBarLayout.Bounds;
            _originalLeft = r.Left;
            _originalWidth = r.Width;

            r.Width = MenuLayout.Width + 5;
            r.Left = r.Left - ((Width - _originalWidth) / 2);
            return BlueBarLayout.LayoutTo(r, 150);
        }

        private Task AnimateBlueBarOut()
        {
            var r = BlueBarLayout.Bounds;
            r.Width = _originalWidth;
            r.Left = _originalLeft;
            return BlueBarLayout.LayoutTo(r, 150);
        }
    }
}
