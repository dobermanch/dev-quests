
/* https://leetcode.com/problems/human-traffic-of-stadium */

# Write your MySQL, MsSQL query statement below

SELECT
    DISTINCT s.*
FROM Stadium s
INNER JOIN (
    SELECT
        *,
        LAG(id) OVER (ORDER BY id) AS 'lag',
        LEAD(id) OVER (ORDER BY id) AS 'lead'
    FROM Stadium
    WHERE people >= 100
) s1 ON s.id IN (s1.id, s1.lag, s1.lead) AND s1.id - 1 = s1.lag AND s1.id + 1 = s1.lead


/* PostgreSQL */
SELECT
    DISTINCT s.*
FROM Stadium s
INNER JOIN (
    SELECT
        *,
        LAG(id) OVER (ORDER BY id) AS lag,
        LEAD(id) OVER (ORDER BY id) AS lead
    FROM Stadium
    WHERE people >= 100
) s1 ON s.id IN (s1.id, s1.lag, s1.lead) AND s1.id - 1 = s1.lag AND s1.id + 1 = s1.lead

/*
Input:
Stadium table:
| id   | visit_date | people    |
| ---- | ---------- | --------- |
| 1    | 2017-01-01 | 10        |
| 2    | 2017-01-02 | 109       |
| 3    | 2017-01-03 | 150       |
| 4    | 2017-01-04 | 99        |
| 5    | 2017-01-05 | 145       |
| 6    | 2017-01-06 | 1455      |
| 7    | 2017-01-07 | 199       |
| 8    | 2017-01-09 | 188       |

Output:
| id   | visit_date | people    |
| ---- | ---------- | --------- |
| 5    | 2017-01-05 | 145       |
| 6    | 2017-01-06 | 1455      |
| 7    | 2017-01-07 | 199       |
| 8    | 2017-01-09 | 188       |

Test Cases
{"headers": {"Stadium": ["id", "visit_date", "people"]}, "rows": {"Stadium": [[1, "2017-01-01", 10], [2, "2017-01-02", 109], [3, "2017-01-03", 150], [4, "2017-01-04", 99], [5, "2017-01-05", 145], [6, "2017-01-06", 1455], [7, "2017-01-07", 199], [8, "2017-01-09", 188]]}}
*/
