namespace AuctionSystem.Core.Models.UserComment
{
    public class DeleteUserCommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string SendingCommentUserName { get; set; } = string.Empty;
    }
}
