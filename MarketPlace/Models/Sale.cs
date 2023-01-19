namespace MarketPlace.Models
{
    public class Sale
    {
        public int IdSale { get; set; }
        public double SaleAmount { get; set; }
        public double IGV { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public int IdShoppingCart { get; set; }
    }
}
