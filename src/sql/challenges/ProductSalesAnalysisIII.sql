/* https://leetcode.com/problems/product-sales-analysis-iii/ */

Create table If Not Exists Sales (sale_id int, product_id int, year int, quantity int, price int)
Create table If Not Exists Product (product_id int, product_name varchar(10))
Truncate table Sales
insert into Sales (sale_id, product_id, year, quantity, price) values ('1', '100', '2008', '10', '5000')
insert into Sales (sale_id, product_id, year, quantity, price) values ('2', '100', '2009', '12', '5000')
insert into Sales (sale_id, product_id, year, quantity, price) values ('7', '200', '2011', '15', '9000')
Truncate table Product
insert into Product (product_id, product_name) values ('100', 'Nokia')
insert into Product (product_id, product_name) values ('200', 'Apple')
insert into Product (product_id, product_name) values ('300', 'Samsung')

/* Solution 1 */
SELECT
  s.product_id,
  s.year AS first_year,
  s.quantity,
  s.price
FROM (
    SELECT
      *,
      rank() OVER (PARTITION BY product_id ORDER BY year ASC) AS 'rank'
    FROM Sales
  ) s
WHERE s.rank = 1

/* Solution 2 */
SELECT
  s1.product_id,
  s2.first_year,
  s1.quantity,
  s1.price
FROM Sales s1
INNER JOIN (
    SELECT
      product_id,  
      min(year) AS first_year
    FROM Sales
    GROUP BY product_id
  ) s2 ON s1.product_id = s2.product_id AND s1.year = s2.first_year