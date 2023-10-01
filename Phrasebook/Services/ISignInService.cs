using Phrasebook.Models;

namespace Phrasebook.Services;

public interface ISignInService
{
    Task<User> SignInAsync(string username, string password);
}
