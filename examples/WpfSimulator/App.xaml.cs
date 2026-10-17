using System;
using System.Windows;
using System.Windows.Threading;

namespace WpfSimulator
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var splash = new SplashWindow();
            splash.Show();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                var main = new MainWindow();
                MainWindow = main;
                main.Show();
                splash.Close();
            };
            timer.Start();
        }
    }
}
