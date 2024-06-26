namespace AuctionSystem.Core.Models.UserComment
{
    public class AllCommentAboutUserFromOtherUsers
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string SendingCommentUserName { get; set; } = string.Empty;
    }
}
