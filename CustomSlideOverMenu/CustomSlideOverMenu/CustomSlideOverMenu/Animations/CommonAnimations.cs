using Xamarin.Forms;

namespace CustomSlideOverMenu.Animations
{
    public class CommonAnimations
    {
        public static Animation TransLateYAnimation(VisualElement element, double from, double to)
        {
            return new Animation(d => { element.TranslationY = d; }, from, to);
        }

        public static Animation TransLateXAnimation(VisualElement element, double from, double to)
        {
            return new Animation(d => { element.TranslationX = d; }, from, to);
        }

        public static Animation OpacityAnimation(VisualElement element, double from, double to)
        {
            return new Animation(d => { element.Opacity = d; }, from, to);
        }

        public static Animation ScaleAnimation(VisualElement element, double from, double to)
        {
            return new Animation(d => { element.Scale = d; }, from, to);
        }
    }
}
