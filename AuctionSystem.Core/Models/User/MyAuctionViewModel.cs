using AuctionSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Models.User
{
    public class MyAuctionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal LastPrice { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<AuctionImage> Images { get; set; } = new List<AuctionImage>();

        public int BiddingPeriodInDays { get; set; }

        public int MinBiddingStep { get; set; }

    }
}
