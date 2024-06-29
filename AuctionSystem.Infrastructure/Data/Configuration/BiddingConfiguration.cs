using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class BiddingConfiguration : IEntityTypeConfiguration<Bidding>
    {
        public void Configure(EntityTypeBuilder<Bidding> builder)
        {
            builder.HasData(SeedBidding());
        }

        private List<Bidding> SeedBidding()
        {
            List<Bidding> biddings = new List<Bidding>();
            Bidding bidding;

            var fixedDate = new DateTime(2024, 5, 29);

            bidding = new Bidding()
            {
                Id = 1,
                Price = 20000,
                DateAndTimeOfBidding = fixedDate,
                BuyerId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8",
                AuctionId = 1
            };
            biddings.Add(bidding);

            return biddings;
        }
    }
}
