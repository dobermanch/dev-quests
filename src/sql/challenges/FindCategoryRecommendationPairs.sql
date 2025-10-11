
/* https://leetcode.com/problems/find-category-recommendation-pairs */

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
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '201', '3')
insert into ProductPurchases (user_id, product_id, quantity) values ('1', '301', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '101', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '102', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '103', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('2', '201', '5')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '101', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '103', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '301', '4')
insert into ProductPurchases (user_id, product_id, quantity) values ('3', '401', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '101', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '201', '3')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '301', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('4', '401', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '102', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '103', '1')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '201', '2')
insert into ProductPurchases (user_id, product_id, quantity) values ('5', '202', '3')
Truncate table ProductInfo
insert into ProductInfo (product_id, category, price) values ('101', 'Electronics', '100')
insert into ProductInfo (product_id, category, price) values ('102', 'Books', '20')
insert into ProductInfo (product_id, category, price) values ('103', 'Books', '35')
insert into ProductInfo (product_id, category, price) values ('201', 'Clothing', '45')
insert into ProductInfo (product_id, category, price) values ('202', 'Clothing', '60')
insert into ProductInfo (product_id, category, price) values ('301', 'Sports', '75')
insert into ProductInfo (product_id, category, price) values ('401', 'Kitchen', '50')

# Write your MySQL query statement below
WITH joined AS (
    SELECT
        p.*,
        i.category
    FROM ProductPurchases p
    INNER JOIN ProductInfo i ON p.product_id = i.product_id
)

SELECT DISTINCT
    IF(p1.category < p2.category, p1.category, p2.category) AS category1,
    IF(p1.category < p2.category, p2.category, p1.category) AS category2,
    COUNT(DISTINCT p1.user_id) AS customer_count
FROM joined p1
INNER JOIN joined p2 ON p1.user_id = p2.user_id AND p1.product_id != p2.product_id AND p1.category != p2.category
GROUP BY p1.category, p2.category
HAVING COUNT(DISTINCT p1.user_id) >= 3
ORDER BY customer_count DESC, category1 ASC, category2 ASC

/*MSSQL*/
WITH joined AS (
    SELECT
        p.*,
        i.category
    FROM ProductPurchases p
    INNER JOIN ProductInfo i ON p.product_id = i.product_id
)

SELECT DISTINCT
    IIF(p1.category < p2.category, p1.category, p2.category) AS category1,
    IIF(p1.category < p2.category, p2.category, p1.category) AS category2,
    COUNT(DISTINCT p1.user_id) AS customer_count
FROM joined p1
INNER JOIN joined p2 ON p1.user_id = p2.user_id AND p1.product_id != p2.product_id AND p1.category != p2.category
GROUP BY p1.category, p2.category
HAVING COUNT(DISTINCT p1.user_id) >= 3
ORDER BY customer_count DESC, category1 ASC, category2 ASC

/*
Test Cases
{"headers":{"ProductPurchases":["user_id","product_id","quantity"],"ProductInfo":["product_id","category","price"]},"rows":{"ProductPurchases":[[1,101,2],[1,102,1],[1,201,3],[1,301,1],[2,101,1],[2,102,2],[2,103,1],[2,201,5],[3,101,2],[3,103,1],[3,301,4],[3,401,2],[4,101,1],[4,201,3],[4,301,1],[4,401,2],[5,102,2],[5,103,1],[5,201,2],[5,202,3]],"ProductInfo":[[101,"Electronics",100],[102,"Books",20],[103,"Books",35],[201,"Clothing",45],[202,"Clothing",60],[301,"Sports",75],[401,"Kitchen",50]]}}
*/
