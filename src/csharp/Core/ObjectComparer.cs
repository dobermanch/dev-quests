using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace LeetCode.Core;

internal class ObjectComparer : EqualityComparer<object>
{
    public override bool Equals(object x, object y)
    {
        if (x is double or float)
        {
            return Math.Abs((double)x - (double)y) < 0.0001;
        }
        else if (typeof(IEnumerable).IsAssignableFrom(x.GetType()))
        {
            return ((IEnumerable)x).OfType<object>().SequenceEqual(((IEnumerable)y).OfType<object>(), new ObjectComparer());
        }

        return object.Equals(x, y);
    }

    public override int GetHashCode([DisallowNull] object obj) => obj.GetHashCode();
}
