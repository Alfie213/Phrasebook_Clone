using Phrasebook.Models;

namespace Phrasebook.Services;

internal sealed class SignInService : ISignInService
{
    public async Task<User> SignInAsync(string username, string password)
    {
        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            using var client = new HttpClient()
            {
                BaseAddress = new Uri("https://phrasebook.space/")
            };

            // TODO: Получение пользователя

            return new User
            {
                Id = 1,
                Username = "Логин",
                Password = "Пароль"
            };
        }

        return null;
    }
}
