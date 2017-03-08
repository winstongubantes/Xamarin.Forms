using System.Windows.Input;
using Xamarin.Forms;

namespace CustomSlideOverMenu.Behaviors
{
    ////We are not using EventToCommandBehavior because we have multi-event related to only one property
    public class LineFocusEntryBehavior : BehaviorBase<Entry>
    {
        public static readonly BindablePropertyKey BackgroundColorPropertyKey = BindableProperty.CreateReadOnly("BackgroundColor", typeof(Color), typeof(LineFocusEntryBehavior), Color.White);

        public static readonly BindableProperty FocusBackgroundColorProperty = BindableProperty.Create("FocusBackgroundColorPropertyKey", typeof(Color), typeof(LineFocusEntryBehavior), Color.White);

        public static readonly BindableProperty UnFocusBackgroundColorProperty = BindableProperty.Create("UnFocusBackgroundColorPropertyKey", typeof(Color), typeof(LineFocusEntryBehavior), Color.White);

        ////read-only property ^
        public static readonly BindableProperty BackgroundColorProperty = BackgroundColorPropertyKey.BindableProperty;

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(LineFocusEntryBehavior), null);

        public Color BackgroundColor
        {
            get { return (Color) GetValue(BackgroundColorProperty); }
            private set { SetValue(BackgroundColorPropertyKey, value); }
        }

        public Color FocusBackgroundColor
        {
            get { return (Color)GetValue(FocusBackgroundColorProperty); }
            private set { SetValue(FocusBackgroundColorProperty, value); }
        }

        public Color UnFocusBackgroundColor
        {
            get { return (Color)GetValue(UnFocusBackgroundColorProperty); }
            private set { SetValue(UnFocusBackgroundColorProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.Focused += Bindable_Focused;
            bindable.Unfocused += Bindable_Unfocused;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Focused -= Bindable_Focused;
            bindable.Unfocused -= Bindable_Unfocused;
            base.OnDetachingFrom(bindable);
        }

        private void Bindable_Focused(object sender, FocusEventArgs e)
        {
            ////When the text entry in focus, set background color of the affecting elements(ex. Box)
            BackgroundColor = FocusBackgroundColor; ////Color.FromHex("#73d540");

            if (Command != null)
                Command.Execute(true);
        }

        private void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            ////When the text entry in focus, set background color of the affecting elements(ex. Box)
            BackgroundColor = UnFocusBackgroundColor;

            if (Command != null)
                Command.Execute(false);
        }
    }
}