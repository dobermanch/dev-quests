namespace Hearthstone.Renders;

public record GameTitle();

internal sealed class GameTitleRender : RenderBase<GameTitle>
{
    protected override void RenderIternal(GameTitle item)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(""" _   _                 _   _         _                   """);
        Console.WriteLine("""| | | | ___  __ _ _ __| |_| |__  ___| |_ ___  _ __   ___ """);
        Console.WriteLine("""| |_| |/ _ \/ _` | '__| __| '_ \/ __| __/ _ \| '_ \ / _ \""");
        Console.WriteLine("""|  _  |  __/ (_| | |  | |_| | | \__ \ || (_) | | | |  __/""");
        Console.WriteLine("""|_| |_|\___|\__,_|_|   \__|_| |_|___/\__\___/|_| |_|\___|""");
        Console.WriteLine();
    }
}
