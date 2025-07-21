# https://leetcode.com/problems/display-the-first-three-rows
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class SelectFirstRows(ProblemBase):
    def Solution(self, employees: pd.DataFrame) -> pd.DataFrame:
        return employees.head(3)



if __name__ == '__main__':
    TestGen(SelectFirstRows) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +-------------+-----------+-----------------------+--------+
                        | employee_id | name      | department            | salary |
                        +-------------+-----------+-----------------------+--------+
                        | 3           | Bob       | Operations            | 48675  |
                        | 90          | Alice     | Sales                 | 11096  |
                        | 9           | Tatiana   | Engineering           | 33805  |
                        | 60          | Annabelle | InformationTechnology | 37678  |
                        | 49          | Jonathan  | HumanResources        | 23793  |
                        | 43          | Khaled    | Administration        | 40454  |
                        +-------------+-----------+-----------------------+--------+                
                    ''')
                    .ResultDataFrame('''
                        +-------------+---------+-------------+--------+
                        | employee_id | name    | department  | salary |
                        +-------------+---------+-------------+--------+
                        | 3           | Bob     | Operations  | 48675  |
                        | 90          | Alice   | Sales       | 11096  |
                        | 9           | Tatiana | Engineering | 33805  |
                        +-------------+---------+-------------+--------+
                    ''')) \
        .Run()


