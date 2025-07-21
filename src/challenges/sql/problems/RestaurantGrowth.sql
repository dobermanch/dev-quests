/* https://leetcode.com/problems/restaurant-growth/ */

Create table If Not Exists Customer (customer_id int, name varchar(20), visited_on date, amount int)
Truncate table Customer
insert into Customer (customer_id, name, visited_on, amount) values ('1', 'Jhon', '2019-01-01', '100')
insert into Customer (customer_id, name, visited_on, amount) values ('2', 'Daniel', '2019-01-02', '110')
insert into Customer (customer_id, name, visited_on, amount) values ('3', 'Jade', '2019-01-03', '120')
insert into Customer (customer_id, name, visited_on, amount) values ('4', 'Khaled', '2019-01-04', '130')
insert into Customer (customer_id, name, visited_on, amount) values ('5', 'Winston', '2019-01-05', '110')
insert into Customer (customer_id, name, visited_on, amount) values ('6', 'Elvis', '2019-01-06', '140')
insert into Customer (customer_id, name, visited_on, amount) values ('7', 'Anna', '2019-01-07', '150')
insert into Customer (customer_id, name, visited_on, amount) values ('8', 'Maria', '2019-01-08', '80')
insert into Customer (customer_id, name, visited_on, amount) values ('9', 'Jaze', '2019-01-09', '110')
insert into Customer (customer_id, name, visited_on, amount) values ('1', 'Jhon', '2019-01-10', '130')
insert into Customer (customer_id, name, visited_on, amount) values ('3', 'Jade', '2019-01-10', '150')

/* Solution MySQL*/
SELECT
    visited_on,
    amount,
    round(amount / 7, 2) AS average_amount
FROM (
    SELECT 
        DISTINCT visited_on,
        sum(amount) OVER (ORDER BY visited_on RANGE BETWEEN INTERVAL 6 DAY PRECEDING AND CURRENT ROW) AS 'amount'
    FROM Customer
) c
WHERE visited_on >= (
        SELECT adddate(visited_on, INTERVAL 6 DAY) 
        FROM Customer 
        ORDER BY visited_on 
        LIMIT 1
    )

/* Solution T-SQL */
SELECT
    DISTINCT c2.visited_on,
    c2.amount,
    round(c2.amount / 7.0, 2) AS average_amount
FROM Customer c1
CROSS APPLY (
    SELECT 
        max(visited_on) as visited_on,
        sum(amount) As amount
    FROM Customer
    WHERE visited_on BETWEEN dateadd(day, -6, c1.visited_on) AND c1.visited_on
) c2
WHERE c2.visited_on >= (
        SELECT TOP 1 dateadd(day, 6, visited_on)
        FROM Customer
    )