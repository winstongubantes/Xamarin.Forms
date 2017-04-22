// Helpers/Settings.cs

using DynamicTheming.Enums;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DynamicTheming.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

    private const string ThemeKey = "theme_key";
    private static readonly AppTheme ThemeDefault = AppTheme.Dark;

    #endregion

      public static AppTheme Theme
        {
          get { return (AppTheme)AppSettings.GetValueOrDefault<int>(SettingsKey, (int)ThemeDefault); }
          set { AppSettings.AddOrUpdateValue<int>(SettingsKey, (int)value); }
      }

      public static string GeneralSettings
      {
          get { return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault); }
          set { AppSettings.AddOrUpdateValue<string>(SettingsKey, value); }
      }

  }
}