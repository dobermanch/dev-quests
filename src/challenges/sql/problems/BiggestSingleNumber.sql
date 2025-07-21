/* https://leetcode.com/problems/biggest-single-number/ */

Create table If Not Exists MyNumbers (num int)
Truncate table MyNumbers
insert into MyNumbers (num) values ('8')
insert into MyNumbers (num) values ('8')
insert into MyNumbers (num) values ('3')
insert into MyNumbers (num) values ('3')
insert into MyNumbers (num) values ('1')
insert into MyNumbers (num) values ('4')
insert into MyNumbers (num) values ('5')
insert into MyNumbers (num) values ('6')

/* Solution */
SELECT 
  max(n.num) AS num
FROM (
    SELECT 
      num
    FROM MyNumbers
    GROUP BY num
    HAVING count(*) = 1
  ) n