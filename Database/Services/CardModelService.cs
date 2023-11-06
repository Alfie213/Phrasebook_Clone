using Core.Interfaces;
using Core.Models;

using Database.Entities;

namespace Database.Services;

/// <inheritdoc cref="ICardModelService"/>
public sealed class CardModelService : ICardModelService
{
	private readonly DbSet<Translation> _translations;
	private readonly ISettingService _setting;

	/// <summary>
	/// Создаёт экземпляр класса.
	/// </summary>
	/// <param name="context">Контекст базы данных.</param>
	/// <param name="setting">Сервис для работы с настройками.</param>
	public CardModelService(Context context, ISettingService setting)
	{
		ArgumentNullException.ThrowIfNull(context);

		_translations = context.Translations;
		_setting = setting;
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<CardModel>> GetCardModelsAsync(int languageId)
	{
		var originalLanguageId = await _setting.GetOriginalLanguageId();

		// Все доступные модели
		var availableLearnModels = _translations.AsNoTracking();
		//.Include(translation => translation.Phrase)
		//.Include(translation => translation.Audio);

		// Условие для проверки у конкретного пользователя.
		//.Where(translation => !translation.Learned && !translation.Hidden);

		var phrase = GetPhraseModel(languageId, availableLearnModels);
		var original = GetPhraseModel(originalLanguageId, availableLearnModels);

		var learnModels = phrase.Zip(original, (first, second) => new CardModel
		{
			Phrase = new PhraseModel
			{
				TranslationId = first.TranslationId,
				Text = first.Text,
				Audio = first.Audio
			},

			Translate = new PhraseModel
			{
				TranslationId = second.TranslationId,
				Text = second.Text,
				Audio = second.Audio
			}
		}).AsEnumerable();

		return learnModels;
	}

	private static IEnumerable<PhraseModel> GetPhraseModel(int languageId, IQueryable<Translation> availableLearnModels)
	{
		return availableLearnModels.Where(translation => translation.LanguageId == languageId)
					.Select(translation => new PhraseModel
					{
						TranslationId = translation.Id,
						Text = translation.Text,
						Audio = translation.Audio!.Source
					}).AsEnumerable();
	}
}
