namespace MarketPlace.Models
{
    public class ShoppingCartDetail
    {
        public int IdShoppingCartDetail { get; set; }
        public virtual Product Product { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public int IdShoppingCart { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

    }
}
