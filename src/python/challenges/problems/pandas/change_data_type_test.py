# https://leetcode.com/problems/change-data-type
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class ChangeDatatype(ProblemBase):
    def Solution(self, students: pd.DataFrame) -> pd.DataFrame:
        students["grade"] = students["grade"].astype(int)
        return students


if __name__ == '__main__':
    TestGen(ChangeDatatype) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +------------+------+-----+-------+
                        | student_id | name | age | grade |
                        +------------+------+-----+-------+
                        | 1          | Ava  | 6   | 73.0  |
                        | 2          | Kate | 15  | 87.0  |
                        +------------+------+-----+-------+
                    ''')
                    .ResultDataFrame('''
                        +------------+------+-----+-------+
                        | student_id | name | age | grade |
                        +------------+------+-----+-------+
                        | 1          | Ava  | 6   | 73    |
                        | 2          | Kate | 15  | 87    |
                        +------------+------+-----+-------+
                    ''')) \
        .Run()


