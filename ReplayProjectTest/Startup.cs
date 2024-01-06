namespace ReplayProjectTest
{
   
    public static class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.UseWebDriverInitializer();
            services.AddScoped<IDriverFactory, DriverFactory>();
            services.AddScoped<IBrowserDriver, BrowserDriver>();

            return services;
        }

    }
}
