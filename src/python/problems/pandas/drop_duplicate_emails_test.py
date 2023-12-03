# https://leetcode.com/problems/drop-duplicate-rows
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class DropDuplicateEmails(ProblemBase):
    def Solution(self, customers: pd.DataFrame) -> pd.DataFrame:
        filtered = customers.drop_duplicates(["email"], keep='first')    
        return filtered


if __name__ == '__main__':
    TestGen(DropDuplicateEmails) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +-------------+---------+---------------------+
                        | customer_id | name    | email               |
                        +-------------+---------+---------------------+
                        | 1           | Ella    | emily@example.com   |
                        | 2           | David   | michael@example.com |
                        | 3           | Zachary | sarah@example.com   |
                        | 4           | Alice   | john@example.com    |
                        | 5           | Finn    | john@example.com    |
                        | 6           | Violet  | alice@example.com   |
                        +-------------+---------+---------------------+
                    ''')
                    .ResultDataFrame('''
                        +-------------+---------+---------------------+
                        | customer_id | name    | email               |
                        +-------------+---------+---------------------+
                        | 1           | Ella    | emily@example.com   |
                        | 2           | David   | michael@example.com |
                        | 3           | Zachary | sarah@example.com   |
                        | 4           | Alice   | john@example.com    |
                        | 6           | Violet  | alice@example.com   |
                        +-------------+---------+---------------------+
                    ''')) \
        .Run()


