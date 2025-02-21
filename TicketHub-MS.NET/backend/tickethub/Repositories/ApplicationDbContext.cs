using System;
using Microsoft.EntityFrameworkCore;

namespace tickethub.Repositories
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }    
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Cast> Casts { get; set; }  
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookedSeat> BookedSeats { get; set; }  
        public DbSet<Payment> Payments { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=localhost;Database=dotnettickethub;User=root;Password=Akshay@6;",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }

        // You can also override SaveChangesAsync for async operations
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentDate = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = currentDate;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedOn = currentDate;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
