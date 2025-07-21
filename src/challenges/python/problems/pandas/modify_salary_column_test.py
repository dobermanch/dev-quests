# https://leetcode.com/problems/modify-columns
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class ModifySalaryColumn(ProblemBase):
    def Solution(self, employees: pd.DataFrame) -> pd.DataFrame:
        employees.salary = employees.salary * 2
        return employees


if __name__ == '__main__':
    TestGen(ModifySalaryColumn) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +---------+--------+
                        | name    | salary |
                        +---------+--------+
                        | Jack    | 19666  |
                        | Piper   | 74754  |
                        | Mia     | 62509  |
                        | Ulysses | 54866  |
                        +---------+--------+
                    ''')
                    .ResultDataFrame('''
                        +---------+--------+
                        | name    | salary |
                        +---------+--------+
                        | Jack    | 39332  |
                        | Piper   | 149508 |
                        | Mia     | 125018 |
                        | Ulysses | 109732 |
                        +---------+--------+
                    ''')) \
        .Run()


