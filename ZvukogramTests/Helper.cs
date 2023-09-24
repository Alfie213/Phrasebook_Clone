using Microsoft.Extensions.Configuration;

namespace ZvukogramTests;

internal static class Helper
{
    public static IConfiguration CreateConfiguration(IEnumerable<KeyValuePair<string, string?>> initialData)
    {
        return new ConfigurationBuilder()
            .AddInMemoryCollection(initialData)
            .Build();
    }
}
