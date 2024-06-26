using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AuctionSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
