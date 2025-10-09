
/* https://leetcode.com/problems/first-letter-capitalization-ii */

CREATE TABLE If not exists user_content (
    content_id INT,
    content_text VARCHAR(255)
)
Truncate table user_content
insert into user_content (content_id, content_text) values ('1', 'hello world of SQL')
insert into user_content (content_id, content_text) values ('2', 'the QUICK-brown fox')
insert into user_content (content_id, content_text) values ('3', 'modern-day DATA science')
insert into user_content (content_id, content_text) values ('4', 'web-based FRONT-end development')

# Write your MSSQL query statement below

WITH SplitWords AS (
  SELECT
    u.content_id,
    u.content_text,
    CONCAT(UPPER(SUBSTRING(s.value, 1, 1)), SUBSTRING(LOWER(s.value), 2, LEN(s.value) - 1)) AS word,
    ROW_NUMBER() OVER (PARTITION BY u.content_id ORDER BY u.content_id) AS word_index
  FROM user_content u
  CROSS APPLY STRING_SPLIT(REPLACE(u.content_text, '-', ' - '), ' ') s
)

SELECT
    content_id,
    MIN(content_text) AS original_text,
    REPLACE(
        STRING_AGG(word, ' ') WITHIN GROUP (ORDER BY word_index),
        ' - ',
        '-'
    ) AS converted_text
FROM SplitWords
GROUP BY content_id


/* PostgreSQL */
WITH SplitWords AS (
  SELECT
    u.content_id,
    u.content_text,
    unnest(string_to_array(REPLACE(content_text,'-',' - '), ' ')) as word
  FROM user_content u
)

SELECT
    w.content_id,
    MIN(w.content_text) AS original_text,
    REPLACE(STRING_AGG(word, ' '), ' - ', '-') AS converted_text
FROM (
    SELECT
        content_id,
        content_text,
        CONCAT(UPPER(SUBSTRING(word, 1, 1)), SUBSTRING(LOWER(word), 2, LENGTH(word) - 1)) AS word
    FROM SplitWords
) w
GROUP BY w.content_id
ORDER BY w.content_id

/*
Test Cases
{"headers":{"user_content":["content_id","content_text"]},"rows":{"user_content":[[1,"hello world of SQL"],[2,"the QUICK-brown fox"],[3,"modern-day DATA science"],[4,"web-based FRONT-end development"]]}}
*/
