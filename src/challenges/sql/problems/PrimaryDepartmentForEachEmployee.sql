/* https://leetcode.com/problems/primary-department-for-each-employee/ */

Create table If Not Exists Employee (employee_id int, department_id int, primary_flag ENUM('Y','N'))
Truncate table Employee
insert into Employee (employee_id, department_id, primary_flag) values ('1', '1', 'N')
insert into Employee (employee_id, department_id, primary_flag) values ('2', '1', 'Y')
insert into Employee (employee_id, department_id, primary_flag) values ('2', '2', 'N')
insert into Employee (employee_id, department_id, primary_flag) values ('3', '3', 'N')
insert into Employee (employee_id, department_id, primary_flag) values ('4', '2', 'N')
insert into Employee (employee_id, department_id, primary_flag) values ('4', '3', 'Y')
insert into Employee (employee_id, department_id, primary_flag) values ('4', '4', 'N')

/* Solution */
SELECT
  e1.employee_id,
  e1.department_id
FROM Employee e1
INNER JOIN (
    SELECT
      employee_id,
      count(department_id) AS count
    FROM Employee
    GROUP BY employee_id
  ) e2 ON e1.employee_id = e2.employee_id
WHERE e2.count = 1 OR e1.primary_flag = 'Y'  