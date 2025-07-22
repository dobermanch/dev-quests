using Hearthstone.Game.Decks.Providers;
using Hearthstone.Game.Decks.Shuffle;
using Hearthstone.Game.Players;
using Hearthstone.Game.Players.Selectors;
using Microsoft.Extensions.Logging;

namespace Hearthstone.Game;

public record GameOptions(
        IDeckProvider DeckProvider, 
        ICardShuffle ShuffleStrategy, 
        IPlayerSelector PlayerSelector, 
        PlayerOptions PlayerSettings,
        ILogger<IGame> Logger
   );