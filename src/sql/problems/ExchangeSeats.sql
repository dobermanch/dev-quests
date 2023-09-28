/* https://leetcode.com/problems/exchange-seats/ */

Create table If Not Exists Seat (id int, student varchar(255))
Truncate table Seat
insert into Seat (id, student) values ('1', 'Abbot')
insert into Seat (id, student) values ('2', 'Doris')
insert into Seat (id, student) values ('3', 'Emerson')
insert into Seat (id, student) values ('4', 'Green')
insert into Seat (id, student) values ('5', 'Jeames')

/* Solution */
SELECT
    CASE 
        WHEN s1.id = s2.id AND s2.id % 2 = 1 THEN s1.id
        WHEN s1.id % 2 = 0 THEN s1.id - 1
        WHEN s1.id % 2 = 1 THEN s1.id + 1
    END AS id,
    student
FROM Seat s1
LEFT JOIN (
        SELECT 
            max(id) AS id
        FROM Seat
    ) s2 ON s1.id = s2.id
ORDER BY id