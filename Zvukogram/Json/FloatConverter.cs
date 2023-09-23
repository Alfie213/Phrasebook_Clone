using Newtonsoft.Json;

using System.Globalization;

namespace Zvukogram.Json;

/// <summary>
/// Конвертирует <see cref="float"/> в JSON без добавления остаточных нулей и с точкой в качестве десятичного разделителя.
/// </summary>
public class FloatConverter : JsonConverter<float>
{
    /// <inheritdoc/>
    public override bool CanRead => false;

    /// <inheritdoc/>
    public override float ReadJson(JsonReader reader, Type objectType, float existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public override void WriteJson(JsonWriter writer, float value, JsonSerializer serializer)
    {
        ArgumentNullException.ThrowIfNull(writer);

        writer.WriteRawValue(value.ToString("G", CultureInfo.InvariantCulture));
    }
}
