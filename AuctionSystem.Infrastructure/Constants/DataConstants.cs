using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class Auction
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;

            public const int MaxLengthDescription = 500;
            public const int MinLengthDescription = 10;

        }

        public static class AuctionCondition
        {
            public const int MaxLengthName = 100;
            public const int MinLengthName = 3;

        }

        public static class AuctionImage
        {
            public const int MaxLengthImageUrl = 2048;
            public const int MinLengthImageUrl = 10;

        }
    }
}
