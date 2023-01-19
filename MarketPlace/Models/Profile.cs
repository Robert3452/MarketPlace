namespace MarketPlace.Models
{
    public class Profile
    {
        public int IdProfile { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string IdentityNumber { get; set; }
        public IdentityType IdentityType { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User User { get; set; }
        public int IdUser { get; set; }
    }

    public enum IdentityType
    {
        DNI,
        CE,
    }
}
