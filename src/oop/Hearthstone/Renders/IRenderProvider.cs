namespace Hearthstone.Renders;

internal interface IRenderProvider
{
    void Render<T>(T type);
}
