/* https://leetcode.com/problems/invalid-tweets */

Create table If Not Exists Tweets(tweet_id int, content varchar(50))
Truncate table Tweets
insert into Tweets (tweet_id, content) values ('1', 'Vote for Biden')
insert into Tweets (tweet_id, content) values ('2', 'Let us make America great again!')

/* Solution MySQL */
SELECT tweet_id
FROM Tweets
WHERE length(content) > 15

/* Solution T-SQL */
SELECT tweet_id
FROM Tweets
WHERE len(content) > 15