/* https://leetcode.com/problems/the-number-of-employees-which-report-to-each-employee/ */

Create table If Not Exists Employees(employee_id int, name varchar(20), reports_to int, age int)
Truncate table Employees
insert into Employees (employee_id, name, reports_to, age) values ('9', 'Hercy', 'None', '43')
insert into Employees (employee_id, name, reports_to, age) values ('6', 'Alice', '9', '41')
insert into Employees (employee_id, name, reports_to, age) values ('4', 'Bob', '9', '36')
insert into Employees (employee_id, name, reports_to, age) values ('2', 'Winston', 'None', '37')

/* Solution */
SELECT
    e1.employee_id,
    e1.name,
    e2.reports_count,
    e2.average_age
FROM Employees e1
INNER JOIN (
        SELECT
            reports_to,
            count(reports_to) AS reports_count,
            round(avg(age * 1.0), 0) AS average_age
        FROM Employees
        GROUP BY reports_to
    ) e2 ON e1.employee_id = e2.reports_to
ORDER BY e1.employee_id