using System;
namespace TdP2019TPFinalRichieri.Services
{
    using AutoMapper;
    using Mapper;
    using DTO;
    using Entities;
    using DAL;
    using System.Text.RegularExpressions;

    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public UserService(IUnitOfWorkFactory pUnitOfWorkFactory,
                            IMapperFactory pMapperFactory)
        {
            this._unitOfWorkFactory = pUnitOfWorkFactory;
            this._mapper = pMapperFactory.GetMapper();
        }

        /// <summary>
        /// Login for the given username and password. 
        /// </summary>
        /// <returns>The authorized user if login is successful.</returns>
        /// <param name="pUsername">Username.</param>
        /// <param name="pPassword">Password.</param>
        public ResponseDTO<UserDTO> Login(string pUsername, string pPassword)
        {
            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                User user = bUoW.UserRepository.Get(pUsername);
                // Non-existing user
                if (user == null)
                {
                    return ResponseDTO<UserDTO>.NotFound($"There is no user associated with the username {pUsername}");
                }
                // Password matches with user's password: successful login
                if (string.Equals(user.Password, pPassword))
                {
                    return ResponseDTO<UserDTO>.Ok(_mapper.Map<UserDTO>(user));
                }
                return ResponseDTO<UserDTO>.Unauthorized("Incorrect password.");
            }
        }


        /// <summary>
        /// Register a new User. 
        /// </summary>
        /// <param name="pUsername">Username.</param>
        /// <param name="pPassword">Password.</param>
        /// <param name="pConfirmPassword">Confirmed password.</param>
        public ResponseDTO<object> SignUp(string pUsername, string pPassword, string pConfirmPassword)
        {
            if (pUsername == null || pUsername.Length < 6)
            {
                return ResponseDTO.BadRequest("Username must contain at least 6 characters.");
            }
            // Regex for username. Must starts with a letter and can only contain 
            // alphanumeric characters or underscore (_)
            // \w in regex means word or underscore
            Regex regex = new Regex("^([a-zA-Z][a-zA-Z0-9])\\w*$");
            if (!regex.IsMatch(pUsername))
            {
                return ResponseDTO.BadRequest("Username must starts with a letter and " +
                    "can only contain alphanumeric characters and underscores.");
            }
            if (pPassword.Length < 6)
            {
                return ResponseDTO.BadRequest("Password must contain at least 6 characters.");
            }
            if (!string.Equals(pPassword, pConfirmPassword))
            {
                return ResponseDTO.BadRequest("Passwords do not match.");
            }
            User user = new User
            {
                Username = pUsername,
                Password = pPassword,
                Rol = UserRol.Operator
            };

            using (IUnitOfWork bUoW = _unitOfWorkFactory.GetUnitOfWork())
            {
                bUoW.UserRepository.Add(user);
                bUoW.Complete();

                return ResponseDTO.Ok("Successfully signed up! ");
            }
        }
    }
}
