using Database.Constants;
using Database.Entities;
using Database.Enums;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System.Globalization;

namespace Database;

/// <summary>
/// Контекст базы данных.
/// </summary>
public sealed class Context : IdentityDbContext<IdentityUser>
{
	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="options">Настройки для создания <see cref="Context"/>.</param>
	public Context(DbContextOptions options) : base(options)
	{
	}

	/// <summary>
	/// Таблица с категориями.
	/// </summary>
	public DbSet<Category> Categories { get; set; }

	/// <summary>
	/// Таблица с языками для изучения.
	/// </summary>
	public DbSet<Language> Languages { get; set; }

	/// <summary>
	/// Таблица с голосами.
	/// </summary>
	public DbSet<Voice> Voices { get; set; }

	/// <summary>
	/// Таблица с фразами.
	/// </summary>
	public DbSet<Phrase> Phrases { get; set; }

	/// <summary>
	/// Таблица с переводами.
	/// </summary>
	public DbSet<Translation> Translations { get; set; }

	/// <summary>
	/// Таблица с аудиофайлами.
	/// </summary>
	public DbSet<Audio> Audios { get; set; }

	/// <summary>
	/// Таблица с настройками.
	/// </summary>
	public DbSet<Setting> Settings { get; set; }

	/// <summary>
	/// Таблица с флагами, которые пользователь может применить к переводу.
	/// </summary>
	public DbSet<UserTranslation> UserTranslations { get; set; }

	/// <summary>
	/// Заполняет таблицы стандартными значениями.
	/// </summary>
	/// <param name="builder"><see cref="ModelBuilder"/>.</param>
	protected override void OnModelCreating(ModelBuilder builder)
	{
		ArgumentNullException.ThrowIfNull(builder, nameof(builder));

		base.OnModelCreating(builder);

		var russianLanguage = new Language()
		{
			Id = 1,
			Name = "Русский",
			Enabled = true
		};

		var serbianLanguage = new Language()
		{
			Id = 2,
			Name = "Сербский",
			Enabled = true
		};

		var category = new Category
		{
			Id = 1,
			Name = "Общие",
			Enabled = true
		};

		var phrase = new Phrase
		{
			Id = 1,
			CategoryId = category.Id,
			Text = "Привет",
			Enabled = true
		};

		var russianVoice = new Voice
		{
			Id = 1,
			LanguageId = russianLanguage.Id,
			Name = "Борислав",
			Gender = Gender.Male
		};

		var serbianVoice = new Voice
		{
			Id = 2,
			LanguageId = serbianLanguage.Id,
			Name = "Nicholas",
			Gender = Gender.Male
		};

		var russianTranslation = new Translation
		{
			Id = 1,
			PhraseId = phrase.Id,
			LanguageId = russianLanguage.Id,
			Text = "Привет"
		};

		var serbianTranslation = new Translation
		{
			Id = 2,
			PhraseId = phrase.Id,
			LanguageId = serbianLanguage.Id,
			Text = "Здраво"
		};

		var russianAudio = new Audio
		{
			Id = russianTranslation.Id,
			VoiceId = russianVoice.Id,
		};

		var serbianAudio = new Audio
		{
			Id = serbianTranslation.Id,
			VoiceId = serbianVoice.Id,
		};

		var setting = new Setting
		{
			Key = SettingKey.OriginalLanguageId,
			Value = russianLanguage.Id.ToString(CultureInfo.InvariantCulture)
		};

		builder.Entity<Language>().HasData(russianLanguage, serbianLanguage);
		builder.Entity<Category>().HasData(category);
		builder.Entity<Phrase>().HasData(phrase);
		builder.Entity<Voice>().HasData(russianVoice, serbianVoice);
		builder.Entity<Translation>().HasData(russianTranslation, serbianTranslation);
		builder.Entity<Audio>().HasData(russianAudio, serbianAudio);
		builder.Entity<Setting>().HasData(setting);
	}
}
