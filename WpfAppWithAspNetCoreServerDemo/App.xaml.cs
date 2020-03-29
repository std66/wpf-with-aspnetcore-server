using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace WpfAppWithAspNetCoreServerDemo {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private IHost host;

        protected override void OnStartup(StartupEventArgs e) {
            //start server
            host = CreateHostBuilder(e.Args).Build();
            host.Start();

            //start UI
            //NOTE: In App.xaml, I removed StartupUri.

            //This is mandatory, unless this assignment the application
            //will not terminate if the main window is closed.
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;

            this.MainWindow = host.Services.GetService<MainWindow>();
            this.MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e) {
            host.Services.GetService<IHostApplicationLifetime>().StopApplication();
            host.Dispose();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder
                        .UseStartup<Startup>();
                });
    }
}
