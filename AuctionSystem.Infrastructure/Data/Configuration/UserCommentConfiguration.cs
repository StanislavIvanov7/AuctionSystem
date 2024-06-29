using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSystem.Infrastructure.Data.Configuration
{
    internal class UserCommentConfiguration: IEntityTypeConfiguration<UserComment>
    {
        public void Configure(EntityTypeBuilder<UserComment> builder)
        {
            builder.HasData(SeedComments());
        }

        private List<UserComment> SeedComments()
        {
            UserComment comment;
            List<UserComment> comments = new List<UserComment>();

            comment = new UserComment()
            {
                Id = 1,
                ReceivingCommentUserId = "cd87d0e2-4047-473e-924a-3e10406c5583",
                Content = "The best customer",
                SendingCommentUserId = "70280028-a1a0-4b5e-89d8-b4e65cbae8d8"
            };
            comments.Add(comment);

            return comments;
        }
    }
}
