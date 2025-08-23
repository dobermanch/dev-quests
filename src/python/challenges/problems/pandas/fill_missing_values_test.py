# https://leetcode.com/problems/fill-missing-data
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class FillMissingValues(ProblemBase):
    def Solution(self, products: pd.DataFrame) -> pd.DataFrame:
        products["quantity"] = products["quantity"].fillna(0, downcast='int')
        return products


if __name__ == '__main__':
    TestGen(FillMissingValues) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +-----------------+----------+-------+
                        | name            | quantity | price |
                        +-----------------+----------+-------+
                        | Wristwatch      |          | 135   |
                        | WirelessEarbuds |          | 821   |
                        | GolfClubs       | 779      | 9319  |
                        | Printer         | 849      | 3051  |
                        +-----------------+----------+-------+
                    ''')
                    .ResultDataFrame('''
                        +-----------------+----------+-------+
                        | name            | quantity | price |
                        +-----------------+----------+-------+
                        | Wristwatch      | 0        | 135   |
                        | WirelessEarbuds | 0        | 821   |
                        | GolfClubs       | 779      | 9319  |
                        | Printer         | 849      | 3051  |
                        +-----------------+----------+-------+
                    ''')) \
        .Run()


