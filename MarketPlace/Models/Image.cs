namespace MarketPlace.Models
{
    public class Image
    {
        public int IdImage{ get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
        public string ImageCode { get; set; }
        public string Bucket { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
