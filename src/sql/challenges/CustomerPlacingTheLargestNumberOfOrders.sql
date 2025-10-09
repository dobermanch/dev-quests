
/* https://leetcode.com/problems/customer-placing-the-largest-number-of-orders */

# Write your MySQL, PostgreSQL query statement below

SELECT
    customer_number
FROM Orders
GROUP BY customer_number
ORDER BY COUNT(customer_number) DESC
LIMIT 1

/* MsSQL */

SELECT TOP 1
    customer_number
FROM Orders
GROUP BY customer_number
ORDER BY COUNT(customer_number) DESC

/*

Input:
Orders table:
| order_number | customer_number |
| ------------ | --------------- |
| 1            | 1               |
| 2            | 2               |
| 3            | 3               |
| 4            | 3               |

Output:
| customer_number |
| --------------- |
| 3               |

Test Cases
{"headers":{"orders":["order_number","customer_number"]},"rows":{"orders":[[1,1],[2,2],[3,3],[4,3]]}}
*/
