
/* https://leetcode.com/problems/capital-gainloss */

Create Table If Not Exists Stocks (stock_name varchar(15), operation ENUM('Sell', 'Buy'), operation_day int, price int)
Truncate table Stocks
insert into Stocks (stock_name, operation, operation_day, price) values ('Leetcode', 'Buy', '1', '1000')
insert into Stocks (stock_name, operation, operation_day, price) values ('Corona Masks', 'Buy', '2', '10')
insert into Stocks (stock_name, operation, operation_day, price) values ('Leetcode', 'Sell', '5', '9000')
insert into Stocks (stock_name, operation, operation_day, price) values ('Handbags', 'Buy', '17', '30000')
insert into Stocks (stock_name, operation, operation_day, price) values ('Corona Masks', 'Sell', '3', '1010')
insert into Stocks (stock_name, operation, operation_day, price) values ('Corona Masks', 'Buy', '4', '1000')
insert into Stocks (stock_name, operation, operation_day, price) values ('Corona Masks', 'Sell', '5', '500')
insert into Stocks (stock_name, operation, operation_day, price) values ('Corona Masks', 'Buy', '6', '1000')
insert into Stocks (stock_name, operation, operation_day, price) values ('Handbags', 'Sell', '29', '7000')
insert into Stocks (stock_name, operation, operation_day, price) values ('Corona Masks', 'Sell', '10', '10000')

# Write your MySQL, MSSQL query statement below

SELECT
    stock_name,
    SUM(CASE WHEN operation = 'SELL' THEN price END)
    - SUM(CASE WHEN operation = 'BUY' THEN price END) AS capital_gain_loss
FROM Stocks
GROUP BY stock_name
/*
Test Cases
{"headers":{"Stocks":["stock_name","operation","operation_day","price"]},"rows":{"Stocks":[["Leetcode","Buy",1,1000],["Corona Masks","Buy",2,10],["Leetcode","Sell",5,9000],["Handbags","Buy",17,30000],["Corona Masks","Sell",3,1010],["Corona Masks","Buy",4,1000],["Corona Masks","Sell",5,500],["Corona Masks","Buy",6,1000],["Handbags","Sell",29,7000],["Corona Masks","Sell",10,10000]]}}
*/
