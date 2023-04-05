using System.Reflection;
using CommunityToolkit.Maui;
using MauiTraining.DataAccess;
using MauiTraining.Services;
using MauiTraining.ViewModel;
using MauiTraining.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MauiTraining;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var assemblyInstance = Assembly.GetExecutingAssembly();
        using var stream = assemblyInstance.GetManifestResourceStream("MauiTraining.appsettings.json");

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Lobster-Regular.ttf", "RockLobster");
            });

        builder.Configuration.AddConfiguration(config);

        // Services
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton(Connectivity.Current);
        builder.Services.AddSingleton<SecurityService>();
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<BuildingService>();
        builder.Services.AddSingleton<IDatabasePathService, DatabasePathService>();

        //views
        builder.Services.AddTransient<HelpSupportViewModel>();
        builder.Services.AddTransient<HelpSupportPage>();
        builder.Services.AddTransient<HelpSupportDetailViewModel>();
        builder.Services.AddTransient<HelpSupportDetailPage>();
        builder.Services.AddTransient<ClientsViewModel>();
        builder.Services.AddTransient<ClientsPage>();
        builder.Services.AddTransient<ProductDetailsViewModel>();
        builder.Services.AddTransient<ProductDetailsPage>();
        builder.Services.AddTransient<ProductsViewModel>();
        builder.Services.AddTransient<ProductsPage>();
        builder.Services.AddTransient<DashboardViewModel>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<BookmarkViewModel>();
        builder.Services.AddTransient<BookmarkPage>();
        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<BuildingListViewModel>();
        builder.Services.AddTransient<BuildingListPage>();
        builder.Services.AddTransient<BuildingDetailViewModel>();
        builder.Services.AddTransient<BuildingDetailPage>();
        builder.Services.AddTransient<SearchBuildingViewModel>();
        builder.Services.AddTransient<SearchBuildingPage>();

        // Db context
        builder.Services.AddDbContext<ShopOutDbContext>();
        var dbContext = new ShopDbContext();
        dbContext.Database.EnsureCreated();
        dbContext.Dispose();

        // routing
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(BuildingDetailPage), typeof(BuildingDetailPage));
        Routing.RegisterRoute(nameof(ProductDetailsPage), typeof(ProductDetailsPage));
        Routing.RegisterRoute(nameof(HelpSupportDetailPage), typeof(HelpSupportDetailPage));
        Routing.RegisterRoute(nameof(BuildingListPage), typeof(BuildingListPage));
        Routing.RegisterRoute(nameof(SearchBuildingPage), typeof(SearchBuildingPage));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

