namespace AuctionSystem.Core.Models.UserComment
{
    public class AllUserCommentsViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public string SendingCommentUserName { get; set; } = string.Empty;

        public string ReceivingCommentUserName { get; set; } = string.Empty;
    }
}
