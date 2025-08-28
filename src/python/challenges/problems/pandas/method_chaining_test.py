# https://leetcode.com/problems/method-chaining
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class FindHeavyAnimals(ProblemBase):
    def Solution(self, animals: pd.DataFrame) -> pd.DataFrame:
        filtered = animals[animals['weight'] > 100].sort_values(by='weight', ascending=False)['name']
        return pd.DataFrame(filtered)


if __name__ == '__main__':
    TestGen(FindHeavyAnimals) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +----------+---------+-----+--------+
                        | name     | species | age | weight |
                        +----------+---------+-----+--------+
                        | Tatiana  | Snake   | 98  | 464    |
                        | Khaled   | Giraffe | 50  | 41     |
                        | Alex     | Leopard | 6   | 328    |
                        | Jonathan | Monkey  | 45  | 463    |
                        | Stefan   | Bear    | 100 | 50     |
                        | Tommy    | Panda   | 26  | 349    |
                        +----------+---------+-----+--------+
                    ''')
                    .ResultDataFrame('''
                        +----------+
                        | name     |
                        +----------+
                        | Tatiana  |
                        | Jonathan |
                        | Tommy    |
                        | Alex     |
                        +----------+
                    ''')) \
        .Run()


