# https://leetcode.com/problems/select-data
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class SelectData(ProblemBase):
    def Solution(self, students: pd.DataFrame) -> pd.DataFrame:
        student = students[students["student_id"] == 101]
        return student[["name", "age"]]


if __name__ == '__main__':
    TestGen(SelectData) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +------------+---------+-----+
                        | student_id | name    | age |
                        +------------+---------+-----+
                        | 101        | Ulysses | 13  |
                        | 53         | William | 10  |
                        | 128        | Henry   | 6   |
                        | 3          | Henry   | 11  |
                        +------------+---------+-----+
                    ''')
                    .ResultDataFrame('''
                        +---------+-----+
                        | name    | age |
                        +---------+-----+
                        | Ulysses | 13  |
                        +---------+-----+
                    ''')) \
        .Run()


