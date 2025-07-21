/* https://leetcode.com/problems/movie-rating */

Create table If Not Exists Movies (movie_id int, title varchar(30))
Create table If Not Exists Users (user_id int, name varchar(30))
Create table If Not Exists MovieRating (movie_id int, user_id int, rating int, created_at date)
Truncate table Movies
insert into Movies (movie_id, title) values ('1', 'Avengers')
insert into Movies (movie_id, title) values ('2', 'Frozen 2')
insert into Movies (movie_id, title) values ('3', 'Joker')
Truncate table Users
insert into Users (user_id, name) values ('1', 'Daniel')
insert into Users (user_id, name) values ('2', 'Monica')
insert into Users (user_id, name) values ('3', 'Maria')
insert into Users (user_id, name) values ('4', 'James')
Truncate table MovieRating
insert into MovieRating (movie_id, user_id, rating, created_at) values ('1', '1', '3', '2020-01-12')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('1', '2', '4', '2020-02-11')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('1', '3', '2', '2020-02-12')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('1', '4', '1', '2020-01-01')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('2', '1', '5', '2020-02-17')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('2', '2', '2', '2020-02-01')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('2', '3', '2', '2020-03-01')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('3', '1', '3', '2020-02-22')
insert into MovieRating (movie_id, user_id, rating, created_at) values ('3', '2', '4', '2020-02-25')

/* Solution MySQL */
(
  SELECT
    u.name AS results
  FROM Users u
  INNER JOIN MovieRating mr ON u.user_id = mr.user_id
  GROUP BY u.user_id
  ORDER BY count(u.user_id) DESC, u.name
  LIMIT 1
)
UNION ALL
(
  SELECT
    m.title AS results
  FROM Movies m
  INNER JOIN MovieRating mr ON m.movie_id = mr.movie_id
  WHERE year(mr.created_at) = 2020 AND month(mr.created_at) = 2
  GROUP BY m.movie_id
  ORDER BY avg(mr.rating * 1.0) DESC, m.title
  LIMIT 1
)

/* Solution T-SQL */
SELECT name AS results
FROM (
  SELECT TOP 1 u.name 
  FROM Users u
  INNER JOIN MovieRating mr ON u.user_id = mr.user_id
  GROUP BY u.user_id, u.name
  ORDER BY count(u.user_id) DESC, u.name
) t
UNION ALL
SELECT title AS results
FROM (
  SELECT TOP 1 m.title
  FROM Movies m
  INNER JOIN MovieRating mr ON m.movie_id = mr.movie_id
  WHERE datediff(month, '2020-02-01', created_at) = 0
  GROUP BY m.movie_id, m.title
  ORDER BY avg(mr.rating * 1.0) DESC, m.title
) t