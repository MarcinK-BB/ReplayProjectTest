using ReplayProjectTest.Pages;

namespace ReplayProjectTest
{
   
    public static class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            //Driver and settings Initialization
            services.UseWebDriverInitializer();
            services.AddScoped<IDriverFactory, DriverFactory>();
            services.AddScoped<IBrowserDriver, BrowserDriver>();

            //Pages initialization
            services.AddScoped<ILoginPage, LoginPage>();

            return services;
        }

    }
}
