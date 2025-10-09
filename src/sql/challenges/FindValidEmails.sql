
/* https://leetcode.com/problems/find-valid-emails */

CREATE TABLE If not Exists Users (
    user_id INT,
    email VARCHAR(255)
)
Truncate table Users
insert into Users (user_id, email) values ('1', 'alice@example.com')
insert into Users (user_id, email) values ('2', 'bob_at_example.com')
insert into Users (user_id, email) values ('3', 'charlie@example.net')
insert into Users (user_id, email) values ('4', 'david@domain.com')
insert into Users (user_id, email) values ('5', 'eve@invalid')

# Write your MySQL query statement below
SELECT *
FROM Users
WHERE email REGEXP '^[0-9A-Za-z_]+@[A-Za-z]+\\.com$'

/*MSSQL*/
SELECT *
FROM Users
WHERE email LIKE '[a-zA-Z0-9_]%@[a-zA-Z]%.com'AND
      email NOT LIKE '%..%' AND
      email NOT LIKE '%.%@%' AND
      email NOT LIKE '%@[a-zA-Z]%[0-9]%'

/*
Test Cases
{"headers":{"Users":["user_id","email"]},"rows":{"Users":[[1,"alice@example.com"],[2,"bob_at_example.com"],[3,"charlie@example.net"],[4,"david@domain.com"],[5,"eve@invalid"]]}}
*/
