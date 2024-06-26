namespace AuctionSystem.Core.Models.User
{
    public class MyUserCommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string ReceivingCommentUserName { get; set; } = string.Empty;
    }
}
