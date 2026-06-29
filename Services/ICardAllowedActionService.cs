using ZadanieProgramistyczneMillenium.Models;

namespace ZadanieProgramistyczneMillenium.Services;

public interface ICardAllowedActionService
{
    IEnumerable<string> GetAllowedActions(CardDetails card);
}
