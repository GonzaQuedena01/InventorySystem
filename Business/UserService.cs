using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Entity;

namespace Business
{
    public class UserService
    {

        private readonly DataBaseConnection _Data;

        public UserService()
        {
            _Data = new DataBaseConnection();
        }

        public string RegisterUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.");
            }

            user.Password = HashPassword(user.Password);

            try
            {
                _Data.RegisterUser(user);
                return "";
            }
            catch(ArgumentException ex)
            {
                return ex.Message;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
