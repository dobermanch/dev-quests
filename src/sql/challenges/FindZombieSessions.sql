
/* https://leetcode.com/problems/find-zombie-sessions */

CREATE TABLE app_events (
    event_id INT,
    user_id INT,
    event_timestamp DATETIME,
    event_type VARCHAR(20),
    session_id VARCHAR(10),
    event_value INT
)
Truncate table app_events
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('1', '201', '2024-03-01 10:00:00', 'app_open', 'S001', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('2', '201', '2024-03-01 10:05:00', 'scroll', 'S001', '500')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('3', '201', '2024-03-01 10:10:00', 'scroll', 'S001', '750')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('4', '201', '2024-03-01 10:15:00', 'scroll', 'S001', '600')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('5', '201', '2024-03-01 10:20:00', 'scroll', 'S001', '800')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('6', '201', '2024-03-01 10:25:00', 'scroll', 'S001', '550')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('7', '201', '2024-03-01 10:30:00', 'scroll', 'S001', '900')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('8', '201', '2024-03-01 10:35:00', 'app_close', 'S001', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('9', '202', '2024-03-01 11:00:00', 'app_open', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('10', '202', '2024-03-01 11:02:00', 'click', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('11', '202', '2024-03-01 11:05:00', 'scroll', 'S002', '400')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('12', '202', '2024-03-01 11:08:00', 'click', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('13', '202', '2024-03-01 11:10:00', 'scroll', 'S002', '350')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('14', '202', '2024-03-01 11:15:00', 'purchase', 'S002', '50')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('15', '202', '2024-03-01 11:20:00', 'app_close', 'S002', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('16', '203', '2024-03-01 12:00:00', 'app_open', 'S003', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('17', '203', '2024-03-01 12:10:00', 'scroll', 'S003', '1000')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('18', '203', '2024-03-01 12:20:00', 'scroll', 'S003', '1200')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('19', '203', '2024-03-01 12:25:00', 'click', 'S003', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('20', '203', '2024-03-01 12:30:00', 'scroll', 'S003', '800')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('21', '203', '2024-03-01 12:40:00', 'scroll', 'S003', '900')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('22', '203', '2024-03-01 12:50:00', 'scroll', 'S003', '1100')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('23', '203', '2024-03-01 13:00:00', 'app_close', 'S003', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('24', '204', '2024-03-01 14:00:00', 'app_open', 'S004', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('25', '204', '2024-03-01 14:05:00', 'scroll', 'S004', '600')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('26', '204', '2024-03-01 14:08:00', 'scroll', 'S004', '700')
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('27', '204', '2024-03-01 14:10:00', 'click', 'S004', NULL)
insert into app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) values ('28', '204', '2024-03-01 14:12:00', 'app_close', 'S004', NULL)

# Write your MySQL query statement below
SELECT
    session_id,
    MIN(user_id) AS user_id,
    TIMESTAMPDIFF(MINUTE, MIN(event_timestamp), MAX(event_timestamp)) AS session_duration_minutes,
    COUNT(CASE WHEN event_type = 'scroll' THEN 1 END) AS scroll_count
FROM app_events
GROUP BY session_id
HAVING
    session_duration_minutes > 30
    AND scroll_count >= 5
    AND COUNT(CASE WHEN event_type = 'purchase' THEN 1 END) = 0
    AND (1.0 * COUNT(CASE WHEN event_type = 'click' THEN 1 END)) / scroll_count < 0.2
ORDER BY scroll_count DESC, session_id ASC

/* MSSQL */
SELECT
    session_id,
    MIN(user_id) AS user_id,
    DATEDIFF(MINUTE, MIN(event_timestamp), MAX(event_timestamp)) AS session_duration_minutes,
    COUNT(CASE WHEN event_type = 'scroll' THEN 1 END) AS scroll_count
FROM app_events
GROUP BY session_id
HAVING
    DATEDIFF(MINUTE, MIN(event_timestamp), MAX(event_timestamp)) > 30
    AND COUNT(CASE WHEN event_type = 'scroll' THEN 1 END) >= 5
    AND COUNT(CASE WHEN event_type = 'purchase' THEN 1 END) = 0
    AND (1.0 * COUNT(CASE WHEN event_type = 'click' THEN 1 END)) / COUNT(CASE WHEN event_type = 'scroll' THEN 1 END) < 0.2
ORDER BY scroll_count DESC, session_id ASC

/*
Test Cases
{"headers":{"app_events":["event_id","user_id","event_timestamp","event_type","session_id","event_value"]},"rows":{"app_events":[[1,201,"2024-03-01 10:00:00","app_open","S001",null],[2,201,"2024-03-01 10:05:00","scroll","S001",500],[3,201,"2024-03-01 10:10:00","scroll","S001",750],[4,201,"2024-03-01 10:15:00","scroll","S001",600],[5,201,"2024-03-01 10:20:00","scroll","S001",800],[6,201,"2024-03-01 10:25:00","scroll","S001",550],[7,201,"2024-03-01 10:30:00","scroll","S001",900],[8,201,"2024-03-01 10:35:00","app_close","S001",null],[9,202,"2024-03-01 11:00:00","app_open","S002",null],[10,202,"2024-03-01 11:02:00","click","S002",null],[11,202,"2024-03-01 11:05:00","scroll","S002",400],[12,202,"2024-03-01 11:08:00","click","S002",null],[13,202,"2024-03-01 11:10:00","scroll","S002",350],[14,202,"2024-03-01 11:15:00","purchase","S002",50],[15,202,"2024-03-01 11:20:00","app_close","S002",null],[16,203,"2024-03-01 12:00:00","app_open","S003",null],[17,203,"2024-03-01 12:10:00","scroll","S003",1000],[18,203,"2024-03-01 12:20:00","scroll","S003",1200],[19,203,"2024-03-01 12:25:00","click","S003",null],[20,203,"2024-03-01 12:30:00","scroll","S003",800],[21,203,"2024-03-01 12:40:00","scroll","S003",900],[22,203,"2024-03-01 12:50:00","scroll","S003",1100],[23,203,"2024-03-01 13:00:00","app_close","S003",null],[24,204,"2024-03-01 14:00:00","app_open","S004",null],[25,204,"2024-03-01 14:05:00","scroll","S004",600],[26,204,"2024-03-01 14:08:00","scroll","S004",700],[27,204,"2024-03-01 14:10:00","click","S004",null],[28,204,"2024-03-01 14:12:00","app_close","S004",null]]}}
*/
