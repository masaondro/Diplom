using System.Threading.Tasks;
using VKR.Contracts.User;

namespace VKR.AppServices.Services
{
    public interface IUserService
    {
        Task<LoginResponceDto> Login(LoginDto dto);

        Task Register(RegisterUserDto dto);

        Task ConfirmEmail(ConfirmEmailDto dto);

        Task CreateModerator(CreateModeratorDto dto);

    }
}