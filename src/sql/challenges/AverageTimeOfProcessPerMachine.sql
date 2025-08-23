/* https://leetcode.com/problems/average-time-of-process-per-machine/ */

Create table If Not Exists Activity (machine_id int, process_id int, activity_type ENUM('start', 'end'), timestamp float)
Truncate table Activity
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('0', '0', 'start', '0.712')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('0', '0', 'end', '1.52')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('0', '1', 'start', '3.14')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('0', '1', 'end', '4.12')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('1', '0', 'start', '0.55')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('1', '0', 'end', '1.55')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('1', '1', 'start', '0.43')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('1', '1', 'end', '1.42')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('2', '0', 'start', '4.1')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('2', '0', 'end', '4.512')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('2', '1', 'start', '2.5')
insert into Activity (machine_id, process_id, activity_type, timestamp) values ('2', '1', 'end', '5')

/* Solution 1*/
SELECT 
  a1.machine_id,
  round(avg(a2.max - a2.min), 3) AS processing_time
FROM Activity a1 
INNER JOIN (
    SELECT 
      machine_id, 
      max(timestamp) AS max, 
      min(timestamp) AS min
    FROM Activity
    GROUP BY machine_id, process_id
  ) a2 ON a1.machine_id = a2.machine_id
GROUP BY a1.machine_id

/* Solution 2 */
SELECT 
  a1.machine_id,
  round(avg(a1.timestamp - a2.timestamp), 3) AS processing_time
FROM Activity a1 
INNER JOIN Activity a2 
  ON a1.machine_id = a2.machine_id
    AND a1.process_id = a2.process_id 
    AND a1.activity_type = 'end'
    AND a2.activity_type = 'start'
GROUP BY a1.machine_id