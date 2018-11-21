using Homan.BLL.Models;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services.Abstract
{
    public interface IUserService
    {
        RegistrationResponseType Register(RegistrationRequestModel model);
        Result<LoginResponseModel> Login(LoginRequestModel model);
    }
}