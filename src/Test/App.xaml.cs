using MahApps.Metro;
using System;
using System.Windows;
using TestApp.Kernel;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Core.StartUp_Engine();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            if (string.IsNullOrWhiteSpace(Core.Color))
            {
                Core.Color = "Teal";
            }
            if (string.IsNullOrWhiteSpace(Core.Theme))
            {
                Core.Theme = "BaseLight";
            }
            else
            {
                ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(Core.Color), ThemeManager.GetAppTheme(Core.Theme));
            }
            base.OnStartup(e);
        }
    }
}
