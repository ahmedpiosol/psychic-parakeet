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
            Id = new Guid();
            CreateDate = DateTime.Now;
            EditDate = null;
        }

        public Guid Id { get; set; }

        public string Notes { get; set; }

        public virtual User CreateBy { get; set; }

        public DateTimeOffset? CreateDate { get; set; }

        public virtual User EditBy { get; set; }

        public DateTimeOffset? EditDate { get; set; }
    }
}
