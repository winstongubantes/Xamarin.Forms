namespace CustomIconizeFont.Droid.Custom.Utils
{
    /// <summary>
    /// Defines the <see cref="Iconize" /> type.
    /// </summary>
    public static partial class Iconize
    {
        public static int TabLayoutId { get; private set; }
        public static int ToolbarId { get; private set; }

        public static void Init(int toolbarId = 0, int tabLayoutId = 0)
        {
            TabLayoutId = tabLayoutId;
            ToolbarId = toolbarId;
        }
    }
}