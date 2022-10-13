using Microsoft.AspNetCore.Mvc;

namespace FoodieOnline.Interface
{
    public interface IAccountRepository
    {
        Task<LoginResponse> Login(LoginModel model);
        Task<LoginResponse> Register(RegisterModel model);
    }
}
