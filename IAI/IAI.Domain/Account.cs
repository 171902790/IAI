using System;
using IAI.Exceptions;

namespace IAI.DomainModel
{
    public class Account:IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void Login(string password)
        {
            if (password != Password)
                throw new PasswordErrorException();
        }

        public static void Register(string username,string password,string repeatPassword)
        {
            
        }
    }
}