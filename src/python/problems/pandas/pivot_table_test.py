# https://leetcode.com/problems/reshape-data-pivot
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class PivotTable(ProblemBase):
    def Solution(self, weather: pd.DataFrame) -> pd.DataFrame:
        weather = weather.pivot(index='month', columns=['city'], values='temperature')

        # need only for current ProblemBase test runner
        weather.insert(0, 'month', weather.index)

        return weather


if __name__ == '__main__':
    TestGen(PivotTable) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +--------------+----------+-------------+
                        | city         | month    | temperature |
                        +--------------+----------+-------------+
                        | Jacksonville | January  | 13          |
                        | Jacksonville | February | 23          |
                        | Jacksonville | March    | 38          |
                        | Jacksonville | April    | 5           |
                        | Jacksonville | May      | 34          |
                        | ElPaso       | January  | 20          |
                        | ElPaso       | February | 6           |
                        | ElPaso       | March    | 26          |
                        | ElPaso       | April    | 2           |
                        | ElPaso       | May      | 43          |
                        +--------------+----------+-------------+
                    ''')
                    .ResultDataFrame('''
                        +----------+--------+--------------+
                        | month    | ElPaso | Jacksonville |
                        +----------+--------+--------------+
                        | April    | 2      | 5            |
                        | February | 6      | 23           |
                        | January  | 20     | 13           |
                        | March    | 26     | 38           |
                        | May      | 43     | 34           |
                        +----------+--------+--------------+
                    ''')) \
        .Run()


