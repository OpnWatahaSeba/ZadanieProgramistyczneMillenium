using ZadanieProgramistyczneMillenium.Models;

namespace ZadanieProgramistyczneMillenium.Services;

public class CardAllowedActionService : ICardAllowedActionService
{
    private readonly Dictionary<string, Func<CardDetails, bool>> _rules;

    public CardAllowedActionService()
    {
        _rules = new Dictionary<string, Func<CardDetails, bool>>
        {
            ["ACTION1"] = c => c.CardStatus == CardStatus.Active,

            ["ACTION2"] = c => c.CardStatus == CardStatus.Inactive,

            ["ACTION3"] = c => true, // always true

            ["ACTION4"] = c => true, // always true

            ["ACTION5"] = c => c.CardType == CardType.Credit,

            ["ACTION6"] = c => c.IsPinSet && (c.CardStatus == CardStatus.Ordered ||
                                              c.CardStatus == CardStatus.Inactive ||
                                              c.CardStatus == CardStatus.Active ||
                                              c.CardStatus == CardStatus.Blocked),

            ["ACTION7"] = c => (c.CardStatus == CardStatus.Blocked && c.IsPinSet) ||
                               (!c.IsPinSet && (c.CardStatus == CardStatus.Ordered ||
                                                c.CardStatus == CardStatus.Inactive ||
                                                c.CardStatus == CardStatus.Active)),

            ["ACTION8"] = c => c.CardStatus is not (CardStatus.Restricted or CardStatus.Expired or CardStatus.Closed),

            ["ACTION9"] = c => true, // always true

            ["ACTION10"] = c => c.CardStatus is not (CardStatus.Restricted or CardStatus.Blocked or CardStatus.Expired or CardStatus.Closed),

            ["ACTION11"] = c => c.CardStatus is not (CardStatus.Ordered or CardStatus.Restricted or CardStatus.Blocked or CardStatus.Expired or CardStatus.Closed),

            ["ACTION12"] = c => c.CardStatus is not (CardStatus.Restricted or CardStatus.Blocked or CardStatus.Expired or CardStatus.Closed),

            ["ACTION13"] = c => c.CardStatus is not (CardStatus.Restricted or CardStatus.Blocked or CardStatus.Expired or CardStatus.Closed)
        };
    }

    public IEnumerable<string> GetAllowedActions(CardDetails card)
    {
        return _rules
            .Where(rule => rule.Value(card))
            .Select(rule => rule.Key);
    }
}
