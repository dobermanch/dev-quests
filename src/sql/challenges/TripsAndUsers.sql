
/* https://leetcode.com/problems/trips-and-users */

Create table If Not Exists Trips (id int, client_id int, driver_id int, city_id int, status ENUM('completed', 'cancelled_by_driver', 'cancelled_by_client'), request_at varchar(50))
Create table If Not Exists Users (users_id int, banned varchar(50), role ENUM('client', 'driver', 'partner'))
Truncate table Trips
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('1', '1', '10', '1', 'completed', '2013-10-01')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('2', '2', '11', '1', 'cancelled_by_driver', '2013-10-01')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('3', '3', '12', '6', 'completed', '2013-10-01')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('4', '4', '13', '6', 'cancelled_by_client', '2013-10-01')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('5', '1', '10', '1', 'completed', '2013-10-02')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('6', '2', '11', '6', 'completed', '2013-10-02')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('7', '3', '12', '6', 'completed', '2013-10-02')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('8', '2', '12', '12', 'completed', '2013-10-03')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('9', '3', '10', '12', 'completed', '2013-10-03')
insert into Trips (id, client_id, driver_id, city_id, status, request_at) values ('10', '4', '13', '12', 'cancelled_by_driver', '2013-10-03')
Truncate table Users
insert into Users (users_id, banned, role) values ('1', 'No', 'client')
insert into Users (users_id, banned, role) values ('2', 'Yes', 'client')
insert into Users (users_id, banned, role) values ('3', 'No', 'client')
insert into Users (users_id, banned, role) values ('4', 'No', 'client')
insert into Users (users_id, banned, role) values ('10', 'No', 'driver')
insert into Users (users_id, banned, role) values ('11', 'No', 'driver')
insert into Users (users_id, banned, role) values ('12', 'No', 'driver')
insert into Users (users_id, banned, role) values ('13', 'No', 'driver')

# Write your MySQL, MsSQL query statement below

SELECT
    t.request_at AS Day,
    ROUND(
        1.0 * COUNT(CASE WHEN t.status IN ('cancelled_by_driver','cancelled_by_client') THEN 1 END) / count(t.status),
        2
    ) AS "Cancellation Rate"
FROM Trips t
INNER JOIN Users c ON c.users_id = t.client_id AND c.banned = 'NO'
INNER JOIN Users d ON d.users_id = t.driver_id AND d.banned = 'NO'
WHERE t.request_at BETWEEN '2013-10-01' AND '2013-10-03'
GROUP BY t.request_at

/*

Input:
Trips table:
| id | client_id | driver_id | city_id | status              | request_at |
| -- | --------- | --------- | ------- | ------------------- | ---------- |
| 1  | 1         | 10        | 1       | completed           | 2013-10-01 |
| 2  | 2         | 11        | 1       | cancelled_by_driver | 2013-10-01 |
| 3  | 3         | 12        | 6       | completed           | 2013-10-01 |
| 4  | 4         | 13        | 6       | cancelled_by_client | 2013-10-01 |
| 5  | 1         | 10        | 1       | completed           | 2013-10-02 |
| 6  | 2         | 11        | 6       | completed           | 2013-10-02 |
| 7  | 3         | 12        | 6       | completed           | 2013-10-02 |
| 8  | 2         | 12        | 12      | completed           | 2013-10-03 |
| 9  | 3         | 10        | 12      | completed           | 2013-10-03 |
| 10 | 4         | 13        | 12      | cancelled_by_driver | 2013-10-03 |

Users table:
| users_id | banned | role   |
| -------- | ------ | ------ |
| 1        | No     | client |
| 2        | Yes    | client |
| 3        | No     | client |
| 4        | No     | client |
| 10       | No     | driver |
| 11       | No     | driver |
| 12       | No     | driver |
| 13       | No     | driver |

Output:
| Day        | Cancellation Rate |
| ---------- | ----------------- |
| 2013-10-01 | 0.33              |
| 2013-10-02 | 0.00              |
| 2013-10-03 | 0.50              |

Test Cases
{"headers": {"Trips": ["id", "client_id", "driver_id", "city_id", "status", "request_at"], "Users": ["users_id", "banned", "role"]}, "rows": {"Trips": [["1", "1", "10", "1", "completed", "2013-10-01"], ["2", "2", "11", "1", "cancelled_by_driver", "2013-10-01"], ["3", "3", "12", "6", "completed", "2013-10-01"], ["4", "4", "13", "6", "cancelled_by_client", "2013-10-01"], ["5", "1", "10", "1", "completed", "2013-10-02"], ["6", "2", "11", "6", "completed", "2013-10-02"], ["7", "3", "12", "6", "completed", "2013-10-02"], ["8", "2", "12", "12", "completed", "2013-10-03"], ["9", "3", "10", "12", "completed", "2013-10-03"], ["10", "4", "13", "12", "cancelled_by_driver", "2013-10-03"]], "Users": [["1", "No", "client"], ["2", "Yes", "client"], ["3", "No", "client"], ["4", "No", "client"], ["10", "No", "driver"], ["11", "No", "driver"], ["12", "No", "driver"], ["13", "No", "driver"]]}}
*/
