namespace MarketPlace.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public int IdProfile { get; set; }
    }
}
