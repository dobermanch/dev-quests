
/* https://leetcode.com/problems/sales-analysis-iii */

# Write your MySQL, MsSQl, PostgreSQL query statement below

SELECT
    DISTINCT p.product_id,
    p.product_name
FROM Product p
LEFT JOIN Sales s ON p.product_id = s.product_id
WHERE s.sale_date BETWEEN '2019-01-01' AND '2019-03-31' AND p.product_id NOT IN (
    SELECT p.product_id
    FROM Product p
    INNER JOIN Sales s ON p.product_id = s.product_id
    WHERE s.sale_date NOT BETWEEN '2019-01-01' AND '2019-03-31'
)

/*
Input:
Product table:
| product_id | product_name | unit_price |
+------------+--------------+------------+
| 1          | S8           | 1000       |
| 2          | G4           | 800        |
| 3          | iPhone       | 1400       |

Sales table:
| seller_id | product_id | buyer_id | sale_date  | quantity | price |
+-----------+------------+----------+------------+----------+-------+
| 1         | 1          | 1        | 2019-01-21 | 2        | 2000  |
| 1         | 2          | 2        | 2019-02-17 | 1        | 800   |
| 2         | 2          | 3        | 2019-06-02 | 1        | 800   |
| 3         | 3          | 4        | 2019-05-13 | 2        | 2800  |

Output:
| product_id  | product_name |
+-------------+--------------+
| 1           | S8           |

Test Cases
{"headers":{"Product":["product_id","product_name","unit_price"],"Sales":["seller_id","product_id","buyer_id","sale_date","quantity","price"]},"rows":{"Product":[[1,"S8",1000],[2,"G4",800],[3,"iPhone",1400]],"Sales":[[1,1,1,"2019-01-21",2,2000],[1,2,2,"2019-02-17",1,800],[2,2,3,"2019-06-02",1,800],[3,3,4,"2019-05-13",2,2800]]}}
*/
