namespace Hearthstone.Renders;

internal abstract class RenderBase<T> : IRender
{
    public void Render(object item)
    {
        if (item is T value)
        {
            var foregroundColor = Console.ForegroundColor;

            RenderIternal(value);

            Console.ForegroundColor = foregroundColor;
        }
    }

    protected abstract void RenderIternal(T item);
}
