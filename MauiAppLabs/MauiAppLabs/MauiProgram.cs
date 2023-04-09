using MauiAppLabs.Converter;
using MauiAppLabs.Tourism;
using NbrbAPI.Models;


namespace MauiAppLabs;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder.Services.AddTransient<IDbService, SQLiteService>();
        builder.Services.AddSingleton<TourismView>();
        
		builder.Services.AddHttpClient<IRateService, RateService>(opt =>
               opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));

        builder.Services.AddTransient<CurConverterVM>();
        builder.Services.AddSingleton<ConverterView>();
        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
