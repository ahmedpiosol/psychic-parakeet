using System;

namespace TestApp.Model
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            IsActive = false;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public UserGroup Group { get; set; }

        public bool IsActive { get; set; }
    }

    public enum UserGroup
    {
        Administrator = 1,
        User,
        Unknown
    }
}