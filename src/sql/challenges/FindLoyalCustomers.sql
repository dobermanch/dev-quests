
/* https://leetcode.com/problems/find-loyal-customers */

CREATE TABLE if not exists customer_transactions (
    transaction_id INT,
    customer_id INT,
    transaction_date DATE,
    amount DECIMAL(10,2),
    transaction_type VARCHAR(20)
)
Truncate table customer_transactions
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('1', '101', '2024-01-05', '150.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('2', '101', '2024-01-15', '200.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('3', '101', '2024-02-10', '180.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('4', '101', '2024-02-20', '250.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('5', '102', '2024-01-10', '100.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('6', '102', '2024-01-12', '120.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('7', '102', '2024-01-15', '80.0', 'refund')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('8', '102', '2024-01-18', '90.0', 'refund')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('9', '102', '2024-02-15', '130.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('10', '103', '2024-01-01', '500.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('11', '103', '2024-01-02', '450.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('12', '103', '2024-01-03', '400.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('13', '104', '2024-01-01', '200.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('14', '104', '2024-02-01', '250.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('15', '104', '2024-02-15', '300.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('16', '104', '2024-03-01', '350.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('17', '104', '2024-03-10', '280.0', 'purchase')
insert into customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) values ('18', '104', '2024-03-15', '100.0', 'refund')

# Write your MySQL query statement below
SELECT
   customer_id
FROM customer_transactions
GROUP BY customer_id
HAVING
    COUNT(*) >= 3
    AND DATEDIFF(MAX(transaction_date), MIN(transaction_date)) >= 30
    AND (1.0 * COUNT(CASE WHEN transaction_type = 'refund' THEN 1 END)) / COUNT(*) < 0.2
ORDER BY customer_id ASC

/* MSSQL */
SELECT
   customer_id
FROM customer_transactions
GROUP BY customer_id
HAVING
    COUNT(*) >= 3
    AND DATEDIFF(DAY, MIN(transaction_date), MAX(transaction_date)) >= 30
    AND (1.0 * COUNT(CASE WHEN transaction_type = 'refund' THEN 1 END)) / COUNT(*) < 0.2
ORDER BY customer_id ASC

/* PostgreSQL */
SELECT
   customer_id
FROM customer_transactions
GROUP BY customer_id
HAVING
    COUNT(*) >= 3
    AND MAX(transaction_date) - MIN(transaction_date) >= 30
    AND (1.0 * COUNT(CASE WHEN transaction_type = 'refund' THEN 1 END)) / COUNT(*) < 0.2
ORDER BY customer_id ASC

/*
Test Cases
{"headers":{"customer_transactions":["transaction_id","customer_id","transaction_date","amount","transaction_type"]},"rows":{"customer_transactions":[[1,101,"2024-01-05",150.00,"purchase"],[2,101,"2024-01-15",200.00,"purchase"],[3,101,"2024-02-10",180.00,"purchase"],[4,101,"2024-02-20",250.00,"purchase"],[5,102,"2024-01-10",100.00,"purchase"],[6,102,"2024-01-12",120.00,"purchase"],[7,102,"2024-01-15",80.00,"refund"],[8,102,"2024-01-18",90.00,"refund"],[9,102,"2024-02-15",130.00,"purchase"],[10,103,"2024-01-01",500.00,"purchase"],[11,103,"2024-01-02",450.00,"purchase"],[12,103,"2024-01-03",400.00,"purchase"],[13,104,"2024-01-01",200.00,"purchase"],[14,104,"2024-02-01",250.00,"purchase"],[15,104,"2024-02-15",300.00,"purchase"],[16,104,"2024-03-01",350.00,"purchase"],[17,104,"2024-03-10",280.00,"purchase"],[18,104,"2024-03-15",100.00,"refund"]]}}
*/
