/* https://leetcode.com/problems/last-person-to-fit-in-the-bus/ */

Create table If Not Exists Queue (person_id int, person_name varchar(30), weight int, turn int)
Truncate table Queue
insert into Queue (person_id, person_name, weight, turn) values ('5', 'Alice', '250', '1')
insert into Queue (person_id, person_name, weight, turn) values ('4', 'Bob', '175', '5')
insert into Queue (person_id, person_name, weight, turn) values ('3', 'Alex', '350', '2')
insert into Queue (person_id, person_name, weight, turn) values ('6', 'John Cena', '400', '3')
insert into Queue (person_id, person_name, weight, turn) values ('1', 'Winston', '500', '6')
insert into Queue (person_id, person_name, weight, turn) values ('2', 'Marie', '200', '4')

/* Solution MySQL */
SELECT
  person_name
FROM (
    SELECT
      *,
      sum(weight) OVER(ORDER BY turn) AS total
    FROM Queue
  ) q
WHERE total <= 1000
ORDER BY total DESC
LIMIT 1

/* Solution T-SQL */
SELECT TOP 1
  person_name
FROM (
    SELECT
      *,
      sum(weight) OVER(ORDER BY turn) AS total
    FROM Queue
  ) q
WHERE total <= 1000
ORDER BY total DESC