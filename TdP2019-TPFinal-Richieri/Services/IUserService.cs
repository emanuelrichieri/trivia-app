using TdP2019TPFinalRichieri.DTO;

namespace TdP2019TPFinalRichieri.Services
{
    public interface IUserService
    {
        ResponseDTO<UserDTO> Login(string pUsername, string pPassword);

        ResponseDTO<object> SignUp(string pUsername, string pPassword, string pConfirmPassword);
    }
}
