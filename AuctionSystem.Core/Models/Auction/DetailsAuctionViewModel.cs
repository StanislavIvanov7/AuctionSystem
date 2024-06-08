using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionSystem.Infrastructure.Data.Models;

namespace AuctionSystem.Core.Models.Auction
{
    public class DetailsAuctionViewModel
    {
        public int Id { get; set; }

        public int ConditionId { get; set; }

        public string SellerId { get; set; } = string.Empty;  

        public string Name { get; set; } = string.Empty;
    
        public string Description { get; set; } = string.Empty;

        public decimal InitialPrice { get; set; }

        public int MinBiddingStep { get; set; }

        public int BiddingPeriodInDays { get; set; }

        public string Condition { get; set; } = null!;

        public string Seller { get; set; } = null!;

        public string StartingAuctionDateTime { get; set; } = null!;

        public decimal LastPrice { get; set; }

        public int BiddingCount { get; set; }

        public string? LastBuyer { get; set; }

        public List<AuctionImage> Images { get; set; } = new List<AuctionImage>();
    }
}
