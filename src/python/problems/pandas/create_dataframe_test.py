# https://leetcode.com/problems/create-a-dataframe-from-list
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class CreateDataframe(ProblemBase):
    def Solution(self, student_data: list[list[int]]) -> pd.DataFrame:
        students = pd.DataFrame(
            data = student_data,
            columns = ["student_id", "age"]
        )

        return students


if __name__ == '__main__':
    TestGen(CreateDataframe) \
        .Add(lambda tc: 
                tc.Param([[1, 15],[2, 11],[3, 11],[4, 20]])
                    .ResultDataFrame('''
                        +------------+-----+
                        | student_id | age |
                        +------------+-----+
                        | 1          | 15  |
                        | 2          | 11  |
                        | 3          | 11  |
                        | 4          | 20  |
                        +------------+-----+
                    ''')) \
        .Run()


