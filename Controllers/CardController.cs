using Microsoft.AspNetCore.Mvc;
using ZadanieProgramistyczneMillenium.Models;
using ZadanieProgramistyczneMillenium.Services;

namespace ZadanieProgramistyczneMillenium.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardsController(ICardService cardService, ICardAllowedActionService allowedActionService) : ControllerBase
{
    [HttpPost("allowed-actions")]
    public async Task<IActionResult> GetAllowedActions(GetAllowedActionsRequest request)
    {
        var cardDetails = await cardService.GetCardDetails(request.UserId, request.CardNumber);

        if (cardDetails == null)
        {
            return NotFound($"Card with number '{request.CardNumber}' for user '{request.UserId}' was not found");
        }

        var allowedActions = allowedActionService.GetAllowedActions(cardDetails);

        var response = new GetAllowedActionsResponse(
            CardNumber: cardDetails.CardNumber,
            AllowedActions: allowedActions
        );

        return Ok(response);
    }
}
