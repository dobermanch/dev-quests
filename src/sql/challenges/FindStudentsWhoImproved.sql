
/* https://leetcode.com/problems/find-students-who-improved */

CREATE TABLE Scores (
    student_id INT,
    subject VARCHAR(50),
    score INT,
    exam_date VARCHAR(10)
)
Truncate table Scores
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Math', '70', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Math', '85', '2023-02-15')
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Physics', '65', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('101', 'Physics', '60', '2023-02-15')
insert into Scores (student_id, subject, score, exam_date) values ('102', 'Math', '80', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('102', 'Math', '85', '2023-02-15')
insert into Scores (student_id, subject, score, exam_date) values ('103', 'Math', '90', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('104', 'Physics', '75', '2023-01-15')
insert into Scores (student_id, subject, score, exam_date) values ('104', 'Physics', '85', '2023-02-15')

# Write your MySQL, MSSQL, PostgreSQL query statement below

SELECT
    s.student_id,
    s.subject,
    MIN(s.first) as first_score,
    MIN(s.last) as latest_score
FROM (
    SELECT
        student_id,
        subject,
        FIRST_VALUE(score) OVER (PARTITION BY student_id, subject ORDER BY exam_date ASC) first,
        FIRST_VALUE(score) OVER (PARTITION BY student_id, subject ORDER BY exam_date DESC) last
    FROM Scores
) s
WHERE s.first < s.last
GROUP BY s.student_id, s.subject
ORDER BY s.student_id, s.subject

---

SELECT *
FROM (
    SELECT
        s.student_id,
        s.subject,
        MAX(CASE WHEN s.first = 1 THEN s.score END) as first_score,
        MAX(CASE WHEN s.last = 1 THEN s.score END) as latest_score
    FROM (
        SELECT
            *,
            ROW_NUMBER() OVER (PARTITION BY student_id, subject ORDER BY exam_date ASC) first,
            ROW_NUMBER() OVER (PARTITION BY student_id, subject ORDER BY exam_date DESC) last
        FROM Scores
    ) s
    GROUP BY s.student_id, s.subject
) s
WHERE s.first_score < s.latest_score
ORDER BY s.student_id, s.subject


/*
Test Cases
{"headers":{"Scores":["student_id","subject","score","exam_date"]},"rows":{"Scores":[[101,"Math",70,"2023-01-15"],[101,"Math",85,"2023-02-15"],[101,"Physics",65,"2023-01-15"],[101,"Physics",60,"2023-02-15"],[102,"Math",80,"2023-01-15"],[102,"Math",85,"2023-02-15"],[103,"Math",90,"2023-01-15"],[104,"Physics",75,"2023-01-15"],[104,"Physics",85,"2023-02-15"]]}}
*/
