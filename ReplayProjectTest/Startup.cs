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


            //Waits initialization
            services.AddScoped<IWaits, Waits>();

            //Pages initialization
            services.AddScoped<ILoginPage, LoginPage>();
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<IContactListPage, ContactListPage>();
            services.AddScoped<IContactCreatePage, ContactCreatePage>();
            services.AddScoped<IContactEditPage, ContactEditPage>();
            services.AddScoped<IReportListPage, ReportListPage>();
            services.AddScoped<IReportEditPage, ReportEditPage>();
            services.AddScoped<IActivityLogPage, ActivityLogPage>();


            return services;
        }

    }
}
