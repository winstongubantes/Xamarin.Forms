using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationApp.Behaviors.Base;
using Xamarin.Forms;

namespace ValidationApp.Behaviors
{
    public class EntryValidatorBehavior : BehaviorBase<Entry>
    {
        public static readonly BindableProperty IsValidProperty = 
            BindableProperty.Create(nameof(IsValid), typeof(bool), 
                typeof(EntryValidatorBehavior), false, BindingMode.OneWayToSource);        

        public bool IsValid
        {
            get { return (bool) GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var isValid = !string.IsNullOrWhiteSpace(e.NewTextValue);
            IsValid = isValid;
        }
    }
}
