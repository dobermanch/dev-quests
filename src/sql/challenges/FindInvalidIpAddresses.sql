
/* https://leetcode.com/problems/find-invalid-ip-addresses */

CREATE TABLE logs (
    log_id INT,
    ip VARCHAR(255),
    status_code INT
)

Truncate table logs
insert into logs (log_id, ip, status_code) values ('1', '192.168.1.1', '200')
insert into logs (log_id, ip, status_code) values ('2', '256.1.2.3', '404')
insert into logs (log_id, ip, status_code) values ('3', '192.168.001.1', '200')
insert into logs (log_id, ip, status_code) values ('4', '192.168.1.1', '200')
insert into logs (log_id, ip, status_code) values ('5', '192.168.1', '500')
insert into logs (log_id, ip, status_code) values ('6', '256.1.2.3', '404')
insert into logs (log_id, ip, status_code) values ('7', '192.168.001.1', '200')

# Write your MSSQL query statement below

SELECT
    s.ip,
    COUNT(*) AS invalid_count
FROM (
    SELECT
        s.ip
    FROM (
        SELECT
            l.*,
            CASE WHEN LEFT(s.value, 1) = '0' OR  CAST(s.value AS INT) > 255 THEN NULL ELSE s.value END AS octet,
            ROW_NUMBER() OVER (PARTITION BY log_id, ip ORDER BY ip) AS number
        FROM logs l
        CROSS APPLY STRING_SPLIT(l.ip, '.') s
    ) s
    GROUP BY s.log_id, s.ip
    HAVING COUNT(*) != 4 OR SUM(CASE WHEN s.octet IS NOT NULL THEN 1 ELSE 0 END) != 4
) s
GROUP BY s.ip
ORDER BY invalid_count DESC, s.ip DESC

---

SELECT
    ip,
    COUNT(*) AS invalid_count
FROM logs
WHERE (
    SELECT
        CASE
            WHEN COUNT(value) != 4 THEN 0
            ELSE COUNT(value) - COUNT(CASE WHEN LEFT(value, 1) = '0' OR CAST(value AS INT) > 255 THEN 1 END)
        END
    FROM STRING_SPLIT(ip, '.')
) != 4
GROUP BY ip
ORDER BY invalid_count DESC, ip DESC

/*
Test Cases
{"headers":{"logs":["log_id","ip","status_code"]},"rows":{"logs":[[1,"192.168.1.1",200],[2,"256.1.2.3",404],[3,"192.168.001.1",200],[4,"192.168.1.1",200],[5,"192.168.1",500],[6,"256.1.2.3",404],[7,"192.168.001.1",200]]}}
*/
