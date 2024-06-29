namespace AuctionSystem.Core.Models.UserComment
{
    public class AllUserCommentForOtherUsers
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string ReceivingCommentUserName { get; set; } = string.Empty;
    }
}
