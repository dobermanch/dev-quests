# https://leetcode.com/problems/reshape-data-concatenate
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class ConcatenateTables(ProblemBase):
    def Solution(self, df1: pd.DataFrame, df2: pd.DataFrame) -> pd.DataFrame:
        return pd.concat([df1, df2])


if __name__ == '__main__':
    TestGen(ConcatenateTables) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +------------+---------+-----+
                        | student_id | name    | age |
                        +------------+---------+-----+
                        | 1          | Mason   | 8   |
                        | 2          | Ava     | 6   |
                        | 3          | Taylor  | 15  |
                        | 4          | Georgia | 17  |
                        +------------+---------+-----+
                    ''')
                    .ParamDataFrame('''
                        +------------+------+-----+
                        | student_id | name | age |
                        +------------+------+-----+
                        | 5          | Leo  | 7   |
                        | 6          | Alex | 7   |
                        +------------+------+-----+
                    ''')
                    .ResultDataFrame('''
                        +------------+---------+-----+
                        | student_id | name    | age |
                        +------------+---------+-----+
                        | 1          | Mason   | 8   |
                        | 2          | Ava     | 6   |
                        | 3          | Taylor  | 15  |
                        | 4          | Georgia | 17  |
                        | 5          | Leo     | 7   |
                        | 6          | Alex    | 7   |
                        +------------+---------+-----+
                    ''')) \
        .Run()


