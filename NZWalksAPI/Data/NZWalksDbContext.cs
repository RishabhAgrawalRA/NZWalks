using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>(){
                new Difficulty
                {
                    ID = Guid.Parse("a1e89c74-726c-4ba8-b3d5-b96824f3c0fa"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    ID = Guid.NewGuid(),
                    Name = "Mediun"
                },
                new Difficulty
                {
                    ID = Guid.NewGuid(),
                    Name = "Difficult"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region {
                    ID = Guid.NewGuid(),
                    Code = "PNQ",
                    Name = "Pune",
                    RegionaImageUrl = "Pune-image"
                },
                new Region {
                    ID = Guid.NewGuid(),
                    Code = "BLR",
                    Name = "Banglore",
                    RegionaImageUrl = "Banglore-image"
                },
                new Region {
                    ID = Guid.NewGuid(),
                    Code = "DLH",
                    Name = "Delhi",
                    RegionaImageUrl = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
