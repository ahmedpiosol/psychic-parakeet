namespace TestApp.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using TestApp.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            /*IList<User> defaultUsers = new List<User>();

            defaultUsers.Add(new User() { Name = "admin", Password = "admin", Group = UserGroup.Administrator, IsActive = true });

            foreach (User u in defaultUsers)
                context.Users.AddOrUpdate(u);

            base.Seed(context);*/
        }
    }
}
