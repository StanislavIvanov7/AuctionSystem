using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AuctionSystem.Core.Constants.RoleConstants;

namespace AuctionSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = AdminRole)]
    public class AdministartorBaseController : Controller
    {
       
    }
}
