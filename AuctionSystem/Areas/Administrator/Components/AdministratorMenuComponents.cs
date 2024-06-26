using Microsoft.AspNetCore.Mvc;
namespace AuctionSystem.Areas.Moderator.Components;
public class AdministratorMenuComponents : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult<IViewComponentResult>(View());
    }
}
