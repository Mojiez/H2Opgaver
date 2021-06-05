﻿namespace SecurePassword.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public User()
        {

        }

        public User(string username, string password) : base ()
        {
            UserName = username;
            Password = password;
        }
    }
}