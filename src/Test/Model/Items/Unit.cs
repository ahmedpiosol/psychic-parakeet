using System.Collections.Generic;

namespace TestApp.Model.Items
{
    public class Unit : NormalBaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
