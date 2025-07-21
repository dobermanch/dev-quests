# https://leetcode.com/problems/rename-columns
import pandas as pd
from models.data_frame import *
from core.problem_base import *

class RenameColumns(ProblemBase):
    def Solution(self, students: pd.DataFrame) -> pd.DataFrame:
        students = students.rename(columns={
            "id": "student_id",
            "first": "first_name",
            "last": "last_name",
            "age": "age_in_years",
        })

        return students


if __name__ == '__main__':
    TestGen(RenameColumns) \
        .Add(lambda tc: 
                tc.ParamDataFrame('''
                        +----+---------+----------+-----+
                        | id | first   | last     | age |
                        +----+---------+----------+-----+
                        | 1  | Mason   | King     | 6   |
                        | 2  | Ava     | Wright   | 7   |
                        | 3  | Taylor  | Hall     | 16  |
                        | 4  | Georgia | Thompson | 18  |
                        | 5  | Thomas  | Moore    | 10  |
                        +----+---------+----------+-----+
                    ''')
                    .ResultDataFrame('''
                        +------------+------------+-----------+--------------+
                        | student_id | first_name | last_name | age_in_years |
                        +------------+------------+-----------+--------------+
                        | 1          | Mason      | King      | 6            |
                        | 2          | Ava        | Wright    | 7            |
                        | 3          | Taylor     | Hall      | 16           |
                        | 4          | Georgia    | Thompson  | 18           |
                        | 5          | Thomas     | Moore     | 10           |
                        +------------+------------+-----------+--------------+
                    ''')) \
        .Run()


