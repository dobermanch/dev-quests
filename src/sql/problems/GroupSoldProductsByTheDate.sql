/* https://leetcode.com/problems/group-sold-products-by-the-date/ */

Create table If Not Exists Activities (sell_date date, product varchar(20))
Truncate table Activities
insert into Activities (sell_date, product) values ('2020-05-30', 'Headphone')
insert into Activities (sell_date, product) values ('2020-06-01', 'Pencil')
insert into Activities (sell_date, product) values ('2020-06-02', 'Mask')
insert into Activities (sell_date, product) values ('2020-05-30', 'Basketball')
insert into Activities (sell_date, product) values ('2020-06-01', 'Bible')
insert into Activities (sell_date, product) values ('2020-06-02', 'Mask')
insert into Activities (sell_date, product) values ('2020-05-30', 'T-Shirt')

/* Solution MySQL */
SELECT 
    sell_date,
    count(DISTINCT product) AS num_sold,
    group_concat(DISTINCT product ORDER BY product SEPARATOR ',') AS products
FROM Activities
GROUP BY sell_date
ORDER BY sell_date

/* Solution T-SQL */
SELECT 
    sell_date,
    count(DISTINCT product) AS num_sold,
    string_agg(product, ',') WITHIN GROUP (ORDER BY product) AS products
FROM (
    SELECT *
    FROM Activities
    GROUP BY sell_date, product
) a
GROUP BY sell_date
ORDER BY sell_date