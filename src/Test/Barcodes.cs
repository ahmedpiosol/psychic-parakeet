namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Barcodes
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Value { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime CreatedIn { get; set; }

        public Guid? EditedById { get; set; }

        public DateTime? EditedIn { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
