
/* https://leetcode.com/problems/calculate-special-bonus */

Create table If Not Exists Employees (employee_id int, name varchar(30), salary int)
Truncate table Employees
insert into Employees (employee_id, name, salary) values ('2', 'Meir', '3000')
insert into Employees (employee_id, name, salary) values ('3', 'Michael', '3800')
insert into Employees (employee_id, name, salary) values ('7', 'Addilyn', '7400')
insert into Employees (employee_id, name, salary) values ('8', 'Juan', '6100')
insert into Employees (employee_id, name, salary) values ('9', 'Kannon', '7700')

# Write your MySQL query statement below
SELECT
    employee_id,
    (CASE
        WHEN employee_id % 2 != 0 AND SUBSTRING(name, 1, 1) != 'M' THEN salary
        ELSE 0
    END) AS bonus
FROM Employees
ORDER BY employee_id

/*
Test Cases
{"headers":{"Employees":["employee_id","name","salary"]},"rows":{"Employees":[[2,"Meir",3000],[3,"Michael",3800],[7,"Addilyn",7400],[8,"Juan",6100],[9,"Kannon",7700]]}}
*/
