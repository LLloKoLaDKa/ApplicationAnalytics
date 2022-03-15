using AA.Domain.Results;
using AA.Domain.Users;
using AA.EntitiesCore.Repositories.Users;
using System;

namespace AA.Services.Users
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;

        public UsersService()
        {
            _usersRepository = new();
        }

        public Result Registration(UserBlank userBlank)
        {
            if (userBlank.Id is null) userBlank.Id = Guid.NewGuid();
            if (userBlank.Email is null) return Result.Fail("Введите почту для регистрации!");
            if (!userBlank.Email.Contains('@')) return Result.Fail("Введёная почта не является корректной!");
            if (userBlank.Password is null) return Result.Fail("Введите пароль для регистрации!");
            if (userBlank.Password != userBlank.RePassword) return Result.Fail("Пароли не совпадают!");

            User? user = _usersRepository.GetUserByEmail(userBlank.Email);
            if (user is not null) return Result.Fail("Пользователь с такой почтой уже существует!");

            _usersRepository.Registration(userBlank);

            return Result.Success(user);
        }

        public Result LogIn(UserBlank userBlank)
        {
            if (userBlank.Email is null) return Result.Fail("Введите почту для входа!");
            if (userBlank.Password is null) return Result.Fail("Введите пароль для входа!");

            User? user = _usersRepository.LogIn(userBlank);
            if (user is null) return Result.Fail("Неверный логин или пароль!");

            return Result.Success(user);
        }
    }
}
