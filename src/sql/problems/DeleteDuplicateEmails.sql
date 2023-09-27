/* https://leetcode.com/problems/delete-duplicate-emails/ */

Create table If Not Exists Person (Id int, Email varchar(255))
Truncate table Person
insert into Person (id, email) values ('1', 'john@example.com')
insert into Person (id, email) values ('2', 'bob@example.com')
insert into Person (id, email) values ('3', 'john@example.com')

/* Solution MySQL */
DELETE p1 
FROM Person p1, (
    SELECT 
      id,
      row_number() OVER(PARTITION BY email ORDER BY id) as 'row'
    FROM Person
  ) p2
WHERE p1.id = p2.id AND p2.row > 1

/* Solution T-SQL */
DELETE FROM Person
WHERE id NOT IN (
    SELECT 
      min(id)      
    FROM Person
    GROUP BY email
  )