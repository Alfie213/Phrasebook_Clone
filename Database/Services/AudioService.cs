using Core.DTO;
using Core.Interfaces;

using Database.Entities;

namespace Database.Services;

/// <inheritdoc cref="IAudioService"/>
public sealed class AudioService : IAudioService
{
	private readonly Context _context;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="context">Контекст базы данных.</param>
	public AudioService(Context context)
	{
		_context = context;
	}

	private DbSet<Audio> Audios => _context.Audios;

	/// <inheritdoc/>
	public async Task<Uri?> GetAudioAsync(int translationId)
	{
		return await Audios.AsNoTracking()
			.Include(audio => audio.Translation)
			.Where(audio => audio.Translation!.Id == translationId)
			.Select(audio => audio.Source)
			.SingleOrDefaultAsync();
	}

	/// <inheritdoc/>
	public async Task SetAudioAsync(int translationId, Uri audio)
	{
		var entity = await Audios
			.Include(audio => audio.Translation)
			.SingleOrDefaultAsync(audio => audio.Translation!.Id == translationId);

		if (entity is not null)
		{
			entity.Source = audio;
			await _context.SaveChangesAsync();
		}
	}

	/// <inheritdoc/>
	public async Task<SpeechSetting> GetSpeechSettingAsync(int id)
	{
		return await Audios.AsNoTracking()
			.Include(audio => audio.Translation)
			.Include(audio => audio.Voice)
			.Where(audio => audio.Translation!.Id == id)
			.Select(audio => new SpeechSetting(audio.Translation!.Text, audio.Voice!.Name))
			.SingleOrDefaultAsync();
	}

	/// <inheritdoc/>
	public async Task<AudioPath> GetAudioPathAsync(int id)
	{
		var result = await Audios
			.ToArrayAsync();

		//var result = await Audios.AsNoTracking()
		//	.Include(audio => audio.Translation)
		//	.ThenInclude(translation => translation!.Language)
		//	.Include(audio => audio.Voice)
		//	.Where(audio => audio.Translation!.Id == id).ToArrayAsync();

		Console.WriteLine(result);
		//var s = result.Select(audio => new AudioPath(
		//		audio.Translation!.Language!.Name,
		//		audio.Voice!.Name,
		//		audio.Translation.Text))
		//	.SingleOrDefaultAsync();

		return new AudioPath();
	}
}
