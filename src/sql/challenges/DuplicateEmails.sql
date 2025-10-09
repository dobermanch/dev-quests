
/* https://leetcode.com/problems/duplicate-emails */

# Write your MySQL, MsSQL query statement below

SELECT
    email
FROM Person
GROUP BY email
HAVING count(*) > 1

/*
Input:
Person table:
+----+---------+
| id | email   |
+----+---------+
| 1  | a@b.com |
| 2  | c@d.com |
| 3  | a@b.com |
+----+---------+
Output:
+---------+
| Email   |
+---------+
| a@b.com |
+---------+
Test Cases
{"headers": {"Person": ["id", "email"]}, "rows": {"Person": [[1, "a@b.com"], [2, "c@d.com"], [3, "a@b.com"]]}}
*/
