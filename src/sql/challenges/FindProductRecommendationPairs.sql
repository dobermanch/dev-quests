
/* https://leetcode.com/problems/find-product-recommendation-pairs */

CREATE TABLE if not exists ProductPurchases (
    user_id INT,
    product_id INT,
    quantity INT
)
CREATE TABLE  if not exists ProductInfo (
    product_id INT,
    category VARCHAR(100),
    price DECIMAL(10, 2)
)
Truncate table ProductPurchases
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '101', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '102', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '103', '3')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '101', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '102', '5')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '104', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '101', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '103', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '105', '4')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '101', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '102', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '103', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '104', '3')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '102', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '104', '1')
Truncate table ProductInfo
insert into ProductInfo (product_id, category, price) values ('101', 'Electronics', '100')
insert into ProductInfo (product_id, category, price) values ('102', 'Books', '20')
insert into ProductInfo (product_id, category, price) values ('103', 'Clothing', '35')
insert into ProductInfo (product_id, category, price) values ('104', 'Kitchen', '50')
insert into ProductInfo (product_id, category, price) values ('105', 'Sports', '75')

# Write your MySQL, PostgreSQL query statement below

SELECT
    p.product1_id,
    p.product2_id,
    i1.category AS product1_category,
    i2.category AS product2_category,
    p.customer_count
FROM (
    SELECT DISTINCT
        LEAST(p1.product_id, p2.product_id) as product1_id,
        GREATEST(p1.product_id, p2.product_id) as product2_id,
        COUNT(*) AS customer_count
    FROM ProductPurchases p1
    INNER JOIN ProductPurchases p2 ON p1.user_id = p2.user_id AND p1.product_id != p2.product_id
    GROUP BY p1.product_id, p2.product_id
    HAVING customer_count >= 3
) p
INNER JOIN ProductInfo i1 ON p.product1_id = i1.product_id
INNER JOIN ProductInfo i2 ON p.product2_id = i2.product_id
ORDER BY p.customer_count DESC, p.product1_id ASC, p.product2_id ASC

/* MSSQL */

SELECT
    p.product1_id,
    p.product2_id,
    i1.category AS product1_category,
    i2.category AS product2_category,
    p.customer_count
FROM (
    SELECT DISTINCT
        IIF(p1.product_id < p2.product_id, p1.product_id, p2.product_id) AS product1_id,
        IIF(p1.product_id < p2.product_id, p2.product_id, p1.product_id) AS product2_id,
        COUNT(*) AS customer_count
    FROM ProductPurchases p1
    INNER JOIN ProductPurchases p2 ON p1.user_id = p2.user_id AND p1.product_id != p2.product_id
    GROUP BY p1.product_id, p2.product_id
    HAVING COUNT(*) >= 3
) p
INNER JOIN ProductInfo i1 ON p.product1_id = i1.product_id
INNER JOIN ProductInfo i2 ON p.product2_id = i2.product_id
ORDER BY p.customer_count DESC, p.product1_id ASC, p.product2_id ASC

/*
Test Cases
{"headers":{"ProductPurchases":["user_id","product_id","quantity"],"ProductInfo":["product_id","category","price"]},"rows":{"ProductPurchases":[[1,101,2],[1,102,1],[1,103,3],[2,101,1],[2,102,5],[2,104,1],[3,101,2],[3,103,1],[3,105,4],[4,101,1],[4,102,1],[4,103,2],[4,104,3],[5,102,2],[5,104,1]],"ProductInfo":[[101,"Electronics",100],[102,"Books",20],[103,"Clothing",35],[104,"Kitchen",50],[105,"Sports",75]]}}
*/
