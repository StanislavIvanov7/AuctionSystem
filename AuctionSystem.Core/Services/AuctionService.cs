using AuctionSystem.Core.Contracts;
using AuctionSystem.Core.Enumeration;
using AuctionSystem.Core.Models.Auction;
using AuctionSystem.Core.Models.User;
using AuctionSystem.Infrastructure.Data.Common;
using AuctionSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IRepository repository;

        public AuctionService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(AuctionFormViewModel model, string userId)
        {
            Auction auction = new Auction()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                BiddingPeriodInDays = model.BiddingPeriodInDays,
                ConditionId = model.ConditionId,
                InitialPrice = model.InitialPrice,
                SellerId = userId,
                MinBiddingStep = model.MinBiddingStep,
                LastPrice = model.InitialPrice,
                StartingAuctionDateTime = DateTime.Now
              

            };

            await repository.AddAsync(auction);
            await repository.SaveChangesAsync();
        }

        public async Task AddImagesAsync(Auction auction,string image ,List<string> imageUrls)
        {

            var a = await repository.All<Auction>()
                        .Where(x => x.Id == auction.Id)
                        .Include(x => x.Images)
                        .FirstOrDefaultAsync();
            a.Images.Add(new AuctionImage()
            {
                AuctionId = a.Id,
                ImageUrl = image,
                IsMain = true
            });

            foreach (var imageUrl in imageUrls)
            {
                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    
                    a.Images.Add(new AuctionImage()
                    {
                        AuctionId = a.Id,
                        ImageUrl = imageUrl,
                        IsMain = false
                    });

                    //var auctionImage = new AuctionImage()
                    //{
                    //    AuctionId = auction.Id,
                    //    ImageUrl = imageUrl,
                    //    IsMain = false,
                    //};
                    //auction.Images.Add(auctionImage);
                    //await repository.AddAsync(auctionImage);
                }
            }
            await repository.SaveChangesAsync();
        }

        public async Task<AuctionQueryViewModel> AllAuctionAsync(
            string? condition,
            string? searchTerm,
            AuctionSorting? sorting,
            int currentPage = 1,
            int auctionPerPage = 1)
        {
            var auctionToShow = repository.All<Auction>();

            if (condition != null)
            {
                auctionToShow = auctionToShow.Where(x => x.Condition.Name == condition);

            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                auctionToShow = auctionToShow.Where(x => (x.Name.ToLower().Contains(normalizedSearchTerm) ||
                                                           x.Description.ToLower().Contains(normalizedSearchTerm)));

            }

            auctionToShow = sorting switch
            {
                AuctionSorting.MinPriceAuction => auctionToShow
                    .OrderBy(h => h.LastPrice),
                AuctionSorting.AuctionWithTheMostBids => auctionToShow
                .OrderByDescending(x => x.BiddingCount),
                AuctionSorting.LastActiveAuction => auctionToShow
                    .Where(x => x.Condition.Name == "Active")
                    .OrderByDescending(x => x.Id)
            };

            var auction = await auctionToShow
                .Skip((currentPage - 1) * auctionPerPage)
                .Take(auctionPerPage)
                .Select(x => new AllAuctionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    LastPrice = x.LastPrice,
                    MinBiddingStep = x.MinBiddingStep,
                    BiddingPeriodInDays = x.BiddingPeriodInDays,
                    InitialPrice = x.InitialPrice,
                    Images = x.Images.Where(x=>x.AuctionId == x.Auction.Id).ToList(),


                })
                .ToListAsync();

            int totalAuction = await auctionToShow.CountAsync();

            return new AuctionQueryViewModel()
            {
                Auction = auction,
                TotalAuctionCount = totalAuction
            };
        }

        public async Task<AuctionQueryViewModel> AllAuctionAsync(
            string? searchTerm = null, 
            AuctionSorting sorting = AuctionSorting.LastActiveAuction, 
            int currentPage = 1, 
            int auctionPerPage = 1)
        {
            var auctionToShow = repository.All<Auction>().Where(x=>x.ConditionId == 4);

           

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                auctionToShow = auctionToShow.Where(x => (x.Name.ToLower().Contains(normalizedSearchTerm) ||
                                                           x.Description.ToLower().Contains(normalizedSearchTerm)));

            }

            auctionToShow = sorting switch
            {
                AuctionSorting.MinPriceAuction => auctionToShow
                    .OrderBy(h => h.LastPrice),
                AuctionSorting.AuctionWithTheMostBids => auctionToShow
                .OrderByDescending(x => x.BiddingCount),
                _ => auctionToShow
                    .OrderByDescending(x => x.Id)
            };

            var auction = await auctionToShow
                .Skip((currentPage - 1) * auctionPerPage)
                .Take(auctionPerPage)
                .Select(x => new AllAuctionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    LastPrice = x.LastPrice,
                    MinBiddingStep = x.MinBiddingStep,
                    BiddingPeriodInDays = x.BiddingPeriodInDays,
                    InitialPrice = x.InitialPrice,
                    Images = x.Images.Where(x => x.AuctionId == x.Auction.Id).ToList(),


                })
                .ToListAsync();

            int totalAuction = await auctionToShow.CountAsync();

            return new AuctionQueryViewModel()
            {
                Auction = auction,
                TotalAuctionCount = totalAuction
            };
        }

        public async Task<IEnumerable<string>> AllConditionNamesAsync()
        {
            return await repository.AllAsReadOnly<AuctionCondition>()
                .Select(x=>x.Name)
                .ToListAsync();
        }

        public async Task<bool> ConditionExistAsync(int id)
        {
            return await repository.AllAsReadOnly<AuctionCondition>()
                .AnyAsync(x=>x.Id == id);
        }

        public async Task<DetailsAuctionViewModel> DetailsAuctionAsync(int id)
        {
            var auction = await repository.AllAsReadOnly<Auction>()
              .Where(x => x.Id == id)
              .Select(x => new DetailsAuctionViewModel()
              {
                  Id = x.Id,
                  Name = x.Name,
                  InitialPrice = x.InitialPrice,
                  Description = x.Description,
                  Condition = x.Condition.Name,
                  Seller = x.Seller.Email,
                  LastBuyer = x.LastBuyer.Email,
                  BiddingCount = x.BiddingCount,
                  LastPrice = x.LastPrice,
                  MinBiddingStep = x.MinBiddingStep,
                  BiddingPeriodInDays = x.BiddingPeriodInDays,
                  StartingAuctionDateTime = x.StartingAuctionDateTime.ToString(),
                  
                  



              }).FirstAsync();

            return auction;
        }

        public async Task EditAsync(int id, AuctionFormViewModel model)
        {
            var auction = await repository.GetByIdAsync<Auction>(id);



            if (auction != null)
            {
                auction.Name = model.Name;
                auction.Description = model.Description;
                auction.InitialPrice = model.InitialPrice;
                auction.MinBiddingStep = model.MinBiddingStep;
                auction.BiddingPeriodInDays = model.BiddingPeriodInDays;
                auction.ConditionId = model.ConditionId;

                await repository.SaveChangesAsync();
            }
        }

        //public async Task EditConditionAsync(int id, AuctionFormViewModel model)
        //{
        //    var auction = await repository.GetByIdAsync<Auction>(id);



        //    if (auction != null)
        //    {
                
        //        auction.ConditionId = model.ConditionId;

        //        await repository.SaveChangesAsync();
        //    }
        //}

        public async Task<bool> ExistAsync(int id)
        {
           return await repository.AllAsReadOnly<Auction>()
                .AnyAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<MyAuctionViewModel>> GetAllAuctionsForUser(string userId)
        {
            var auctions = await repository.AllAsReadOnly<Auction>()
                .Where(x => x.SellerId == userId)
                .Select(x => new MyAuctionViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    BiddingPeriodInDays = x.BiddingPeriodInDays,
                    LastPrice = x.LastPrice,
                    MinBiddingStep = x.MinBiddingStep,
                    Images = x.Images
                }).ToListAsync();

            return auctions;
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            var auction = await repository.All<Auction>()
                .FirstAsync(x => x.Id == id);
            return auction;
        }

        public async Task<Auction> GetAuctionByNameAsync(string name)
        {
            var auction= await repository.All<Auction>()
                .FirstAsync(x => x.Name == name);
            return auction;
        }

        public async Task<IEnumerable<AllAuctionConditionsViewModel>> GetAuctionConditionsAsync()
        {
            return await repository.AllAsReadOnly<AuctionCondition>()
                .Select(x => new AllAuctionConditionsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();
        }

        public async Task<AuctionFormViewModel> GetAuctionForEditAsync(int id)
        {
            var auction = await repository.AllAsReadOnly<Auction>()
               .Where(x => x.Id == id)
               .Select(x => new AuctionFormViewModel()
               {
                   Id = id,
                   Name = x.Name,
                   BiddingPeriodInDays= x.BiddingPeriodInDays,
                   InitialPrice = x.InitialPrice,
                   ConditionId = x.ConditionId,
                   Description = x.Description,
                   MinBiddingStep = x.MinBiddingStep,
                   
               }).FirstAsync();

            return auction;
        }

        public async Task<ModeratorAuctionFormViewModel> GetModeratorAuctionForEditAsync(int id)
        {
            var auction = await repository.AllAsReadOnly<Auction>()
               .Where(x => x.Id == id)
               .Select(x => new ModeratorAuctionFormViewModel()
               {
                   ConditionId = x.ConditionId,
                   

               }).FirstAsync();

            return auction;
        }

        public async Task ModeratorEditAsync(int id, ModeratorAuctionFormViewModel model)
        {
            var auction = await repository.GetByIdAsync<Auction>(id);



            if (auction != null)
            {
               
                auction.ConditionId = model.ConditionId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task SetConditionToFinish(int auctionId)
        {
            var auction = await GetAuctionByIdAsync(auctionId);

            auction.ConditionId = 5;
            await repository.SaveChangesAsync();
        }

        public async Task<bool> UserExistAsync(string id)
        {
            return await repository.AllAsReadOnly<ApplicationUser>()
                .AnyAsync(x => x.Id == id);
        }
    }
}
