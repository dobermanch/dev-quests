/* https://leetcode.com/problems/second-highest-salary/ */

Create table If Not Exists Employee (id int, salary int)
Truncate table Employee
insert into Employee (id, salary) values ('1', '100')
insert into Employee (id, salary) values ('2', '200')
insert into Employee (id, salary) values ('3', '300')

/* Solution */
SELECT
    max(salary) AS SecondHighestSalary
FROM (
    SELECT 
        *,
        dense_rank() OVER (ORDER BY salary DESC) as 'rank'
    FROM Employee
) s
WHERE s.rank = 2