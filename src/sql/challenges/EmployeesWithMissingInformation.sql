
/* https://leetcode.com/problems/employees-with-missing-information */

Create table If Not Exists Employees (employee_id int, name varchar(30))
Create table If Not Exists Salaries (employee_id int, salary int)
Truncate table Employees
insert into Employees (employee_id, name) values ('2', 'Crew')
insert into Employees (employee_id, name) values ('4', 'Haven')
insert into Employees (employee_id, name) values ('5', 'Kristian')
Truncate table Salaries
insert into Salaries (employee_id, salary) values ('5', '76071')
insert into Salaries (employee_id, salary) values ('1', '22517')
insert into Salaries (employee_id, salary) values ('4', '63539')

# Write your MySQL query statement below
SELECT e.employee_id
FROM Employees e
LEFT JOIN Salaries s ON e.employee_id = s.employee_id
WHERE s.salary IS NULL

UNION

SELECT s.employee_id
FROM Employees e
RIGHT JOIN Salaries s ON e.employee_id = s.employee_id
WHERE e.name IS NULL OR e.name = ''
ORDER BY employee_id

/* MSSQL, PostgreSQL*/
SELECT
    COALESCE(e.employee_id, s.employee_id) AS employee_id
FROM Employees e
FULL OUTER JOIN Salaries s ON e.employee_id = s.employee_id
WHERE e.name IS NULL OR e.name = '' OR s.salary IS NULL
ORDER BY employee_id

/*
Test Cases
{"headers":{"Employees":["employee_id","name"],"Salaries":["employee_id","salary"]},"rows":{"Employees":[[2,"Crew"],[4,"Haven"],[5,"Kristian"]],"Salaries":[[5,76071],[1,22517],[4,63539]]}}
*/
