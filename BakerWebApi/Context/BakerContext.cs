using BakerWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakerWebApi.Context
{
    public class BakerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NK4JT39\\SQLEXPRESS;Initial Catalog=DbBakerAkademiq;Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AddressInfo> AddressInfos { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}