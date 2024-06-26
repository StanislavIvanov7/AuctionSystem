using Microsoft.AspNetCore.Mvc;
namespace AuctionSystem.Components
{
    public class MainMenuComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
