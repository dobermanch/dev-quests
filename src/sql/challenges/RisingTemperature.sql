/* https://leetcode.com/problems/rising-temperature/ */

Create table If Not Exists Weather (id int, recordDate date, temperature int)
Truncate table Weather
insert into Weather (id, recordDate, temperature) values ('1', '2015-01-01', '10')
insert into Weather (id, recordDate, temperature) values ('2', '2015-01-02', '25')
insert into Weather (id, recordDate, temperature) values ('3', '2015-01-03', '20')
insert into Weather (id, recordDate, temperature) values ('4', '2015-01-04', '30')

/* Solution MySQL */
SELECT w1.id
FROM Weather w1, Weather w2
WHERE dateDiff(w1.recordDate, w2.recordDate) = 1 AND w1.temperature > w2.temperature

/* Solution T-SQL */
SELECT w1.id
FROM Weather w1, Weather w2
WHERE dateDiff(day, w2.recordDate, w1.recordDate) = 1 AND w1.temperature > w2.temperature