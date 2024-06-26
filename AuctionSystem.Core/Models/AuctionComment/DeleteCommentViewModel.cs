namespace AuctionSystem.Core.Models.AuctionComment
{
    public class DeleteCommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string AuctionName { get; set; } = string.Empty;
    }
}
