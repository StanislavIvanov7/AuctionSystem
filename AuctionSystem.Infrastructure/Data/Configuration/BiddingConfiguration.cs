using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
                BuyerId = "39fb9235-83a6-4bb9-9236-490a99f6bb83",
                AuctionId = 1
            };

            biddings.Add(bidding);

            return biddings;
        }
    }
}
