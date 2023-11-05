using Core.Interfaces;
using Core.Models;

using Identity.Services;

using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
	private readonly ICardModelService _service;
	private readonly IAudioUploadService _uploadService;
	private readonly IAudioService _audioService;
	private readonly TokenService _tokenService;

	public CardController(ICardModelService service, IAudioUploadService uploadService, IAudioService audioService, TokenService tokenService)
	{
		_service = service;
		_uploadService = uploadService;
		_audioService = audioService;
		_tokenService = tokenService;
	}

	//[HttpGet]
	//public string Test()
	//{
	//	return "123";
	//}

	[HttpGet]
	public async Task<IEnumerable<CardModel>> GetCardsAsync(int languageId)
	{
		var learnModels = await _service.GetCardModelsAsync(languageId);

		foreach (var learnModel in learnModels)
		{
			await CheckAudioAsync(learnModel.Phrase);
			await CheckAudioAsync(learnModel.Translate);
		}

		return learnModels;
	}

	private async Task CheckAudioAsync(PhraseModel phrase)
	{
		if (phrase is null)
		{
			return;
		}

		// Если ссылка на файл существует
		if (phrase.Audio is not null)
		{
			// Если файл не существует
			if (!await _uploadService.ExistAsync(phrase.Audio))
			{
				// Загружаем файл
				await _uploadService.UploadTranslationAudio(phrase.TranslationId);
			}
		}
		else
		{
			// Если ссылки нет,
			var audioSavePath = await _uploadService.GetAudioSavePath(phrase.TranslationId);

			// Смотрим, есть ли файл в папке
			if (!await _uploadService.ExistAsync(audioSavePath))
			{
				//если нет, то загружаем
				await _uploadService.UploadTranslationAudio(phrase.TranslationId);
			}

			// Обновляем ссылку на файл в БД
			await _audioService.SetAudioAsync(phrase.TranslationId, audioSavePath);
		}
	}
}
