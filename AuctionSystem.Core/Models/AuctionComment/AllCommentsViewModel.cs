﻿namespace AuctionSystem.Core.Models.AuctionComment
{
    public class AllCommentsViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public string AuctionName { get; set; } = string.Empty;

        public string AuctionImageUrl { get; set; } = string.Empty;
    }
}
