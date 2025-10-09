
/* https://leetcode.com/problems/customers-who-never-order */

# Write your MySQL, MsSQL, PostgreSQL query statement below

SELECT
    c.name AS Customers
FROM Customers c
LEFT JOIN Orders o ON c.id = o.customerId
WHERE o.id IS NULL

/*
Input:
Customers table:
| id | name  |
| -- | ----- |
| 1  | Joe   |
| 2  | Henry |
| 3  | Sam   |
| 4  | Max   |

Orders table:
| id | customerId |
| -- | ---------- |
| 1  | 3          |
| 2  | 1          |

Output:
| customers |
| --------- |
| Henry     |
| Max       |

Test Cases
{"headers": {"Customers": ["id", "name"], "Orders": ["id", "customerId"]}, "rows": {"Customers": [[1, "Joe"], [2, "Henry"], [3, "Sam"], [4, "Max"]], "Orders": [[1, 3], [2, 1]]}}
*/
