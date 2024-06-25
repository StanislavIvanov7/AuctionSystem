using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class AuctionCommentConfiguration : IEntityTypeConfiguration<AuctionComment>
    {
        public void Configure(EntityTypeBuilder<AuctionComment> builder)
        {
            builder.HasData(SeedComments());
        }

        private List<AuctionComment> SeedComments()
        {
            AuctionComment comment;

            List<AuctionComment> comments = new List<AuctionComment>();

            comment = new AuctionComment()
            {
                Id = 6,
                AuctionId = 1,
                Content = "Very good car",
                UserId = "cd87d0e2-4047-473e-924a-3e10406c5583"
            };

            comments.Add(comment);

            return comments;
        }
    }
}
