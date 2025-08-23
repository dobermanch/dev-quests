/* https://leetcode.com/problems/product-price-at-a-given-date/ */

Create table If Not Exists Products (product_id int, new_price int, change_date date)
Truncate table Products
insert into Products (product_id, new_price, change_date) values ('1', '20', '2019-08-14')
insert into Products (product_id, new_price, change_date) values ('2', '50', '2019-08-14')
insert into Products (product_id, new_price, change_date) values ('1', '30', '2019-08-15')
insert into Products (product_id, new_price, change_date) values ('1', '35', '2019-08-16')
insert into Products (product_id, new_price, change_date) values ('2', '65', '2019-08-17')
insert into Products (product_id, new_price, change_date) values ('3', '20', '2019-08-18')

/* Solution MySQL */
SELECT
  DISTINCT p1.product_id,
  ifnull(p2.price, 10) AS price
FROM Products p1
LEFT JOIN (
    SELECT
      product_id,
      first_value(new_price) OVER(PARTITION BY product_id ORDER BY change_date DESC) AS price
    FROM Products
    WHERE change_date <= '2019-08-16'
  ) p2 
  ON p1.product_id = p2.product_id

/* Solution T-SQL */
SELECT
  DISTINCT p1.product_id,
  isnull(p2.price, 10) AS price
FROM Products p1
LEFT JOIN (
    SELECT
      product_id,
      first_value(new_price) OVER(PARTITION BY product_id ORDER BY change_date DESC) AS price
    FROM Products
    WHERE change_date <= '2019-08-16'
  ) p2 
  ON p1.product_id = p2.product_id