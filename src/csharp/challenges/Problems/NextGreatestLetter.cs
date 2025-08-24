// https://leetcode.com/problems/find-smallest-letter-greater-than-target

namespace LeetCode.Problems;

public sealed class NextGreatestLetter : ProblemBase
{
    [Theory]
    [ClassData(typeof(NextGreatestLetter))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.ParamArray(['c', 'f', 'j']).Add('a').Result('c'))
          .Add(it => it.ParamArray(['c', 'f', 'j']).Add('f').Result('f'))
          .Add(it => it.ParamArray(['x','x','y','y']).Add('x').Result('x'))
          .Add(it => it.ParamArray(['a', 'z']).Add('z').Result('z'))
          .Add(it => it.ParamArray(['e','e','e','e','e','e','n','n','n','n']).Add('e').Result('n'))
          .Add(it => it.ParamArray(['c', 'f', 'j']).Add('g').Result('j'))
          .Add(it => it.ParamArray(['c', 'f', 'j']).Add('d').Result('f'))
          .Add(it => it.ParamArray(['c','f','j', 'k', 'm', 'p']).Add('l').Result('m'));

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
