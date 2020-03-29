using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfAppWithAspNetCoreServerDemo.ViewModels;

namespace WpfAppWithAspNetCoreServerDemo {
    class Startup {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration) {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services
                .AddSingleton<MainWindow>(
                    provider => new MainWindow(
                        provider.GetService<MainWindowViewModel>()
                    )
                )
                .AddSingleton<MainWindowViewModel>();

            services.AddControllersWithViews(x => x.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
