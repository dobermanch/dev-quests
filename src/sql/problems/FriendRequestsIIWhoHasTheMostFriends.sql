/* https://leetcode.com/problems/friend-requests-ii-who-has-the-most-friends/ */

Create table If Not Exists RequestAccepted (requester_id int not null, accepter_id int null, accept_date date null)
Truncate table RequestAccepted
insert into RequestAccepted (requester_id, accepter_id, accept_date) values ('1', '2', '2016/06/03')
insert into RequestAccepted (requester_id, accepter_id, accept_date) values ('1', '3', '2016/06/08')
insert into RequestAccepted (requester_id, accepter_id, accept_date) values ('2', '3', '2016/06/08')
insert into RequestAccepted (requester_id, accepter_id, accept_date) values ('3', '4', '2016/06/09')

/* Solution MySQL*/
SELECT
    id,
    sum(count) AS num
FROM (
    SELECT
        requester_id AS id,
        count(requester_id) AS count
    FROM RequestAccepted
    GROUP BY requester_id
    UNION ALL
    SELECT
        accepter_id AS ID,
        count(accepter_id) AS count
    FROM RequestAccepted
    GROUP BY accepter_id
) c
GROUP BY id
ORDER BY num DESC
LIMIT 1

/* Solution T-SQL */
SELECT TOP 1
    id,
    sum(count) AS num
FROM (
    SELECT
        requester_id AS id,
        count(requester_id) AS count
    FROM RequestAccepted
    GROUP BY requester_id
    UNION ALL
    SELECT
        accepter_id AS ID,
        count(accepter_id) AS count
    FROM RequestAccepted
    GROUP BY accepter_id
) c
GROUP BY id
ORDER BY num DESC