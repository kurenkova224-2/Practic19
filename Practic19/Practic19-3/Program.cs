using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_3
{
    internal class Program
    {
        public class LoginAlreadyExistsException : Exception
        {
            public LoginAlreadyExistsException(string login)
            : base($"Логин {login} уже занят!")
            {
            }
        }

        public class WeakPasswordException : Exception
        {
            public WeakPasswordException()
            : base("Слабый пароль! Минимум 6 символов.")
            {
            }
        }

        public class UserService
        {
            private HashSet<string> _existingLogins;

            public UserService()
            {
                _existingLogins = new HashSet<string>();
            }

            public void Register(string login, string password)
            {
                Console.WriteLine($"Регистрация: {login}, {password}");

                if (password.Length < 6)
                {
                    throw new WeakPasswordException();
                }

                if (_existingLogins.Contains(login))
                {
                    throw new LoginAlreadyExistsException(login);
                }

                _existingLogins.Add(login);
                Console.WriteLine("Регистрация успешна!");
            }
        }
        static void Main(string[] args)
        {
            UserService userService = new UserService();

            try
            {
                userService.Register("admin", "123"); // Слабый пароль
            }
            catch (WeakPasswordException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            try
            {
                userService.Register("user1", "secret123"); // Успешная регистрация
                userService.Register("user1", "password"); // Логин занят
            }
            catch (LoginAlreadyExistsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
