using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Areas.Moderator.Components;

public class ModeratorMenuComponents : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.FromResult<IViewComponentResult>(View());
    }
}
