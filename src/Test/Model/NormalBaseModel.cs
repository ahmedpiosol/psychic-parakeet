using System;

namespace TestApp.Model
{
    /// <summary>
    /// Uses Normal Intgers as IDs for tables that won't Sync with the server
    /// </summary>
    public class NormalBaseModel : CommonBase
    {
        public NormalBaseModel()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string Notes { get; set; }

        public Guid CreatedById { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public Guid? EditedById { get; set; }

        public DateTimeOffset? EditDate { get; set; }

        public virtual User Creators { get; set; }

        public virtual User Editors { get; set; }
    }
}
