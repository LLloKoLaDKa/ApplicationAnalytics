using AA.Domain.Users;
using AA.EntitiesCore.Extensions;
using AA.EntitiesCore.Models.Users;
using AA.EntitiesCore.Models.Users.Converters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AA.EntitiesCore.Repositories.Users
{
    public class UsersRepository : BaseRepository
    {
        public User? GetUserByEmail(String email)
        {
            return UseContext(context =>
            {
                return context.Users.FirstOrDefault(u => u.Email == email)?.ToUser();
            });
        }

        public void Registration(UserBlank blank)
        {
            UseContext(context =>
            {
                UserDb db = blank.ToDb();

                context.Users.Add(db);
                context.Entry(db).State = EntityState.Added;
                context.SaveChanges();
            });
        }

        public User? LogIn(UserBlank blank)
        {
            return UseContext(context =>
            {
                return context.Users.FirstOrDefault(u => u.Email == blank.Email && u.PasswordHash == blank.Password.ToMD5Hash())?.ToUser();
            });
        }
    }
}
