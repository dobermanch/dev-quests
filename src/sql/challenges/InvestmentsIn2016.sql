/* https://leetcode.com/problems/investments-in-2016/ */

Create Table If Not Exists Insurance (pid int, tiv_2015 float, tiv_2016 float, lat float, lon float)
Truncate table Insurance
insert into Insurance (pid, tiv_2015, tiv_2016, lat, lon) values ('1', '10', '5', '10', '10')
insert into Insurance (pid, tiv_2015, tiv_2016, lat, lon) values ('2', '20', '20', '20', '20')
insert into Insurance (pid, tiv_2015, tiv_2016, lat, lon) values ('3', '10', '30', '20', '20')
insert into Insurance (pid, tiv_2015, tiv_2016, lat, lon) values ('4', '10', '40', '40', '40')

/* Solution */
SELECT
  round(sum(tiv_2016), 2) AS tiv_2016
FROM (
  SELECT
    tiv_2016,
    count(*) OVER(PARTITION BY tiv_2015) AS 'tiv_count',
    count(*) OVER(PARTITION BY lat, lon) AS 'coord_count'
  FROM Insurance
) i1
WHERE tiv_count > 1 AND coord_count = 1