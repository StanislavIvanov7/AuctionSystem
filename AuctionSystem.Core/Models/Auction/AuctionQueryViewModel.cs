using AuctionSystem.Core.Enumeration;
using System.ComponentModel.DataAnnotations;
namespace AuctionSystem.Core.Models.Auction
{
    public class AuctionQueryViewModel
    {
        public int AuctionPerPage { get; } = 3;
        public string Condition { get; set; } = null!;
        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;
        public AuctionSorting Sorting { get; set; }
        public int CurrentPage { get; init; } = 1;
        public int TotalAuctionCount { get; set; }
        public IEnumerable<string> Conditions { get; set; } = null!;
        public IEnumerable<AllAuctionViewModel> Auction { get; set; } = new List<AllAuctionViewModel>();
    }
}
