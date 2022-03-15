using System;

namespace AA.Domain.Users
{
    public class User
    {
        public Guid Id { get; }
        public String Email { get; }

        public User(Guid id, String email)
        {
            Id = id;
            Email = email;
        }
    }
}
