
/* https://leetcode.com/problems/analyze-organization-hierarchy */

CREATE TABLE if not exists Employees (
    employee_id INT,
    employee_name VARCHAR(100),
    manager_id INT,
    salary INT,
    department VARCHAR(50)
)
Truncate table Employees
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('1', 'Alice', NULL, '12000', 'Executive')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('2', 'Bob', '1', '10000', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('3', 'Charlie', '1', '10000', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('4', 'David', '2', '7500', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('5', 'Eva', '2', '7500', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('6', 'Frank', '3', '9000', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('7', 'Grace', '3', '8500', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('8', 'Hank', '4', '6000', 'Sales')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('9', 'Ivy', '6', '7000', 'Engineering')
insert into Employees (employee_id, employee_name, manager_id, salary, department) values ('10', 'Judy', '6', '7000', 'Engineering')

# Write your MySQL, PostgreSQL query statement below
WITH RECURSIVE ManagerChain AS (
  SELECT
    employee_id,
    manager_id,
    salary
  FROM Employees
  WHERE manager_id IS NOT NULL

  UNION ALL

  SELECT
    e.employee_id,
    mc.manager_id,
    e.salary
  FROM ManagerChain mc
  JOIN Employees e ON e.manager_id = mc.employee_id
),
levelChain AS (
  SELECT
    employee_id,
    employee_name,
    manager_id,
    1 AS level,
    salary
  FROM employees
  WHERE manager_id IS NULL

  UNION ALL

  SELECT
    e.employee_id,
    e.employee_name,
    e.manager_id,
    l.level + 1,
    e.salary
  FROM employees e
  JOIN levelChain l ON e.manager_id = l.employee_id
)

SELECT
    l.employee_id,
    l.employee_name,
    l.level,
    COALESCE(mc.team_size, 0) AS team_size,
    l.salary + COALESCE(mc.budget, 0) AS budget
FROM levelChain l
LEFT JOIN (
    SELECT
        manager_id,
        COUNT(*) AS team_size,
        SUM(salary) AS budget
    FROM ManagerChain
    GROUP BY manager_id
) mc ON l.employee_id = mc.manager_id
ORDER BY l.level ASC, budget DESC, l.employee_name ASC

/* MSSQL */
WITH ManagerChain AS (
  SELECT
    employee_id,
    manager_id,
    salary
  FROM Employees
  WHERE manager_id IS NOT NULL

  UNION ALL

  SELECT
    e.employee_id,
    mc.manager_id,
    e.salary
  FROM ManagerChain mc
  JOIN Employees e ON e.manager_id = mc.employee_id
),
levelChain AS (
  SELECT
    employee_id,
    employee_name,
    manager_id,
    1 AS level,
    salary
  FROM employees
  WHERE manager_id IS NULL

  UNION ALL

  SELECT
    e.employee_id,
    e.employee_name,
    e.manager_id,
    l.level + 1,
    e.salary
  FROM employees e
  JOIN levelChain l ON e.manager_id = l.employee_id
)

SELECT
    l.employee_id,
    l.employee_name,
    l.level,
    COALESCE(mc.team_size, 0) AS team_size,
    l.salary + COALESCE(mc.budget, 0) AS budget
FROM levelChain l
LEFT JOIN (
    SELECT
        manager_id,
        COUNT(*) AS team_size,
        SUM(salary) AS budget
    FROM ManagerChain
    GROUP BY manager_id
) mc ON l.employee_id = mc.manager_id
ORDER BY l.level ASC, budget DESC, l.employee_name ASC

/*
Test Cases
{"headers":{"Employees":["employee_id","employee_name","manager_id","salary","department"]},"rows":{"Employees":[[1,"Alice",null,12000,"Executive"],[2,"Bob",1,10000,"Sales"],[3,"Charlie",1,10000,"Engineering"],[4,"David",2,7500,"Sales"],[5,"Eva",2,7500,"Sales"],[6,"Frank",3,9000,"Engineering"],[7,"Grace",3,8500,"Engineering"],[8,"Hank",4,6000,"Sales"],[9,"Ivy",6,7000,"Engineering"],[10,"Judy",6,7000,"Engineering"]]}}
*/
