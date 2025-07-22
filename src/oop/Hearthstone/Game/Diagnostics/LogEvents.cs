using Microsoft.Extensions.Logging;

namespace Hearthstone.Game.Diagnostics;

internal class LogEvents
{
    public static readonly EventId GameInit = new(1001, nameof(GameInit));
    public static readonly EventId GameStarted = new(1002, nameof(GameStarted));
    public static readonly EventId GameInProgress = new(1003, nameof(GameInProgress));
    public static readonly EventId GameStopped = new(1004, nameof(GameStopped));
}
