using BlazorModel;
using System.Threading.Tasks;

namespace BlazorBasic.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }
}
