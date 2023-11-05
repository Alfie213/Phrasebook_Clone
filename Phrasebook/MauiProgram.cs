using Microsoft.Extensions.Logging;

using Phrasebook.PartialViews;
using Phrasebook.Services;
using Phrasebook.ViewModels;
using Phrasebook.ViewModels.Account;
using Phrasebook.ViewModels.PartialViews;
using Phrasebook.Views;
using Phrasebook.Views.Account;

namespace Phrasebook;
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

		var services = builder.Services;

#pragma warning disable CA2000
		services.AddSingleton(new HttpClient() { BaseAddress = new Uri("https://localhost:7291/api/") });
#pragma warning restore CA2000

		services.AddSingleton<AppShellViewModel>();

		services.AddSingleton<SignInViewModel>();
		services.AddSingleton<SignInPage>();

		services.AddSingleton<RegistrationViewModel>();
		services.AddSingleton<RegistrationPage>();

		services.AddSingleton<FlyoutHeaderViewModel>();
		services.AddSingleton<FlyoutHeader>();

		services.AddSingleton<LearnPageViewModel>();
		services.AddSingleton<LearnPage>();

		services.AddScoped<IAuthenticationService, AuthenticationService>();
		services.AddScoped<IRegistrationService, RegistrationService>();
		services.AddScoped<IUserService, UserService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
