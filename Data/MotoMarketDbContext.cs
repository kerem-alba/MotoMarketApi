using Microsoft.EntityFrameworkCore;
using MotoMarketApi.Entities;

namespace MotoMarketApi.Data
{
    public class MotoMarketDbContext : DbContext
    {
        public MotoMarketDbContext(DbContextOptions<MotoMarketDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<MotorcycleAd> MotorcycleAds => Set<MotorcycleAd>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Model> Models => Set<Model>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<FavoriteAd> FavoriteAds => Set<FavoriteAd>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteAd>()
                .HasOne(f => f.MotorcycleAd)
                .WithMany()
                .HasForeignKey(f => f.MotorcycleAdId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FavoriteAd>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
