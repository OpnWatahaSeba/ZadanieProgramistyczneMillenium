using System.ComponentModel.DataAnnotations;

namespace ZadanieProgramistyczneMillenium.Models;

public record GetAllowedActionsRequest(
    [Required(AllowEmptyStrings = false, ErrorMessage = "UserId is required and cannot be empty")]
    string UserId,

    [Required(AllowEmptyStrings = false, ErrorMessage = "CardNumber is required and cannot be empty")]
    string CardNumber
);

public record GetAllowedActionsResponse(
    string CardNumber,
    IEnumerable<string> AllowedActions
);
