using Microsoft.Extensions.Logging;

using Phrasebook.PartialViews;
using Phrasebook.Services;
using Phrasebook.ViewModels;
using Phrasebook.ViewModels.Account;
using Phrasebook.ViewModels.PartialViews;
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

#pragma warning disable CA2000
		builder.Services.AddSingleton(new HttpClient() { BaseAddress = new Uri("https://localhost:7291/api/") });
#pragma warning restore CA2000

		builder.Services.AddSingleton<AppShellViewModel>();

		builder.Services.AddSingleton<SignInViewModel>();
		builder.Services.AddSingleton<SignInPage>();

		builder.Services.AddSingleton<RegistrationViewModel>();
		builder.Services.AddSingleton<RegistrationPage>();

		builder.Services.AddSingleton<FlyoutHeaderViewModel>();
		builder.Services.AddSingleton<FlyoutHeader>();

		builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
		builder.Services.AddScoped<IRegistrationService, RegistrationService>();
		builder.Services.AddScoped<IUserService, UserService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
