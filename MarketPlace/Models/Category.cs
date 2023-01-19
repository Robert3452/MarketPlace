namespace MarketPlace.Models
{
    public class Category
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public int Description { get; set; } 
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Product> Products{ get; set; }
    }
}
