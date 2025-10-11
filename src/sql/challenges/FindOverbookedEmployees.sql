
/* https://leetcode.com/problems/find-overbooked-employees */

CREATE TABLE if not exists employees (
    employee_id INT,
    employee_name VARCHAR(255),
    department VARCHAR(100)
)
CREATE TABLE meetings (
    meeting_id INT,
    employee_id INT,
    meeting_date DATE,
    meeting_type VARCHAR(50),
    duration_hours DECIMAL(4, 2)
)
Truncate table employees
insert into employees (employee_id, employee_name, department) values ('1', 'Alice Johnson', 'Engineering')
insert into employees (employee_id, employee_name, department) values ('2', 'Bob Smith', 'Marketing')
insert into employees (employee_id, employee_name, department) values ('3', 'Carol Davis', 'Sales')
insert into employees (employee_id, employee_name, department) values ('4', 'David Wilson', 'Engineering')
insert into employees (employee_id, employee_name, department) values ('5', 'Emma Brown', 'HR')
Truncate table meetings
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('1', '1', '2023-06-05', 'Team', '8.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('2', '1', '2023-06-06', 'Client', '6.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('3', '1', '2023-06-07', 'Training', '7.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('4', '1', '2023-06-12', 'Team', '12.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('5', '1', '2023-06-13', 'Client', '9.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('6', '2', '2023-06-05', 'Team', '15.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('7', '2', '2023-06-06', 'Client', '8.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('8', '2', '2023-06-12', 'Training', '10.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('9', '3', '2023-06-05', 'Team', '4.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('10', '3', '2023-06-06', 'Client', '3.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('11', '4', '2023-06-05', 'Team', '25.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('12', '4', '2023-06-19', 'Client', '22.0')
insert into meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) values ('13', '5', '2023-06-05', 'Training', '2.0')

# Write your MySQL query statement below
SELECT
    e.employee_id,
    e.employee_name,
    e.department,
    COUNT(*) AS meeting_heavy_weeks
FROM (
    SELECT
        employee_id,
        WEEK(meeting_date, 1) AS week
    FROM meetings
    GROUP BY employee_id, WEEK(meeting_date, 1)
    HAVING SUM(duration_hours) > 20
) m
INNER JOIN employees e ON m.employee_id = e.employee_id
GROUP BY e.employee_id, e.employee_name, e.department
HAVING COUNT(*) >= 2
ORDER BY meeting_heavy_weeks DESC, e.employee_name ASC

/* MSSQL */
SET DATEFIRST 1;

SELECT
    e.employee_id,
    e.employee_name,
    e.department,
    COUNT(*) AS meeting_heavy_weeks
FROM (
    SELECT
        employee_id,
        DATEPART(WEEK, meeting_date) AS week
    FROM meetings
    GROUP BY employee_id, DATEPART(WEEK, meeting_date)
    HAVING SUM(duration_hours) > 20
) m
INNER JOIN employees e ON m.employee_id = e.employee_id
GROUP BY e.employee_id, e.employee_name, e.department
HAVING COUNT(*) >= 2
ORDER BY meeting_heavy_weeks DESC, e.employee_name ASC

/* PostgreSQL */
SELECT
    e.employee_id,
    e.employee_name,
    e.department,
    COUNT(*) AS meeting_heavy_weeks
FROM (
    SELECT
        employee_id,
        EXTRACT('week' FROM meeting_date) AS week
    FROM meetings
    GROUP BY employee_id, EXTRACT('week' FROM meeting_date)
    HAVING SUM(duration_hours) > 20
) m
INNER JOIN employees e ON m.employee_id = e.employee_id
GROUP BY e.employee_id, e.employee_name, e.department
HAVING COUNT(*) >= 2
ORDER BY meeting_heavy_weeks DESC, e.employee_name ASC

/*
Test Cases
{"headers":{"employees":["employee_id","employee_name","department"],"meetings":["meeting_id","employee_id","meeting_date","meeting_type","duration_hours"]},"rows":{"employees":[[1,"Alice Johnson","Engineering"],[2,"Bob Smith","Marketing"],[3,"Carol Davis","Sales"],[4,"David Wilson","Engineering"],[5,"Emma Brown","HR"]],"meetings":[[1,1,"2023-06-05","Team",8.0],[2,1,"2023-06-06","Client",6.0],[3,1,"2023-06-07","Training",7.0],[4,1,"2023-06-12","Team",12.0],[5,1,"2023-06-13","Client",9.0],[6,2,"2023-06-05","Team",15.0],[7,2,"2023-06-06","Client",8.0],[8,2,"2023-06-12","Training",10.0],[9,3,"2023-06-05","Team",4.0],[10,3,"2023-06-06","Client",3.0],[11,4,"2023-06-05","Team",25.0],[12,4,"2023-06-19","Client",22.0],[13,5,"2023-06-05","Training",2.0]]}}
*/
