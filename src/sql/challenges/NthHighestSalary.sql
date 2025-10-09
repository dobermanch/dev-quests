
/* https://leetcode.com/problems/nth-highest-salary */

/*
Employee
| id | salary |
| -- | ------ |
| 1  | 100    |
| 2  | 200    |
| 3  | 300    |

N=2

Result
| getNthHighestSalary(2) |
| ---------------------- |
| 200                    |

---

Employee
| id | salary |
| -- | ------ |
| 1  | 100    |

N=2

Result
| getNthHighestSalary(2) |
| ---------------------- |
| null                   |

---

Employee
| id | salary |
| -- | ------ |
| 1  | 100    |
| 2  | 100    |

N=1

Result
| getNthHighestSalary(1) |
| ---------------------- |
| 100                    |

---

Employee
| id | salary |
| -- | ------ |
| 1  | 100    |
| 2  | 200    |
| 3  | 300    |

N=-1

Result
| getNthHighestSalary(-1) |
| ----------------------- |
| null                    |

Test Cases
{"headers": {"Employee": ["id", "salary"]}, "argument": 2, "rows": {"Employee": [[1, 100], [2, 200], [3, 300]]}}
{"headers": {"Employee": ["id", "salary"]}, "argument": 2, "rows": {"Employee": [[1, 100]]}}
*/

/* MsSQL */

CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    DECLARE @result INT
    IF @N <= 0
    BEGIN
        SET @result = (SELECT null)
    END
    ELSE
    BEGIN
        SET @result = (
            SELECT
                DISTINCT salary
            FROM Employee
            ORDER BY salary DESC
            OFFSET @N-1 ROWS FETCH NEXT 1 ROWS ONLY
        )
    END

    RETURN @result;
END

/* MySQL */

CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  SET N = N-1;
  RETURN (
    SELECT
        DISTINCT salary
    FROM Employee
    ORDER BY salary DESC
    LIMIT 1 OFFSET N
  );
END
