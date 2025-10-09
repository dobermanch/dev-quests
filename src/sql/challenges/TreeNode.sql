
/* https://leetcode.com/problems/tree-node */
Create table If Not Exists Tree (id int, p_id int)
Truncate table Tree
insert into Tree (id, p_id) values ('1', NULL)
insert into Tree (id, p_id) values ('2', '1')
insert into Tree (id, p_id) values ('3', '1')
insert into Tree (id, p_id) values ('4', '2')
insert into Tree (id, p_id) values ('5', '2')

# Write your MySQL, MsSQL query statement below
SELECT
    DISTINCT t1.id,
    (CASE
        WHEN t1.p_id IS NULL THEN 'Root'
        WHEN t2.id IS NOT NULL THEN 'Inner'
        WHEN t2.id IS NULL THEN 'Leaf'
    END) AS 'type'
FROM Tree t1
LEFT JOIN Tree t2 ON t1.id = t2.p_id

/* PostgreSQL */
SELECT
    DISTINCT t1.id,
    (CASE
        WHEN t1.p_id IS NULL THEN 'Root'
        WHEN t2.id IS NOT NULL THEN 'Inner'
        WHEN t2.id IS NULL THEN 'Leaf'
    END) AS type
FROM Tree t1
LEFT JOIN Tree t2 ON t1.id = t2.p_id

/*

Input:
Tree table:
| id | p_id |
| -- | ---- |
| 1  | null |
| 2  | 1    |
| 3  | 1    |
| 4  | 2    |
| 5  | 2    |

Output:
| id | type  |
| -- | ----- |
| 1  | Root  |
| 2  | Inner |
| 3  | Leaf  |
| 4  | Leaf  |
| 5  | Leaf  |

Test Cases
{"headers":{"Tree":["id","p_id"]},"rows":{"Tree":[[1,null],[2,1],[3,1],[4,2],[5,2]]}}
{"headers":{"Tree":["id","p_id"]},"rows":{"Tree":[[1,null]]}}
*/
