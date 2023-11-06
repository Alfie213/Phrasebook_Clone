using Core.Interfaces;

using Database;
using Database.Services;

using Identity;
using Identity.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Reflection;

using Zvukogram;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddRazorPages();
services.AddLocalization();

builder.Services.AddRazorPages();

var jwtOptions = new JwtOptions(builder.Configuration);
services.AddSingleton(jwtOptions);

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		if (builder.Environment.IsDevelopment())
		{
			options.RequireHttpsMetadata = false;
		}

		options.ClaimsIssuer = jwtOptions.Issuer;
		options.Audience = jwtOptions.Audience;

		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			ValidateLifetime = true,
			IssuerSigningKey = jwtOptions.Key,
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidIssuer = jwtOptions.Issuer,
			ValidAudience = jwtOptions.Audience,
		};
	});

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<Context>(options
	=> options.UseSqlServer(connectionString, options
		=> options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
	options.Password.RequireUppercase = false;
})
	.AddEntityFrameworkStores<Context>();

services.AddSingleton<TokenService>();

// Нужно ли всё это?
services.AddScoped<IUserService, UserService>();
services.AddHttpClient();
services.AddScoped<ICardModelService, CardModelService>();
services.AddScoped<IAudioService, AudioService>();
services.AddScoped<ZvukogramService>();
services.AddScoped<ISettingService, SettingService>();
services.AddScoped<IAudioUploadService, AudioUploadService>();
services.AddSingleton<FileService>();

services.AddAuthorization(options
	=> options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
		.RequireAuthenticatedUser()
		.Build());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();

	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
