using AuctionSystem.Infrastructure.Data.Configuration;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace AuctionSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new AuctionConditionConfiguration());
            builder.ApplyConfiguration(new AuctionConfiguration());
            builder.ApplyConfiguration(new AuctionImageConfiguration());
            builder.ApplyConfiguration(new BiddingConfiguration());
            builder.ApplyConfiguration(new AuctionCommentConfiguration());
            builder.ApplyConfiguration(new UserCommentConfiguration());
            base.OnModelCreating(builder);
        }
        public DbSet<Auction> Auctions { get; set; } = null!;
        public DbSet<AuctionCondition> AuctionConditions { get; set; } = null!;
        public DbSet<AuctionImage> AuctionImages { get; set; } = null!;
        public DbSet<AuctionComment> AuctionComments { get; set; } = null!;
        public DbSet<UserComment> UserComments { get; set; } = null!;
        public DbSet<Bidding> Biddings { get; set; } = null!;
    }
}