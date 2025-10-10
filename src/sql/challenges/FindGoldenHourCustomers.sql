
/* https://leetcode.com/problems/find-golden-hour-customers */

CREATE TABLE restaurant_orders (
    order_id INT,
    customer_id INT,
    order_timestamp DATETIME,
    order_amount DECIMAL(10,2),
    payment_method VARCHAR(10),
    order_rating INT
)
Truncate table restaurant_orders
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('1', '101', '2024-03-01 12:30:00', '25.5', 'card', '5')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('2', '101', '2024-03-02 19:15:00', '32.0', 'app', '4')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('3', '101', '2024-03-03 13:45:00', '28.75', 'card', '5')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('4', '101', '2024-03-04 20:30:00', '41.0', 'app', NULL)
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('5', '102', '2024-03-01 11:30:00', '18.5', 'cash', '4')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('6', '102', '2024-03-02 12:00:00', '22.0', 'card', '3')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('7', '102', '2024-03-03 15:30:00', '19.75', 'cash', NULL)
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('8', '103', '2024-03-01 19:00:00', '55.0', 'app', '5')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('9', '103', '2024-03-02 20:45:00', '48.5', 'app', '4')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('10', '103', '2024-03-03 18:30:00', '62.0', 'card', '5')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('11', '104', '2024-03-01 10:00:00', '15.0', 'cash', '3')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('12', '104', '2024-03-02 09:30:00', '18.0', 'cash', '2')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('13', '104', '2024-03-03 16:00:00', '20.0', 'card', '3')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('14', '105', '2024-03-01 12:15:00', '30.0', 'app', '4')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('15', '105', '2024-03-02 13:00:00', '35.5', 'app', '5')
insert into restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) values ('16', '105', '2024-03-03 11:45:00', '28.0', 'card', '4')

# Write your MySQL query statement below
SELECT
    customer_id,
    COUNT(*) AS total_orders,
    ROUND(
        COUNT(
            CASE
                WHEN HOUR(order_timestamp) BETWEEN 11 AND 13 OR HOUR(order_timestamp) BETWEEN 18 AND 20
                THEN 1
            END
        ) / COUNT(*) * 100,
        0
    ) AS peak_hour_percentage,
    ROUND(AVG(order_rating), 2) AS average_rating
FROM restaurant_orders
GROUP BY customer_id
HAVING
    total_orders >= 3
    AND peak_hour_percentage >= 60
    AND average_rating >= 4
    AND (1.0 * COUNT(order_rating)) / COUNT(*) >= 0.5
ORDER BY average_rating DESC, customer_id DESC

/* MSSQL */
WITH customer_stats AS (
  SELECT
    customer_id,
    COUNT(*) AS total_orders,
    COUNT(CASE
      WHEN DATEPART(HOUR, order_timestamp) BETWEEN 11 AND 13
        OR DATEPART(HOUR, order_timestamp) BETWEEN 18 AND 20
      THEN 1
    END) * 100.0 / COUNT(*) AS peak_hour_percentage,
    AVG(CAST(order_rating AS FLOAT)) AS average_rating,
    COUNT(order_rating) * 1.0 / COUNT(*) AS rating_coverage
  FROM restaurant_orders
  GROUP BY customer_id
)
SELECT
  customer_id,
  ROUND(total_orders, 0) AS total_orders,
  ROUND(peak_hour_percentage, 0) AS peak_hour_percentage,
  ROUND(average_rating, 2) AS average_rating
FROM customer_stats
WHERE
  total_orders >= 3
  AND peak_hour_percentage >= 60
  AND average_rating >= 4
  AND rating_coverage >= 0.5
ORDER BY average_rating DESC, customer_id DESC;

/*
Test Cases
{"headers":{"restaurant_orders":["order_id","customer_id","order_timestamp","order_amount","payment_method","order_rating"]},"rows":{"restaurant_orders":[[1,101,"2024-03-01 12:30:00",25.50,"card",5],[2,101,"2024-03-02 19:15:00",32.00,"app",4],[3,101,"2024-03-03 13:45:00",28.75,"card",5],[4,101,"2024-03-04 20:30:00",41.00,"app",null],[5,102,"2024-03-01 11:30:00",18.50,"cash",4],[6,102,"2024-03-02 12:00:00",22.00,"card",3],[7,102,"2024-03-03 15:30:00",19.75,"cash",null],[8,103,"2024-03-01 19:00:00",55.00,"app",5],[9,103,"2024-03-02 20:45:00",48.50,"app",4],[10,103,"2024-03-03 18:30:00",62.00,"card",5],[11,104,"2024-03-01 10:00:00",15.00,"cash",3],[12,104,"2024-03-02 09:30:00",18.00,"cash",2],[13,104,"2024-03-03 16:00:00",20.00,"card",3],[14,105,"2024-03-01 12:15:00",30.00,"app",4],[15,105,"2024-03-02 13:00:00",35.50,"app",5],[16,105,"2024-03-03 11:45:00",28.00,"card",4]]}}
*/
