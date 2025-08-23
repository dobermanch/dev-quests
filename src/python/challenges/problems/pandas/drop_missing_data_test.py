# https://leetcode.com/problems/drop-missing-data
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class DropMissingData(ProblemBase):
    def Solution(self, students: pd.DataFrame) -> pd.DataFrame:
        filtered = students[students.name.notnull()]
        return filtered


if __name__ == '__main__':
    TestGen(DropMissingData) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +------------+---------+-----+
                        | student_id | name    | age |
                        +------------+---------+-----+
                        | 32         | Piper   | 5   |
                        | 217        |         | 19  |
                        | 779        | Georgia | 20  |
                        | 849        | Willow  | 14  |
                        +------------+---------+-----+
                    ''')
                    .ResultDataFrame('''
                        +------------+---------+-----+
                        | student_id | name    | age |
                        +------------+---------+-----+
                        | 32         | Piper   | 5   |
                        | 779        | Georgia | 20  | 
                        | 849        | Willow  | 14  |
                        +------------+---------+-----+
                    ''')) \
        .Run()


