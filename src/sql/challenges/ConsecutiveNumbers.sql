/* https://leetcode.com/problems/consecutive-numbers/description/ */

Create table If Not Exists Logs (id int, num int)
Truncate table Logs
insert into Logs (id, num) values ('1', '1')
insert into Logs (id, num) values ('2', '1')
insert into Logs (id, num) values ('3', '1')
insert into Logs (id, num) values ('4', '2')
insert into Logs (id, num) values ('5', '1')
insert into Logs (id, num) values ('6', '2')
insert into Logs (id, num) values ('7', '2')

/* Solution */
SELECT
    DISTINCT num AS ConsecutiveNums
FROM (
        SELECT
            num,
            lag(num, 1) OVER (ORDER BY id ASC) AS 'prev',
            lead(num, 1) OVER (ORDER BY id ASC) AS 'next'
        FROM Logs
    ) l
WHERE num = prev AND num = next