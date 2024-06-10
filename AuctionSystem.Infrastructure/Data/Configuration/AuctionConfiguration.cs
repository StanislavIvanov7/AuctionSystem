using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasData(SeedAuction());
        }

        private List<Auction> SeedAuction()
        {
            List<Auction> auctions = new List<Auction>();

            Auction auction;
            var fixedDate = new DateTime(2024, 5, 24);

            auction = new Auction()
            {
                Id = 1,
                Name = "Car auction",
                Description = "Mercedes C200 2018 car for sale with a starting price of 12,000lv and a minimum bid of BGN 100.On actual kilometers without any remarks.",
                InitialPrice = 12000,
                MinBiddingStep = 100,
                BiddingPeriodInDays = 5,
                ConditionId = 5,
                SellerId = "39fb9235-83a6-4bb9-9236-490a99f6bb83",
                LastPrice = 20000,
                LastBuyerId = "7930926e-9ca6-4c83-8921-bb432b90c8f6",
                BiddingCount = 1,
                StartingAuctionDateTime = fixedDate,
            };

            auctions.Add(auction);
           
            return auctions;

        }
    }
}
