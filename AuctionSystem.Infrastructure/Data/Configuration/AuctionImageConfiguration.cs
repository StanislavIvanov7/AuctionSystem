using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionSystem.Infrastructure.Data.Configuration
{
    public class AuctionImageConfiguration : IEntityTypeConfiguration<AuctionImage>
    {
        public void Configure(EntityTypeBuilder<AuctionImage> builder)
        {
            builder.HasData(SeedAuctionImages());
        }

        private List<AuctionImage> SeedAuctionImages()
        {
            List<AuctionImage> images = new List<AuctionImage>();
            AuctionImage image;

            image = new AuctionImage()
            {
                Id = 1,
                ImageUrl = "https://carsguide.ikman.lk/wp-content/uploads/2023/11/C200-scaled.jpg",
                AuctionId = 1,
                IsMain = true,
            };
            images.Add(image);

            image = new AuctionImage()
            {
                Id = 2,
                ImageUrl = "https://res.cloudinary.com/driveau/image/upload/v1616453173/cms/uploads/2018-mercedes-benz-c200-508.jpg",
                AuctionId = 1,
                IsMain = false,
            };
            images.Add(image);

            image = new AuctionImage()
            {
                Id = 3,
                ImageUrl = "https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/15-mercedes-benz-c200-2018-review-static-rear.jpg",
                AuctionId = 1,
                IsMain = false,
            };
            images.Add(image);

            return images;
        }
    }
}
