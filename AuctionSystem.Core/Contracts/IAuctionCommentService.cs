using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.AuctionComment;
using AuctionSystem.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Contracts
{
    public interface IAuctionCommentService
    {
        //Task<IEnumerable<AuctionNameViewModel>> GetAuctionNamesAsync();

        Task<bool> AuctionExistAsync(int id);

        Task AddAsync(AuctionCommentFormViewModel model,string userId);

        Task<bool> ExistAsync(int id);

        Task<DeleteCommentViewModel> GetCommentForDeleteAsync(int id);

        Task<IEnumerable<AllCommentsViewModel>> AllCommentsAsync();

        Task<IEnumerable<AllCommentsViewModel>> AllCommentsForAuctionAsync(int id);

        Task<IEnumerable<AllCommentsViewModel>> GetAllAuctionCommentsFromUser(string id);

        Task RemoveAsync(int id);

        Task<bool> UserExistAsync(string id);
    }
}
