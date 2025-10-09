
/* https://leetcode.com/problems/employees-earning-more-than-their-managers */

# Write your MySQL query statement below


/*
Employee
| id | name  | salary | managerId |
| -- | ----- | ------ | --------- |
| 1  | Joe   | 70000  | 3         |
| 2  | Henry | 80000  | 4         |
| 3  | Sam   | 60000  | null      |
| 4  | Max   | 90000  | null      |

Output
| Employee |
| -------- |
| Joe      |

Test Cases
{"headers": {"Employee": ["id", "name", "salary", "managerId"]}, "rows": {"Employee": [[1, "Joe", 70000, 3], [2, "Henry", 80000, 4], [3, "Sam", 60000, null], [4, "Max", 90000, null]]}}
*/

/* MySQL, MsSQL */

SELECT
    e.name AS Employee
FROM Employee e
INNER JOIN Employee m ON e.managerId = m.id AND e.salary > m.salary
