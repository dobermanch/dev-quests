
/* https://leetcode.com/problems/odd-and-even-transactions */

Create table if not exists transactions ( transaction_id int, amount int, transaction_date date)
Truncate table transactions
insert into transactions (transaction_id, amount, transaction_date) values ('1', '150', '2024-07-01')
insert into transactions (transaction_id, amount, transaction_date) values ('2', '200', '2024-07-01')
insert into transactions (transaction_id, amount, transaction_date) values ('3', '75', '2024-07-01')
insert into transactions (transaction_id, amount, transaction_date) values ('4', '300', '2024-07-02')
insert into transactions (transaction_id, amount, transaction_date) values ('5', '50', '2024-07-02')
insert into transactions (transaction_id, amount, transaction_date) values ('6', '120', '2024-07-03')

# Write your MySQL, MSSQL, POstgreSQL query statement below

SELECT
    transaction_date,
    SUM(CASE WHEN amount % 2 != 0 THEN amount ELSE 0 END) AS odd_sum,
    SUM(CASE WHEN amount % 2 = 0 THEN amount ELSE 0 END) AS even_sum
FROM transactions
GROUP BY transaction_date
ORDER BY transaction_date

/*
Test Cases
{"headers":{"transactions":["transaction_id","amount","transaction_date"]},"rows":{"transactions":[[1,150,"2024-07-01"],[2,200,"2024-07-01"],[3,75,"2024-07-01"],[4,300,"2024-07-02"],[5,50,"2024-07-02"],[6,120,"2024-07-03"]]}}
*/
