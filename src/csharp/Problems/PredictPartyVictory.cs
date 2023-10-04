//https://leetcode.com/problems/dota2-senate

namespace LeetCode.Problems;

public sealed class PredictPartyVictory : ProblemBase
{
    [Theory]
    [ClassData(typeof(PredictPartyVictory))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("RD").Result("Radiant"))
          .Add(it => it.Param("RDD").Result("Dire"))
          .Add(it => it.Param("RRDDD").Result("Radiant"))
          .Add(it => it.Param("DRRDRDRDRDDRDRDR").Result("Radiant"));

    private string Solution(string senate)
    {
        var voting = new Queue<char>();
        var radiant = (total: 0, skip: 0);
        var dire = (total: 0, skip: 0);

        foreach(var senator in senate) 
        {
            if (senator is 'R')
            {
                radiant.total++;
            }
            else
            {
                dire.total++;
            }

            voting.Enqueue(senator);
        }

        while (radiant.total > 0 && dire.total > 0)
        {
            var senator = voting.Dequeue();
            if (senator is 'R')
            {
                if (radiant.skip <= 0)
                {
                    dire.skip++;
                    dire.total--;
                    voting.Enqueue(senator);
                }
                else
                {
                    radiant.skip--;
                }
            }
            else if (dire.skip <= 0)
            {
                radiant.skip++;
                radiant.total--;
                voting.Enqueue(senator);
            }
            else
            {
                dire.skip--;
            }        
        }

        return dire.total == 0 ? "Radiant" : "Dire";
    }

    private string Solution1(string senate)
    {
        var radiant = new Queue<int>();
        var dire = new Queue<int>();
        
        for (var order = 0; order < senate.Length; order++)
        {
            if (senate[order] is 'R')
            {
                radiant.Enqueue(order);
            }
            else
            {
                dire.Enqueue(order);
            }
        }

        while (radiant.Count > 0 && dire.Count > 0)
        {
            var radiantVoter = radiant.Dequeue();
            var direVoter = dire.Dequeue();
            if (radiantVoter < direVoter)
            {
                radiant.Enqueue(radiantVoter + senate.Length);
            }
            else
            {
                dire.Enqueue(direVoter + senate.Length);
            }        
        }

        return dire.Count == 0 ? "Radiant" : "Dire";
    }
}