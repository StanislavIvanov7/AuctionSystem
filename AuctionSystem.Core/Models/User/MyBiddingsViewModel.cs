using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Models.User
{
    public class MyBiddingsViewModel
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string DateAndTimeOfBidding { get; set; } = string.Empty;

        public string Auction { get; set; } = string.Empty;
    }
}
