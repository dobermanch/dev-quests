
/* https://leetcode.com/problems/department-highest-salary */

# Write your MySQL, MsSQL query statement below


SELECT
    d.name AS Department,
    e.name AS Employee,
    MAX(e.salary) AS Salary
FROM Department d
INNER JOIN (
    SELECT
        *,
        DENSE_RANK() OVER (PARTITION BY departmentId ORDER BY salary) AS 'rank'
    FROM Employee
) e ON d.id = e.departmentId
GROUP BY d.id

/* PostgreSQL */

SELECT
    d.name AS Department,
    e.name AS Employee,
    e.salary AS Salary
FROM Department d
INNER JOIN (
    SELECT
        *,
        DENSE_RANK() OVER (PARTITION BY departmentId ORDER BY salary DESC) AS rank
    FROM Employee
) e ON d.id = e.departmentId AND e.rank = 1

/*

Input:
Employee table:
| id | name  | salary | departmentId |
| -- | ----- | ------ | ------------ |
| 1  | Joe   | 70000  | 1            |
| 2  | Jim   | 90000  | 1            |
| 3  | Henry | 80000  | 2            |
| 4  | Sam   | 60000  | 2            |
| 5  | Max   | 90000  | 1            |

Department table:
| id | name  |
| -- | ----- |
| 1  | IT    |
| 2  | Sales |
Output:
| Department | Employee | Salary |
| ---------- | -------- | -------|
| IT         | Jim      | 90000  |
| Sales      | Henry    | 80000  |
| IT         | Max      | 90000  |

Test Cases
{"headers": {"Employee": ["id", "name", "salary", "departmentId"], "Department": ["id", "name"]}, "rows": {"Employee": [[1, "Joe", 70000, 1], [2, "Jim", 90000, 1], [3, "Henry", 80000, 2], [4, "Sam", 60000, 2], [5, "Max", 90000, 1]], "Department": [[1, "IT"], [2, "Sales"]]}}
*/
