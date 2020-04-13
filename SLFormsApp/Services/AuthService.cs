using System.Threading.Tasks;
using Plugin.Settings;
using SLFormsApp.Interfaces;
using SLFormsApp.Models;

namespace SLFormsApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly Database _database;

        public AuthService(Database database)
        {
            _database = database;
        }

        public async Task<(bool IsSuccess, ResponseError[] Errors)> LoginAsync(string login, string password)
        {
            await Task.Delay(1000).ConfigureAwait(false);

            var user = await _database.GetUserAsync(login).ConfigureAwait(false);

            if (user == null)
            {
                return (false, new[] { new ResponseError("login", "Invalid login") });
            }

            if (password != user.Password)
            {
                return (false, new[] { new ResponseError("password", "Invalid password") });
            }

            CrossSettings.Current.AddOrUpdateValue(Defines.CurrentUserKey, user.Login);

            return (true, null);
        }

        public async Task<(bool IsSuccess, ResponseError[] Errors)> RegisterAsync(string login, string password)
        {
            await Task.Delay(1000)
                .ConfigureAwait(false);

            var isUserExists = await _database.GetUserAsync(login).ConfigureAwait(false) != null;

            if (isUserExists)
            {
                return (false, new[] { new ResponseError("login", "User already exists") });
            }

            var result = await _database.CreateUserAsync(new User { Login = login, Password = password })
                .ConfigureAwait(false);

            if (result)
            {
                CrossSettings.Current.AddOrUpdateValue(Defines.CurrentUserKey, login);
            }

            return (result, null);
        }

        public async Task LogoutAsync()
        {
            await Task.Delay(1000)
                .ConfigureAwait(false);

            CrossSettings.Current.Remove(Defines.CurrentUserKey);
        }
    }
}
