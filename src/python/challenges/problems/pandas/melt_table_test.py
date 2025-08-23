# https://leetcode.com/problems/reshape-data-melt
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class MeltTable(ProblemBase):
    def Solution(self, report: pd.DataFrame) -> pd.DataFrame:
        report = report.melt(
                    id_vars='product',
                    value_name="sales",
                    var_name="quarter")
        
        return report


if __name__ == '__main__':
    TestGen(MeltTable) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +-------------+-----------+-----------+-----------+-----------+
                        | product     | quarter_1 | quarter_2 | quarter_3 | quarter_4 |
                        +-------------+-----------+-----------+-----------+-----------+
                        | Umbrella    | 417       | 224       | 379       | 611       |
                        | SleepingBag | 800       | 936       | 93        | 875       |
                        +-------------+-----------+-----------+-----------+-----------+
                    ''')
                    .ResultDataFrame('''
                        +-------------+-----------+-------+
                        | product     | quarter   | sales |
                        +-------------+-----------+-------+
                        | Umbrella    | quarter_1 | 417   |
                        | SleepingBag | quarter_1 | 800   |
                        | Umbrella    | quarter_2 | 224   |
                        | SleepingBag | quarter_2 | 936   |
                        | Umbrella    | quarter_3 | 379   |
                        | SleepingBag | quarter_3 | 93    |
                        | Umbrella    | quarter_4 | 611   |
                        | SleepingBag | quarter_4 | 875   |
                        +-------------+-----------+-------+
                    ''')) \
        .Run()


