using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class AuctionConditionConfiguration : IEntityTypeConfiguration<AuctionCondition>
    {
        public void Configure(EntityTypeBuilder<AuctionCondition> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<AuctionCondition> SeedCategories()
        {
            List<AuctionCondition> conditions = new List<AuctionCondition>();

            AuctionCondition condition;

            condition = new AuctionCondition()
            {
                Id = 1,
                Name = "Unregistered"
            };
            conditions.Add(condition);

            condition = new AuctionCondition()
            {
                Id = 2,
                Name = "Awaiting approval"
            };
            conditions.Add(condition);

            condition = new AuctionCondition()
            {
                Id = 3,
                Name = "Refused"
            };
            conditions.Add(condition);

            condition = new AuctionCondition()
            {
                Id = 4,
                Name = "Active"
            };
            conditions.Add(condition);

            condition = new AuctionCondition()
            {
                Id = 5,
                Name = "Finished"
            };
            conditions.Add(condition);

            condition = new AuctionCondition()
            {
                Id = 6,
                Name = "Terminated"
            };
            conditions.Add(condition);

            return conditions;
        }
    }
}
