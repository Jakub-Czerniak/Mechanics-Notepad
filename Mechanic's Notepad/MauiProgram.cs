using CommunityToolkit.Maui;
using Mechanic_s_Notepad.ViewModels;
using Mechanic_s_Notepad.Views;

namespace Mechanic_s_Notepad;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

		builder.Services.AddSingleton<CarListViewModel>();
        builder.Services.AddSingleton<CarListPage>();

        builder.Services.AddTransient<CarDetailsViewModel>();
        builder.Services.AddTransient<CarDetailsPage>();

        builder.Services.AddTransient<AddNewCarViewModel>();
        builder.Services.AddTransient<AddCarPage>();

        builder.Services.AddTransient<AddNewServiceViewModel>();
        builder.Services.AddTransient<AddServicePage>();

        /*builder.Services.AddTransient<ServiceDetailsViewModel>();
        builder.Services.AddTransient<SeviceDetailsPage>();*/


        return builder.Build();
	}
}
