using Core.DTO;

using Zvukogram;
using Zvukogram.Request;

namespace Identity.Extensions;

public static class ZvukogramServiceExtensions
{
	public static async Task<Uri?> GetAudioAsync(this ZvukogramService service, SpeechSetting speechSetting)
	{
		ArgumentNullException.ThrowIfNull(service, nameof(service));

		var parameters = new Parameters(speechSetting.Text, speechSetting.Voice);
		return await service.GetAudioAsync(parameters);
	}
}
