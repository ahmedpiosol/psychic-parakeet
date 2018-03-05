namespace TestApp.Model.Items
{
    public class Item : NormalBaseModel
    {
        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public int? ManualId { get; set; }

        public string Barcode { get; set; }

        public byte?[] Image { get; set; }

        public virtual Unit Unit { get; set; }

        public string MadeIn { get; set; }

        public bool IsSerail { get; set; }

        public bool IsExpire{ get; set; }

    }
}