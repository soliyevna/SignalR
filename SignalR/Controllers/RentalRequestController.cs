using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalRequestController : ControllerBase
{
    private readonly IHubContext<NotificationHub> _hubContext;
    private List<RentalRequest> _requests = new ();
    public RentalRequestController(IHubContext<NotificationHub> hubContext)
    {
        this._hubContext = hubContext;
    }
    [HttpPost]
    public async Task<IActionResult> SendRentalRequestAsync(RentalRequest request)
    {
        this._requests.Add(request);
        await this._hubContext.Clients.All.SendAsync("ReceiveNotification", $"You have a new rental request for your {request.RealEstateId} from {request.TenantId}");
        return Ok();
    }
}
