
/* https://leetcode.com/problems/bank-account-summary-ii */

Create table If Not Exists Users (account int, name varchar(20))
Create table If Not Exists Transactions (trans_id int, account int, amount int, transacted_on date)
Truncate table Users
insert into Users (account, name) values ('900001', 'Alice')
insert into Users (account, name) values ('900002', 'Bob')
insert into Users (account, name) values ('900003', 'Charlie')
Truncate table Transactions
insert into Transactions (trans_id, account, amount, transacted_on) values ('1', '900001', '7000', '2020-08-01')
insert into Transactions (trans_id, account, amount, transacted_on) values ('2', '900001', '7000', '2020-09-01')
insert into Transactions (trans_id, account, amount, transacted_on) values ('3', '900001', '-3000', '2020-09-02')
insert into Transactions (trans_id, account, amount, transacted_on) values ('4', '900002', '1000', '2020-09-12')
insert into Transactions (trans_id, account, amount, transacted_on) values ('5', '900003', '6000', '2020-08-07')
insert into Transactions (trans_id, account, amount, transacted_on) values ('6', '900003', '6000', '2020-09-07')
insert into Transactions (trans_id, account, amount, transacted_on) values ('7', '900003', '-4000', '2020-09-11')

# Write your MySQL query statement below

SELECT
    u.name,
    SUM(t.amount) AS balance
FROM Users u
INNER JOIN Transactions t ON u.account = t.account
GROUP BY u.account, u.name
HAVING balance > 10000


/* MSSQL, PostgreSQL */
SELECT *
FROM (
    SELECT
        u.name,
        SUM(t.amount) AS balance
    FROM Users u
    INNER JOIN Transactions t ON u.account = t.account
    GROUP BY u.account, u.name
) u
WHERE u.balance > 10000

/*
Test Cases
{"headers": {"Users": ["account", "name"], "Transactions": ["trans_id", "account", "amount", "transacted_on"]}, "rows": {"Users": [[900001, "Alice"], [900002, "Bob"], [900003, "Charlie"]], "Transactions": [[1, 900001, 7000, "2020-08-01"], [2, 900001, 7000, "2020-09-01"], [3, 900001, -3000, "2020-09-02"], [4, 900002, 1000, "2020-09-12"], [5, 900003, 6000, "2020-08-07"], [6, 900003, 6000, "2020-09-07"], [7, 900003, -4000, "2020-09-11"]]}}
*/
