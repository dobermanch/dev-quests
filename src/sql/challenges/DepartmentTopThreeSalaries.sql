/* https://leetcode.com/problems/department-top-three-salaries/ */

Create table If Not Exists Employee (id int, name varchar(255), salary int, departmentId int)
Create table If Not Exists Department (id int, name varchar(255))
Truncate table Employee
insert into Employee (id, name, salary, departmentId) values ('1', 'Joe', '85000', '1')
insert into Employee (id, name, salary, departmentId) values ('2', 'Henry', '80000', '2')
insert into Employee (id, name, salary, departmentId) values ('3', 'Sam', '60000', '2')
insert into Employee (id, name, salary, departmentId) values ('4', 'Max', '90000', '1')
insert into Employee (id, name, salary, departmentId) values ('5', 'Janet', '69000', '1')
insert into Employee (id, name, salary, departmentId) values ('6', 'Randy', '85000', '1')
insert into Employee (id, name, salary, departmentId) values ('7', 'Will', '70000', '1')
Truncate table Department
insert into Department (id, name) values ('1', 'IT')
insert into Department (id, name) values ('2', 'Sales')

/* Solution 1. T-SQL only */
WITH Salary(departmentId, name, salary, rank) AS
(
    SELECT departmentId, name, salary, dense_rank() OVER (PARTITION BY departmentId ORDER BY salary DESC) AS n
    FROM Employee
)

SELECT d.name AS Department, s.name AS Employee, s.salary AS Salary
FROM Department d
INNER JOIN Salary s ON d.id = s.departmentId AND s.rank <= 3

/* Solution 2. It works for T-SQL and MySql*/
SELECT d.name AS Department, s.name AS Employee, s.salary AS Salary
FROM Department d
INNER JOIN (
    SELECT *, DENSE_RANK() OVER (PARTITION BY departmentid ORDER BY salary DESC) AS 'rank'
    FROM Employee
) s ON d.id = s.departmentId AND s.rank <= 3