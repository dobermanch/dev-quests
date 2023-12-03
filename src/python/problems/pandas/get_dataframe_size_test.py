# https://leetcode.com/problems/get-the-size-of-a-dataframe
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class GetDataframeSize(ProblemBase):
    def Solution(self, players: pd.DataFrame) -> list[int]:
        rows, cols = players.shape
        return [rows, cols]



if __name__ == '__main__':
    TestGen(GetDataframeSize) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                    +-----------+----------+-----+-------------+--------------------+
                    | player_id | name     | age | position    | team               |
                    +-----------+----------+-----+-------------+--------------------+
                    | 846       | Mason    | 21  | Forward     | RealMadrid         |
                    | 749       | Riley    | 30  | Winger      | Barcelona          |
                    | 155       | Bob      | 28  | Striker     | ManchesterUnited   |
                    | 583       | Isabella | 32  | Goalkeeper  | Liverpool          |
                    | 388       | Zachary  | 24  | Midfielder  | BayernMunich       |
                    | 883       | Ava      | 23  | Defender    | Chelsea            |
                    | 355       | Violet   | 18  | Striker     | Juventus           |
                    | 247       | Thomas   | 27  | Striker     | ParisSaint-Germain |
                    | 761       | Jack     | 33  | Midfielder  | ManchesterCity     |
                    | 642       | Charlie  | 36  | Center-back | Arsenal            |
                    +-----------+----------+-----+-------------+--------------------+                    
                    ''')
                    .Result([10, 5])) \
        .Run()


