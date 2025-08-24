// https://leetcode.com/problems/find-smallest-letter-greater-than-target

namespace LeetCode.Problems;

public sealed class FindSmallestLetterGreaterThanTarget : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindSmallestLetterGreaterThanTarget))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray(['c', 'f', 'j']).Param('a').Result('c'))
          .Add(it => it.ParamArray(['c', 'f', 'j']).Param('f').Result('j'))
          .Add(it => it.ParamArray(['x','x','y','y']).Param('x').Result('y'))
          .Add(it => it.ParamArray(['a', 'z']).Param('z').Result('a'))
          .Add(it => it.ParamArray(['e','e','e','e','e','e','n','n','n','n']).Param('e').Result('n'))
          .Add(it => it.ParamArray(['c', 'f', 'j']).Param('g').Result('j'))
          .Add(it => it.ParamArray(['c', 'f', 'j']).Param('d').Result('f'))
          .Add(it => it.ParamArray(['c','f','j', 'k', 'm', 'p']).Param('l').Result('m'));

    private char Solution1(char[] letters, char target)
    {
        int left = 0;
        int right = letters.Length - 1;

        while (left <= right) 
        {
            int mid = (left + right) / 2;

            if (letters[mid] > target) 
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return left < letters.Length ? letters[left] : letters[0];
    }
}
