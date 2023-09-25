/* https://leetcode.com/problems/game-play-analysis-iv/ */

Create table If Not Exists Activity (player_id int, device_id int, event_date date, games_played int)
Truncate table Activity
insert into Activity (player_id, device_id, event_date, games_played) values ('1', '2', '2016-03-01', '5')
insert into Activity (player_id, device_id, event_date, games_played) values ('1', '2', '2016-03-02', '6')
insert into Activity (player_id, device_id, event_date, games_played) values ('2', '3', '2017-06-25', '1')
insert into Activity (player_id, device_id, event_date, games_played) values ('3', '1', '2016-03-02', '0')
insert into Activity (player_id, device_id, event_date, games_played) values ('3', '4', '2018-07-03', '5')

/* Solution MySQL*/
SELECT
  round(1.0 * sum(CASE WHEN a1.event_date = a2.next_date THEN 1 ELSE 0 END) / count(DISTINCT a1.player_id), 2) AS fraction
FROM Activity a1
LEFT JOIN (
    SELECT
      player_id,
      adddate(min(event_date), interval 1 day) AS next_date
    FROM Activity
    GROUP BY player_id
  ) a2 ON a1.player_id = a2.player_id
  
/* Solution T-SQL */
SELECT
  round(1.0 * sum(CASE WHEN a1.event_date = a2.next_date THEN 1 ELSE 0 END) / count(DISTINCT a1.player_id), 2) AS fraction
FROM Activity a1
LEFT JOIN (
    SELECT
      player_id,
      dateadd(day, 1, min(event_date)) AS next_date
    FROM Activity
    GROUP BY player_id
  ) a2 ON a1.player_id = a2.player_id
