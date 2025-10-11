
/* https://leetcode.com/problems/find-covid-recovery-patients */

CREATE TABLE patients (
    patient_id INT,
    patient_name VARCHAR(255),
    age INT
)
CREATE TABLE covid_tests (
    test_id INT,
    patient_id INT,
    test_date DATE,
    result VARCHAR(50)
)
Truncate table patients
insert into patients (patient_id, patient_name, age) values ('1', 'Alice Smith', '28')
insert into patients (patient_id, patient_name, age) values ('2', 'Bob Johnson', '35')
insert into patients (patient_id, patient_name, age) values ('3', 'Carol Davis', '42')
insert into patients (patient_id, patient_name, age) values ('4', 'David Wilson', '31')
insert into patients (patient_id, patient_name, age) values ('5', 'Emma Brown', '29')
Truncate table covid_tests
insert into covid_tests (test_id, patient_id, test_date, result) values ('1', '1', '2023-01-15', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('2', '1', '2023-01-25', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('3', '2', '2023-02-01', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('4', '2', '2023-02-05', 'Inconclusive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('5', '2', '2023-02-12', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('6', '3', '2023-01-20', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('7', '3', '2023-02-10', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('8', '3', '2023-02-20', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('9', '4', '2023-01-10', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('10', '4', '2023-01-18', 'Positive')
insert into covid_tests (test_id, patient_id, test_date, result) values ('11', '5', '2023-02-15', 'Negative')
insert into covid_tests (test_id, patient_id, test_date, result) values ('12', '5', '2023-02-20', 'Negative')

# Write your MySQL query statement below
WITH tests AS (
    SELECT
        c1.patient_id,
        c1.test_date AS start_date,
        c2.test_date AS end_date
    FROM covid_tests c1
    INNER JOIN covid_tests c2 ON c1.patient_id = c2.patient_id AND c1.test_date < c2.test_date
    WHERE c1.result = 'Positive' AND c2.result = 'Negative'
)

SELECT
    p.patient_id,
    p.patient_name,
    p.age,
    DATEDIFF(c.end_date, c.start_date) AS recovery_time
FROM (
    SELECT *
    FROM(
        SELECT
            patient_id,
            MIN(start_date) AS start_date,
            MAX(end_date) AS end_date
        FROM tests
        GROUP BY patient_id, end_date
    ) c
    GROUP BY patient_id
) c
INNER JOIN patients p ON c.patient_id = p.patient_id
ORDER BY recovery_time ASC, p.patient_name ASC

/* MSSQL */
WITH tests AS (
    SELECT
        c1.patient_id,
        c1.test_date AS start_date,
        c2.test_date AS end_date
    FROM covid_tests c1
    INNER JOIN covid_tests c2 ON c1.patient_id = c2.patient_id AND c1.test_date < c2.test_date
    WHERE c1.result = 'Positive' AND c2.result = 'Negative'
)

SELECT
    p.patient_id,
    p.patient_name,
    p.age,
    DATEDIFF(DAY, c.start_date, c.end_date) AS recovery_time
FROM (
    SELECT
        patient_id,
        MIN(start_date) AS start_date,
        MIN(end_date) AS end_date
    FROM(
        SELECT
            patient_id,
            MIN(start_date) AS start_date,
            MAX(end_date) AS end_date
        FROM tests
        GROUP BY patient_id, end_date
    ) t
    GROUP BY patient_id
) c
INNER JOIN patients p ON c.patient_id = p.patient_id
ORDER BY recovery_time ASC, p.patient_name ASC

/*
Test Cases
{"headers":{"patients":["patient_id","patient_name","age"],"covid_tests":["test_id","patient_id","test_date","result"]},"rows":{"patients":[[1,"Alice Smith",28],[2,"Bob Johnson",35],[3,"Carol Davis",42],[4,"David Wilson",31],[5,"Emma Brown",29]],"covid_tests":[[1,1,"2023-01-15","Positive"],[2,1,"2023-01-25","Negative"],[3,2,"2023-02-01","Positive"],[4,2,"2023-02-05","Inconclusive"],[5,2,"2023-02-12","Negative"],[6,3,"2023-01-20","Negative"],[7,3,"2023-02-10","Positive"],[8,3,"2023-02-20","Negative"],[9,4,"2023-01-10","Positive"],[10,4,"2023-01-18","Positive"],[11,5,"2023-02-15","Negative"],[12,5,"2023-02-20","Negative"]]}}
*/
