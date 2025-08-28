# https://leetcode.com/problems/create-a-new-column
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class CreateBonusColumn(ProblemBase):
    def Solution(self, employees: pd.DataFrame) -> pd.DataFrame:
        employees["bonus"] = employees["salary"] * 2

        return employees



if __name__ == '__main__':
    TestGen(CreateBonusColumn) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +---------+--------+
                        | name    | salary |
                        +---------+--------+
                        | Piper   | 4548   |
                        | Grace   | 28150  |
                        | Georgia | 1103   |
                        | Willow  | 6593   |
                        | Finn    | 74576  |
                        | Thomas  | 24433  |
                        +---------+--------+
                    ''')
                    .ResultDataFrame('''
                        +---------+--------+--------+
                        | name    | salary | bonus  |
                        +---------+--------+--------+
                        | Piper   | 4548   | 9096   |
                        | Grace   | 28150  | 56300  |
                        | Georgia | 1103   | 2206   |
                        | Willow  | 6593   | 13186  |
                        | Finn    | 74576  | 149152 |
                        | Thomas  | 24433  | 48866  |
                        +---------+--------+--------+
                    ''')) \
        .Run()


