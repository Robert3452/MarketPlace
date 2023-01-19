namespace MarketPlace.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Image> Images { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }
    }
}
