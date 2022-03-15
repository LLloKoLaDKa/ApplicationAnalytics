using AA.Domain.Users;
using AA.EntitiesCore.Extensions;
using System;

namespace AA.EntitiesCore.Models.Converters
{
    internal static class UsersConverters
    {
        internal static User ToUser(this UserDb db)
        {
            return new User(db.Id, db.Email);
        }

        internal static UserDb ToDb(this UserBlank blank)
        {
            return new UserDb(blank.Id.Value, blank.Email, blank.Password.ToMD5Hash(), DateTime.Now);
        }
    }
}
