using System.Threading.Tasks;
using SLFormsApp.Models;

namespace SLFormsApp.Interfaces
{
    public interface IAuthService
    {
        Task<(bool IsSuccess, ResponseError[] Errors)> LoginAsync(string login, string password);

        Task<(bool IsSuccess, ResponseError[] Errors)> RegisterAsync(string login, string password);

        Task LogoutAsync();
    }
}
