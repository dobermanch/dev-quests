
/* https://leetcode.com/problems/find-consistently-improving-employees */

CREATE TABLE employees (
    employee_id INT,
    name VARCHAR(255)
)
CREATE TABLE performance_reviews (
    review_id INT,
    employee_id INT,
    review_date DATE,
    rating INT
)
Truncate table employees
insert into employees (employee_id, name) values ('1', 'Alice Johnson')
insert into employees (employee_id, name) values ('2', 'Bob Smith')
insert into employees (employee_id, name) values ('3', 'Carol Davis')
insert into employees (employee_id, name) values ('4', 'David Wilson')
insert into employees (employee_id, name) values ('5', 'Emma Brown')
Truncate table performance_reviews
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('1', '1', '2023-01-15', '2')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('2', '1', '2023-04-15', '3')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('3', '1', '2023-07-15', '4')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('4', '1', '2023-10-15', '5')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('5', '2', '2023-02-01', '3')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('6', '2', '2023-05-01', '2')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('7', '2', '2023-08-01', '4')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('8', '2', '2023-11-01', '5')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('9', '3', '2023-03-10', '1')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('10', '3', '2023-06-10', '2')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('11', '3', '2023-09-10', '3')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('12', '3', '2023-12-10', '4')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('13', '4', '2023-01-20', '4')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('14', '4', '2023-04-20', '4')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('15', '4', '2023-07-20', '4')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('16', '5', '2023-02-15', '3')
insert into performance_reviews (review_id, employee_id, review_date, rating) values ('17', '5', '2023-05-15', '2')

# Write your MySQL query statement below
SELECT
    e.employee_id,
    e.name,
    rating - rating3 AS improvement_score
FROM (
    SELECT
        *,
        LEAD(rating) OVER (PARTITION BY employee_id ORDER BY review_date DESC) AS 'rating2',
        LEAD(rating,2) OVER (PARTITION BY employee_id ORDER BY review_date DESC) AS 'rating3',
        DENSE_RANK() OVER (PARTITION BY employee_id ORDER BY review_date DESC) AS 'rank'
    FROM performance_reviews
) p
INNER JOIN employees e ON p.employee_id = e.employee_id
WHERE
    rating2 IS NOT NULL
    AND rating3 IS NOT NULL
    AND rating > rating2
    AND rating2 > rating3
    AND p.rank = 1
ORDER BY improvement_score DESC, e.name ASC

/* PostgreSQL*/
SELECT
    e.employee_id,
    e.name,
    rating - rating3 AS improvement_score
FROM (
    SELECT
        *,
        LEAD(rating) OVER (PARTITION BY employee_id ORDER BY review_date DESC) AS rating2,
        LEAD(rating,2) OVER (PARTITION BY employee_id ORDER BY review_date DESC) AS rating3,
        DENSE_RANK() OVER (PARTITION BY employee_id ORDER BY review_date DESC) AS rank
    FROM performance_reviews
) p
INNER JOIN employees e ON p.employee_id = e.employee_id
WHERE
    rating2 IS NOT NULL
    AND rating3 IS NOT NULL
    AND rating > rating2
    AND rating2 > rating3
    AND p.rank = 1
ORDER BY improvement_score DESC, e.name ASC

/*
Test Cases
{"headers":{"employees":["employee_id","name"],"performance_reviews":["review_id","employee_id","review_date","rating"]},"rows":{"employees":[[1,"Alice Johnson"],[2,"Bob Smith"],[3,"Carol Davis"],[4,"David Wilson"],[5,"Emma Brown"]],"performance_reviews":[[1,1,"2023-01-15",2],[2,1,"2023-04-15",3],[3,1,"2023-07-15",4],[4,1,"2023-10-15",5],[5,2,"2023-02-01",3],[6,2,"2023-05-01",2],[7,2,"2023-08-01",4],[8,2,"2023-11-01",5],[9,3,"2023-03-10",1],[10,3,"2023-06-10",2],[11,3,"2023-09-10",3],[12,3,"2023-12-10",4],[13,4,"2023-01-20",4],[14,4,"2023-04-20",4],[15,4,"2023-07-20",4],[16,5,"2023-02-15",3],[17,5,"2023-05-15",2]]}}
*/
