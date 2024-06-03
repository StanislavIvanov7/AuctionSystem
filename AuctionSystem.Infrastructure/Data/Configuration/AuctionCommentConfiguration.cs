using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                UserId = "39fb9235-83a6-4bb9-9236-490a99f6bb83"
            };

            comments.Add(comment);

            return comments;
        }
    }
}
