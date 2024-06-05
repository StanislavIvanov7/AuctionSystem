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

            public const string MaxLengthPrice = "100000000";
            public const string MinLengthPrice = "0";

            public const int MaxLengthMinBiddingStep = 100000;
            public const int MinLengthMinBiddingStep = 1;

            public const int MaxLengthBiddingPeriodInDays = 50;
            public const int MinLengthBiddingPeriodInDays = 1;



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

        public static class AuctionComment
        {
            public const int MaxLengthContent = 600;
            public const int MinLengthContent = 3;

        }

        public static class UserComment
        {
            public const int MaxLengthContent = 600;
            public const int MinLengthContent = 3;

        }

        public static class Bidding
        {
            public const string MaxLengthLastPrice = "100000000";
            public const string MinLengthLastPrice = "0";
        }

        public static class ApplicationUser
        {
            public const int MaxLengthPassword = 100;
            public const int MinLengthPassword = 6;

            public const int MaxLengthFirstName = 50;
            public const int MinLengthFirstName = 1;

            public const int MaxLengthLastName = 50;
            public const int MinLengthLastName = 3;

            public const int MaxLengthUserRole = 50;
            public const int MinLengthUserRole = 3;

            public const int MaxLengthPhoneNumber = 10;
            public const int MinLengthPhoneNumber = 10;

        }
    }
}
