using AuctionSystem.Infrastructure.Data.Configuration;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuctionConditionConfiguration());
            builder.ApplyConfiguration(new AuctionConfiguration());
            builder.ApplyConfiguration(new AuctionImageConfiguration());
            builder.ApplyConfiguration(new BiddingConfiguration());

            base.OnModelCreating(builder);
        }

        

        public DbSet<Auction> Auctions { get; set; } = null!;

        public DbSet<AuctionCondition> AuctionConditions { get; set; } = null!;

        public DbSet<AuctionImage> AuctionImages { get; set; } = null!;

        public DbSet<Bidding> Biddings { get; set; } = null!;
    }
}