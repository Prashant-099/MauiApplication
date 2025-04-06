using Microsoft.Extensions.Logging;
using MauiAppFB.Services;
using DevExpress.Blazor;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.ReportDesigner;
using DevExpress.AspNetCore;
using Devexpress.Blazor.Internal;

namespace MauiAppFB
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
               
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("bootstrap-icons.woff2", "BootstrapIcons");
            });
            // Register HttpClient as Singleton with a base URL
            builder.Services.AddSingleton(sp =>
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://147.79.68.129/") // Set the base URL of your API
                };
                return client;
            });
            builder.Services.AddDevExpressBlazor();
            builder.Services.AddDevExpressWebAssemblyBlazorReportViewer();
            builder.Services.AddDevExpressServerSideBlazorReportViewer();
          
      // Register the AuthService as Singleton (uses HttpClient)
      builder.Services.AddSingleton<AuthService>();

            // Register the CargoService with the HttpClient dependency injected
            builder.Services.AddScoped<CargoService>();
            builder.Services.AddScoped<AccountsService>();
            builder.Services.AddScoped<AccountGroupService>();
            builder.Services.AddScoped<CountryService>();
            builder.Services.AddScoped<CurrenciesService>();
            builder.Services.AddScoped<LocationService>();
            builder.Services.AddScoped<NotifyService>();
            builder.Services.AddScoped<StatesService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<USerRoleService>();
            builder.Services.AddScoped<VehiclesService>();
            builder.Services.AddScoped<VehicleTypeService>();
            builder.Services.AddScoped<CompanyService>();
            builder.Services.AddScoped<LRService>();
            builder.Services.AddScoped<PrintService>();
            builder.Services.AddScoped<PaytypeService>();
            builder.Services.AddScoped<Reportservice>();
            // Register Maui Blazor WebView
            builder.Services.AddMauiBlazorWebView();
            

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
