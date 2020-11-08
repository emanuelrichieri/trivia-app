using System;
namespace TdP2019TPFinalRichieri.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRol Rol { get; set; }

    }


    public enum UserRol
    {
        Administrator,
        Operator
    }
}
