/* https://leetcode.com/problems/fix-names-in-a-table/ */

Create table If Not Exists Users (user_id int, name varchar(40))
Truncate table Users
insert into Users (user_id, name) values ('1', 'aLice')
insert into Users (user_id, name) values ('2', 'bOB')

/* Solution MySQL */
SELECT
    user_id,
    concat(upper(left(name, 1)), lower(right(name, length(name) - 1))) AS name
FROM Users
ORDER BY user_id

/* Solution T-SQL */
SELECT
    user_id,
    concat(upper(left(name, 1)), lower(right(name, len(name) - 1))) AS name
FROM Users
ORDER BY user_id