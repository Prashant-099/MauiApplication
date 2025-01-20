using Microsoft.Extensions.Logging;
using MauiAppFB.Services;

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
            // Register HttpClient as Singleton with a base URL
            builder.Services.AddSingleton(sp =>
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://147.79.68.129/") // Set the base URL of your API
                };
                return client;
            });
          

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
