/* https://leetcode.com/problems/count-salary-categories/ */

Create table If Not Exists Accounts (account_id int, income int)
Truncate table Accounts
insert into Accounts (account_id, income) values ('3', '108939')
insert into Accounts (account_id, income) values ('2', '12747')
insert into Accounts (account_id, income) values ('8', '87709')
insert into Accounts (account_id, income) values ('6', '91796')

/* Solution */
SELECT
  c.category,
  count(a.category) AS accounts_count
FROM (
  SELECT 'Low Salary' AS category
  UNION SELECT 'Average Salary'
  UNION SELECT 'High Salary'
) c
LEFT JOIN (
    SELECT
      CASE
        WHEN income < 20000 THEN 'Low Salary'
        WHEN income > 50000 THEN 'High Salary'
        ELSE 'Average Salary'
      END AS category
    FROM Accounts
  ) a ON c.category = a.category
GROUP BY c.category