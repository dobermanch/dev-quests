#https://leetcode.com/problems/dota2-senate/

from core.problem_base import *

class PredictPartyVictory(ProblemBase):
    def Solution(self, senate: str) -> str:
        voting = []
        radiantTotal = 0
        radiantSkip = 0
        direTotal = 0
        direSkip = 0

        for senator in senate:
            voting.append(senator)
            if senator == 'R':
                radiantTotal += 1
            else:
                direTotal += 1
        
        while radiantTotal > 0 and direTotal > 0:
            senator = voting.pop(0)
            if senator == 'R':
                if radiantSkip <= 0:
                    direSkip += 1
                    direTotal -= 1
                    voting.append(senator)
                else:
                    radiantSkip -= 1
            elif direSkip <= 0:
                radiantSkip += 1
                radiantTotal -= 1
                voting.append(senator)
            else:
                direSkip -= 1

        return "Radiant" if direTotal == 0 else "Dire"
    
    def Solution1(self, senate: str) -> str:
        radiant = []
        dire = []
        
        for order in range(len(senate)):
            if senate[order] == 'R':
                radiant.append(order)
            else:
                dire.append(order)
        
        while radiant and dire:
            radiantVoter = radiant.pop(0)
            direVoter = dire.pop(0)
            if radiantVoter < direVoter:
                radiant.append(radiantVoter + len(senate))
            else:
                dire.append(direVoter + len(senate))

        return "Radiant" if radiant else "Dire"

if __name__ == '__main__':
    TestGen(PredictPartyVictory) \
        .Add(lambda tc: tc.Param("RD").Result("Radiant")) \
        .Add(lambda tc: tc.Param("RDD").Result("Dire")) \
        .Add(lambda tc: tc.Param("RRDDD").Result("Radiant")) \
        .Add(lambda tc: tc.Param("DRRDRDRDRDDRDRDR").Result("Radiant")) \
        .Run()
