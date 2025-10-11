
/* https://leetcode.com/problems/seasonal-sales-analysis */

CREATE TABLE if not exists products (
    product_id INT,
    product_name VARCHAR(255),
    category VARCHAR(50)
)
CREATE TABLE if not exists sales (
    sale_id INT,
    product_id INT,
    sale_date DATE,
    quantity INT,
    price DECIMAL(10, 2)
)
Truncate table sales
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('1', '1', '2023-01-15', '5', '10.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('2', '2', '2023-01-20', '4', '15.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('3', '3', '2023-03-10', '3', '18.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('4', '4', '2023-04-05', '1', '20.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('5', '1', '2023-05-20', '2', '10.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('6', '2', '2023-06-12', '4', '15.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('7', '5', '2023-06-15', '5', '12.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('8', '3', '2023-07-24', '2', '18.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('9', '4', '2023-08-01', '5', '20.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('10', '5', '2023-09-03', '3', '12.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('11', '1', '2023-09-25', '6', '10.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('12', '2', '2023-11-10', '4', '15.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('13', '3', '2023-12-05', '6', '18.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('14', '4', '2023-12-22', '3', '20.0')
insert into sales (sale_id, product_id, sale_date, quantity, price) values ('15', '5', '2024-02-14', '2', '12.0')
Truncate table products
insert into products (product_id, product_name, category) values ('1', 'Warm Jacket', 'Apparel')
insert into products (product_id, product_name, category) values ('2', 'Designer Jeans', 'Apparel')
insert into products (product_id, product_name, category) values ('3', 'Cutting Board', 'Kitchen')
insert into products (product_id, product_name, category) values ('4', 'Smart Speaker', 'Tech')
insert into products (product_id, product_name, category) values ('5', 'Yoga Mat', 'Fitness')

# Write your MySQL query statement below
WITH sales_info AS (
    SELECT
        s.product_id,
        p.category,
        (
            CASE
                WHEN MONTH(sale_date) IN (12, 1, 2) THEN 'Winter'
                WHEN MONTH(sale_date) IN (3, 4, 5) THEN 'Spring'
                WHEN MONTH(sale_date) IN (6, 7, 8) THEN 'Summer'
                WHEN MONTH(sale_date) IN (9, 10, 11) THEN 'Fall'
            END
        )
        AS season,
        s.quantity,
        s.quantity * price AS revenue
    FROM sales s
    INNER JOIN products p ON s.product_id = p.product_id
)

SELECT *
FROM (
    SELECT
        season,
        category,
        SUM(quantity) AS total_quantity,
        SUM(revenue) AS total_revenue
    FROM sales_info
    GROUP BY category, season
    ORDER BY season ASC, total_quantity DESC, total_revenue DESC
) s
GROUP BY season


/* MSSQL */
WITH sales_info AS (
    SELECT
        s.product_id,
        p.category,
        (
            CASE
                WHEN DATEPART(MONTH, sale_date) IN (12, 1, 2) THEN 'Winter'
                WHEN DATEPART(MONTH, sale_date) IN (3, 4, 5) THEN 'Spring'
                WHEN DATEPART(MONTH, sale_date) IN (6, 7, 8) THEN 'Summer'
                WHEN DATEPART(MONTH, sale_date) IN (9, 10, 11) THEN 'Fall'
            END
        )
        AS season,
        s.quantity,
        s.quantity * price AS revenue
    FROM sales s
    INNER JOIN products p ON s.product_id = p.product_id
)

SELECT
    season,
    category,
    total_quantity,
    total_revenue
FROM (
    SELECT
        *,
        ROW_NUMBER() OVER (PARTITION BY season ORDER BY total_quantity DESC, total_revenue DESC) AS 'row'
    FROM (
        SELECT
            season,
            category,
            SUM(quantity) AS total_quantity,
            SUM(revenue) AS total_revenue
        FROM sales_info
        GROUP BY category, season
    ) s
)s
WHERE row = 1

/*
Test Cases
{"headers":{"sales":["sale_id","product_id","sale_date","quantity","price"],"products":["product_id","product_name","category"]},"rows":{"sales":[[1,1,"2023-01-15",5,10.00],[2,2,"2023-01-20",4,15.00],[3,3,"2023-03-10",3,18.00],[4,4,"2023-04-05",1,20.00],[5,1,"2023-05-20",2,10.00],[6,2,"2023-06-12",4,15.00],[7,5,"2023-06-15",5,12.00],[8,3,"2023-07-24",2,18.00],[9,4,"2023-08-01",5,20.00],[10,5,"2023-09-03",3,12.00],[11,1,"2023-09-25",6,10.00],[12,2,"2023-11-10",4,15.00],[13,3,"2023-12-05",6,18.00],[14,4,"2023-12-22",3,20.00],[15,5,"2024-02-14",2,12.00]],"products":[[1,"Warm Jacket","Apparel"],[2,"Designer Jeans","Apparel"],[3,"Cutting Board","Kitchen"],[4,"Smart Speaker","Tech"],[5,"Yoga Mat","Fitness"]]}}
*/
