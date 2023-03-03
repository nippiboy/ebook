using ebook_server.DTOs;
using ebook_server.Entitys;

namespace ebook_server.Helper
{
    public class UserConverter
    {
        public UserDTO ConvertUserToUserDTO(User user)
        {
            if (user == null) return null;
            return new UserDTO {UserName = user.UserName, UserEmail = user.UserEmail, CreditAmout = user.CreditAmount };
        }

        public User ConvertUserDTOTOUser(UserDTO userDTO)
        {
            return new User {UserName = userDTO.UserName, UserEmail = userDTO.UserEmail, CreditAmount = userDTO.CreditAmout};
        }

        public User ConvertUserCreationDToTOUser(UserCreationDTO userCreationDTO)
        {
            return new User { UserName = userCreationDTO.userName, UserEmail = userCreationDTO.email, CreditAmount = 0, UserPassword = userCreationDTO.password };
        }

    }
}
