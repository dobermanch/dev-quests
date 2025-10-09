
/* https://leetcode.com/problems/swap-salary */
Create table If Not Exists Salary (id int, name varchar(100), sex char(1), salary int)
Truncate table Salary
insert into Salary (id, name, sex, salary) values ('1', 'A', 'm', '2500')
insert into Salary (id, name, sex, salary) values ('2', 'B', 'f', '1500')
insert into Salary (id, name, sex, salary) values ('3', 'C', 'm', '5500')
insert into Salary (id, name, sex, salary) values ('4', 'D', 'f', '500')

# Write your MySQL, MsSQL, PostgreSQL query statement below
UPDATE Salary
SET sex = (
    CASE
        WHEN sex = 'm' THEN 'f'
        WHEN sex = 'f' THEN 'm'
        ELSE sex
    END
)

/*
Input:
Salary table:
| id | name | sex | salary |
| -- | ---- | --- | ------ |
| 1  | A    | m   | 2500   |
| 2  | B    | f   | 1500   |
| 3  | C    | m   | 5500   |
| 4  | D    | f   | 500    |

Output:
| id | name | sex | salary |
| -- | ---- | --- | ------ |
| 1  | A    | f   | 2500   |
| 2  | B    | m   | 1500   |
| 3  | C    | f   | 5500   |
| 4  | D    | m   | 500    |

Test Cases
{"headers":{"Salary":["id","name","sex","salary"]},"rows":{"Salary":[[1,"A","m",2500],[2,"B","f",1500],[3,"C","m",5500],[4,"D","f",500]]}}
*/
