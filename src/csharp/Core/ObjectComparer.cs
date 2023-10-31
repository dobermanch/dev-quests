using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace LeetCode.Core;

internal class ObjectComparer : EqualityComparer<object?>
{
    public override bool Equals(object x, object y)
    {
        if (x is double or float)
        {
            return Math.Abs((double)x - (double)y) < 0.0001;
        }

        if (x is not null && typeof(IEnumerable).IsAssignableFrom(x.GetType()))
        {
            return ((IEnumerable)x).OfType<object>().SequenceEqual(((IEnumerable)y).OfType<object>(), new ObjectComparer());
        }

        if (x is not null)
        {
            var equatable = typeof(IEquatable<>).MakeGenericType(x.GetType()).GetTypeInfo();
            if (equatable.IsAssignableFrom(x.GetType().GetTypeInfo()))
            {
                var equalsMethod = equatable.GetDeclaredMethod(nameof(IEquatable<object>.Equals));
                if (equalsMethod == null)
                {
                    return false;
                }

                return (bool)equalsMethod.Invoke(x, new object[] { y })!;
            }
        }

        return Default.Equals(x, y);
    }

    public override int GetHashCode([DisallowNull] object obj) => obj.GetHashCode();
}
