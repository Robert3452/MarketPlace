using MarketPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartDetail> ShoppingCartDetail { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>((el) =>
            {
                el.ToTable("Product");
                el.HasKey(e => e.IdProduct);
                el.Property(e => e.Name).IsRequired().HasMaxLength(30);
                el.Property(e => e.Description).HasMaxLength(400);
                el.HasMany(e => e.Images).WithOne(el => el.Product).HasForeignKey(el => el.IdImage);
                el.Property(e => e.Price).IsRequired().HasDefaultValue(0);
                el.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.IdCategory);


            });

            modelBuilder.Entity<Profile>(el =>
            {
                el.ToTable("Profile");
                el.HasKey(e => e.IdProfile);
                el.Property(e => e.IdentityType).IsRequired();
                el.Property(e => e.Names).IsRequired().HasMaxLength(140);
                el.Property(e => e.IdentityNumber).IsRequired().HasMaxLength(10);
                el.Property(e => e.LastNames).IsRequired().HasMaxLength(140);
              //  el.HasOne(p => p.User).WithOne(p => p.Profile).HasForeignKey<Profile>(e => e.IdUser);



            });

            modelBuilder.Entity<User>(el =>
            {
                el.ToTable("User");
                el.HasKey(e => e.IdUser);
                el.Property(e => e.Password).IsRequired();
                el.Property(e => e.UserName).IsRequired().HasMaxLength(100);
                el.Property(e => e.Email).IsRequired();
                el.HasOne(p => p.Profile).WithOne(p=>p.User).HasForeignKey<User>(e => e.IdProfile);


            });

            modelBuilder.Entity<Category>(el =>
            {
                el.ToTable("Category");
                el.HasKey(e => e.IdCategory);
                el.Property(e => e.Name).IsRequired().HasMaxLength(100);
                el.Property(e => e.Description).IsRequired();

            });

            modelBuilder.Entity<Image>(el =>
            {
                el.ToTable("Image");
                el.HasKey(e => e.IdImage);
                el.Property(e => e.ImageCode).IsRequired();
                el.Property(e => e.Bucket).IsRequired();
                el.Property(e => e.Uri);
                el.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Sale>(el =>
            {
                el.ToTable("Sale");
                el.HasKey(e => e.IdSale);
                el.Property(e => e.SaleAmount).IsRequired();
                el.Property(e => e.IGV).IsRequired();
                el.HasOne(p => p.ShoppingCart).WithOne(el => el.Sale).HasForeignKey<Sale>(e => e.IdShoppingCart);
            });

            modelBuilder.Entity<ShoppingCart>(el =>
            {
                el.ToTable("ShoppingCart");
                el.HasKey(e => e.IdShoppingCart);
                el.Property(e => e.Total);
                el.HasMany(e => e.ShoppingCartDetails)
                    .WithOne(el => el.ShoppingCart)
                    .HasForeignKey(el => el.IdShoppingCart);


            });

            modelBuilder.Entity<ShoppingCartDetail>(el =>
            {
                el.ToTable("ShoppingCartDetail");
                el.HasKey(e => e.IdShoppingCartDetail);
                el.Property(e => e.Quantity).IsRequired();
                el.HasOne(e => e.ShoppingCart)
                    .WithMany(el => el.ShoppingCartDetails)
                    .HasForeignKey(el => el.IdShoppingCart);
                el.HasOne(e => e.Product).WithMany(el => el.ShoppingCartDetails).HasForeignKey(el => el.IdProduct);
                el.HasOne(e => e.ShoppingCart).WithMany(el => el.ShoppingCartDetails).HasForeignKey(el => el.IdShoppingCart);
            });
        }

    }
}
