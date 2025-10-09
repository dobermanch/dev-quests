
/* https://leetcode.com/problems/rank-scores */

# Write your MySQL query statement below


/*
scores
| id | score |
| -- | ----- |
| 1  | 3.5   |
| 2  | 3.65  |
| 3  | 4     |
| 4  | 3.85  |
| 5  | 4     |
| 6  | 3.65  |

output
| score | rank |
| ----- | ---- |
| 4     | 1    |
| 4     | 1    |
| 3.85  | 2    |
| 3.65  | 3    |
| 3.65  | 3    |
| 3.5   | 4    |

Test Cases
{"headers": {"Scores": ["id", "score"]}, "rows": {"Scores": [[1, 3.50], [2, 3.65], [3, 4.00], [4, 3.85], [5, 4.00], [6, 3.65]]}}
*/

/*MySql, MsSql*/

SELECT
    score,
    DENSE_RANK() OVER (ORDER BY score DESC) AS 'rank'
FROM Scores
