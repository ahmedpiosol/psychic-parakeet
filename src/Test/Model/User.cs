using System;
using System.Collections.Generic;

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

        //public virtual ICollection<Items.Item> Items { get; set; } = new List<Items.Item>();
    }

    public enum UserGroup
    {
        Administrator = 1,
        User,
        Unknown
    }
}