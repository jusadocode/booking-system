using BookingSystem.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Server.Data
{
    public class BookingContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Booking> Booking { get; set; }

        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BookingDatabase");
        }

    }

}
