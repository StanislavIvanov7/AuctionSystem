using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionSystem.Infrastructure.Data.Models;


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
                ReceivingCommentUserId = "39fb9235-83a6-4bb9-9236-490a99f6bb83",
                Content = "The best customer",
                SendingCommentUserId = "9e4d170a-cfb8-4e35-b754-7f9586f48ce4"
            };

            comments.Add(comment);

            return comments;
        }
    }
}
