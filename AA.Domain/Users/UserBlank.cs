using System;

namespace AA.Domain.Users
{
    public class UserBlank
    {
        public Guid? Id { get; set; }
        public String? Email { get; set; }
        public String? Password { get; set; }
        public String? RePassword { get; set; }

        public UserBlank() { }

        public UserBlank(Guid? id, String? email, String? password, String? rePassword)
        {
            Id = id;
            Email = email;
            Password = password;
            RePassword = rePassword;
        }
    }
}
