using ZadanieProgramistyczneMillenium.Models;

namespace ZadanieProgramistyczneMillenium.Services;

public interface ICardService
{
    Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
}
