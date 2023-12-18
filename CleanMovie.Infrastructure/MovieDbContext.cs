using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> opts) :base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasOne(c => c.Rental).WithMany(c => c.Members).HasForeignKey(c=>c.RentalId);
            modelBuilder.Entity<Rental>().HasMany(c => c.Members).WithOne(c=>c.Rental).HasForeignKey(c=>c.MemberId);
            modelBuilder.Entity<MovieRental>().HasKey(g => new { g.MovieId, g.RentalId });
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Member> Members { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<MovieRental>MovieRentals { get; set; }
    }
}
