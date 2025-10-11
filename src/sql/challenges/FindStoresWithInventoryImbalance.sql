
/* https://leetcode.com/problems/find-stores-with-inventory-imbalance */

CREATE TABLE if not exists stores (
    store_id INT,
    store_name VARCHAR(255),
    location VARCHAR(255)
)
CREATE TABLE if not exists inventory (
    inventory_id INT,
    store_id INT,
    product_name VARCHAR(255),
    quantity INT,
    price DECIMAL(10, 2)
)
Truncate table stores
insert into stores (store_id, store_name, location) values ('1', 'Downtown Tech', 'New York')
insert into stores (store_id, store_name, location) values ('2', 'Suburb Mall', 'Chicago')
insert into stores (store_id, store_name, location) values ('3', 'City Center', 'Los Angeles')
insert into stores (store_id, store_name, location) values ('4', 'Corner Shop', 'Miami')
insert into stores (store_id, store_name, location) values ('5', 'Plaza Store', 'Seattle')
Truncate table inventory
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('1', '1', 'Laptop', '5', '999.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('2', '1', 'Mouse', '50', '19.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('3', '1', 'Keyboard', '25', '79.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('4', '1', 'Monitor', '15', '299.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('5', '2', 'Phone', '3', '699.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('6', '2', 'Charger', '100', '25.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('7', '2', 'Case', '75', '15.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('8', '2', 'Headphones', '20', '149.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('9', '3', 'Tablet', '2', '499.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('10', '3', 'Stylus', '80', '29.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('11', '3', 'Cover', '60', '39.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('12', '4', 'Watch', '10', '299.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('13', '4', 'Band', '25', '49.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('14', '5', 'Camera', '8', '599.99')
insert into inventory (inventory_id, store_id, product_name, quantity, price) values ('15', '5', 'Lens', '12', '199.99')

# Write your MySQL, MSSQL, PostgreSQL query statement below

SELECT
    s.store_id,
    s.store_name,
    MIN(s.location) AS location,
    MIN(i.most_exp_product) AS most_exp_product,
    MIN(i.cheapest_product) AS cheapest_product,
    ROUND(1.0 * MIN(i.cheapest_product_quantity) / MIN(i.most_exp_product_quantity), 2) AS imbalance_ratio
FROM (
    SELECT
        store_id,
        FIRST_VALUE(product_name) OVER (PARTITION BY store_id ORDER BY price ASC) AS cheapest_product,
        FIRST_VALUE(price) OVER (PARTITION BY store_id ORDER BY price ASC) AS cheapest_product_price,
        FIRST_VALUE(quantity) OVER (PARTITION BY store_id ORDER BY price ASC) AS cheapest_product_quantity,
        FIRST_VALUE(product_name) OVER (PARTITION BY store_id ORDER BY price DESC) AS most_exp_product,
        FIRST_VALUE(price) OVER (PARTITION BY store_id ORDER BY price DESC) AS most_exp_product_price,
        FIRST_VALUE(quantity) OVER (PARTITION BY store_id ORDER BY price DESC) AS most_exp_product_quantity
    FROM inventory
) i
INNER JOIN stores s ON i.store_id = s.store_id
GROUP BY s.store_id, s.store_name
HAVING COUNT(*) >= 3 AND MIN(i.most_exp_product_quantity) < MIN(i.cheapest_product_quantity)
ORDER BY imbalance_ratio DESC, s.store_name ASC

/*
Test Cases
{"headers":{"stores":["store_id","store_name","location"],"inventory":["inventory_id","store_id","product_name","quantity","price"]},"rows":{"stores":[[1,"Downtown Tech","New York"],[2,"Suburb Mall","Chicago"],[3,"City Center","Los Angeles"],[4,"Corner Shop","Miami"],[5,"Plaza Store","Seattle"]],"inventory":[[1,1,"Laptop",5,999.99],[2,1,"Mouse",50,19.99],[3,1,"Keyboard",25,79.99],[4,1,"Monitor",15,299.99],[5,2,"Phone",3,699.99],[6,2,"Charger",100,25.99],[7,2,"Case",75,15.99],[8,2,"Headphones",20,149.99],[9,3,"Tablet",2,499.99],[10,3,"Stylus",80,29.99],[11,3,"Cover",60,39.99],[12,4,"Watch",10,299.99],[13,4,"Band",25,49.99],[14,5,"Camera",8,599.99],[15,5,"Lens",12,199.99]]}}
*/
