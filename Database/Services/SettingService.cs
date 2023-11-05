using Core.Interfaces;

using Database.Constants;
using Database.Entities;

using System.Globalization;

namespace Database.Services;

/// <inheritdoc cref="ISettingService"/>
public sealed class SettingService : ISettingService
{
	private readonly Context _context;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="context">Контекст базы данных.</param>
	public SettingService(Context context)
	{
		_context = context;
	}

	/// <inheritdoc/>
	public async Task<int> GetOriginalLanguageId()
	{
		var value = await _context.Settings.AsNoTracking()
			.Where(setting => setting.Key == SettingKey.OriginalLanguageId)
			.Select(setting => setting.Value)
			.SingleAsync();

		return int.Parse(value, CultureInfo.InvariantCulture);
	}

	/// <inheritdoc/>
	public async Task SetOriginalLanguageId(int id)
	{
		var setting = await _context.Settings
			.SingleOrDefaultAsync(setting => setting.Key == SettingKey.OriginalLanguageId);

		var value = id.ToString(CultureInfo.InvariantCulture);

		if (setting is not null)
		{
			setting.Value = value;
			await _context.SaveChangesAsync();
		}
		else
		{
			await CreateSettingAsync(SettingKey.OriginalLanguageId, value);
		}
	}

	private async Task CreateSettingAsync(string key, string value)
	{
		await _context.Settings.AddAsync(new Setting
		{
			Key = key,
			Value = value
		});

		await _context.SaveChangesAsync();
	}
}
