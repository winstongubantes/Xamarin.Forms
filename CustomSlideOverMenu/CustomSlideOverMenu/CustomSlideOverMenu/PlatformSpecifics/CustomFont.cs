 // ReSharper disable once CheckNamespace
namespace PlatformSpecifics.Android
{
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.PlatformConfiguration;
    using FormsElement = Xamarin.Forms.View;

    public static class CustomFont
    {
        const string EffectName = "Custom.FontEffect";

        public static readonly BindableProperty IsCustomFontProperty = BindableProperty.CreateAttached("IsCustomFont", typeof(bool), typeof(CustomFont), false, propertyChanged: OnIsShadowedPropertyChanged);

        public static bool GetIsCustomFont(BindableObject element)
        {
            return (bool)element.GetValue(IsCustomFontProperty);
        }

        public static void SetIsCustomFont(BindableObject element, bool value)
        {
            element.SetValue(IsCustomFontProperty, value);
        }

        //This seems like it only supports boolean
        public static bool IsCustomFont(this IPlatformElementConfiguration<Android, FormsElement> config)
        {
            return GetIsCustomFont(config.Element);
        }

        public static IPlatformElementConfiguration<Android, FormsElement> SetIsCustomFont(this IPlatformElementConfiguration<Android, FormsElement> config, bool value)
        {
            SetIsCustomFont(config.Element, value);
            return config;
        }

        static void OnIsShadowedPropertyChanged(BindableObject element, object oldValue, object newValue)
        {
            if ((bool)newValue)
            {
                AttachEffect(element as FormsElement);
            }
            else
            {
                DetachEffect(element as FormsElement);
            }
        }

        private static void AttachEffect(FormsElement element)
        {
            IElementController controller = element;
            if (controller == null || controller.EffectIsAttached(EffectName))
            {
                return;
            }
            element.Effects.Add(Effect.Resolve(EffectName));
        }

        private static void DetachEffect(FormsElement element)
        {
            IElementController controller = element;
            if (controller == null || !controller.EffectIsAttached(EffectName))
            {
                return;
            }

            var toRemove = element.Effects.FirstOrDefault(e => e.ResolveId == Effect.Resolve(EffectName).ResolveId);
            if (toRemove != null)
            {
                element.Effects.Remove(toRemove);
            }
        }
    }
}
