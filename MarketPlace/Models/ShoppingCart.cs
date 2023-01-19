using MarketPlace.Models;

namespace MarketPlace
{
    public class ShoppingCart
    {
        public int IdShoppingCart { get; set; }
        public double Total { get; set; }
        public virtual User User { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails {get;set;}
    }
}
