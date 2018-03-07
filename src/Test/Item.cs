namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameAr { get; set; }

        [StringLength(50)]
        public string NameEn { get; set; }

        public int? ManualId { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public int UnitId { get; set; }

        [StringLength(50)]
        public string MadeIn { get; set; }

        public bool IsSerail { get; set; }

        public bool IsExpire { get; set; }

        public Guid CreatedById { get; set; }

        public DateTime CreatedIn { get; set; }

        public Guid? EditedById { get; set; }

        public DateTime? EditedIn { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
