
// https://leetcode.com/problems/minimum-genetic-mutation

namespace LeetCode.Problems;

public sealed class MinimumGeneticMutation : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinimumGeneticMutation))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("AAAAAAAA").Param("AAAAACGG").ParamArray(["AAAAAAGA", "AAAAAGGA", "AAAAACGA", "AAAAACGG", "AAAAAAGG", "AAAAAAGC"]).Result(3))
          .Add(it => it.Param("AAAAAAAA").Param("CCCCCCCC").ParamArray(["AAAAAAAA", "AAAAAAAC", "AAAAAACC", "AAAAACCC", "AAAACCCC", "AACACCCC", "ACCACCCC", "ACCCCCCC", "CCCCCCCA", "CCCCCCCC"]).Result(8))
          .Add(it => it.Param("AACCGGTT").Param("AACCGCTA").ParamArray(["AACCGGTA","AACCGCTA","AAACGGTA"]).Result(2))
          .Add(it => it.Param("AACCGGTT").Param("AAACGGTA").ParamArray(["AACCGGTA","AACCGCTA","AAACGGTA"]).Result(2))
          .Add(it => it.Param("AAAAAAAA").Param("CCCCCCCC").ParamArray(["AAAAAAAA","AAAAAAAC","AAAAAACC","AAAAACCC","AAAACCCC","AACACCCC","ACCACCCC","ACCCCCCC","CCCCCCCA"]).Result(-1))
          .Add(it => it.Param("AACCGGTT").Param("AACCGGTA").ParamArray(["AACCGGTA"]).Result(1) )
        ;

    private int Solution(string startGene, string endGene, string[] bank)
    {
        var bankSet = bank.ToHashSet();
        var seen = new Dictionary<string, int>();
        var queue = new Queue<(string gene, int index, int count)>();
        queue.Enqueue((endGene, endGene.Length - 1, 0));

        var letters = new[] { 'A', 'C', 'G', 'T' };
        int result = -1;

        while (queue.Count > 0)
        {
            var (gene, index, count) = queue.Dequeue();

            if (gene == startGene)
            {
                result = count;
                break;
            }

            if (!bankSet.Contains(gene))
            {
                continue;
            }

            if (seen.ContainsKey(gene))
            {
                index -= 1;
            }
            else
            {
                count += 1;
                index = endGene.Length - 1;
                seen[gene] = count;
            }
                        
            if (index < 0)
            {
                continue;
            }

            foreach (char l in letters)
            {
                string mutated = gene.Substring(0, index) + l + gene.Substring(index + 1);
                queue.Enqueue((mutated, index, seen[gene]));
            }
        }

        return result;
    }
}
