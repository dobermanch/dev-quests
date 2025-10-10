
/* https://leetcode.com/problems/find-books-with-polarized-opinions */

CREATE TABLE books (
    book_id INT,
    title VARCHAR(255),
    author VARCHAR(255),
    genre VARCHAR(100),
    pages INT
)
CREATE TABLE reading_sessions (
    session_id INT,
    book_id INT,
    reader_name VARCHAR(255),
    pages_read INT,
    session_rating INT
)
Truncate table books
insert into books (book_id, title, author, genre, pages) values ('1', 'The Great Gatsby', 'F. Scott', 'Fiction', '180')
insert into books (book_id, title, author, genre, pages) values ('2', 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', '281')
insert into books (book_id, title, author, genre, pages) values ('3', '1984', 'George Orwell', 'Dystopian', '328')
insert into books (book_id, title, author, genre, pages) values ('4', 'Pride and Prejudice', 'Jane Austen', 'Romance', '432')
insert into books (book_id, title, author, genre, pages) values ('5', 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', '277')
Truncate table reading_sessions
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('1', '1', 'Alice', '50', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('2', '1', 'Bob', '60', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('3', '1', 'Carol', '40', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('4', '1', 'David', '30', '2')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('5', '1', 'Emma', '45', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('6', '2', 'Frank', '80', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('7', '2', 'Grace', '70', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('8', '2', 'Henry', '90', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('9', '2', 'Ivy', '60', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('10', '2', 'Jack', '75', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('11', '3', 'Kate', '100', '2')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('12', '3', 'Liam', '120', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('13', '3', 'Mia', '80', '2')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('14', '3', 'Noah', '90', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('15', '3', 'Olivia', '110', '4')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('16', '3', 'Paul', '95', '5')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('17', '4', 'Quinn', '150', '3')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('18', '4', 'Ruby', '140', '3')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('19', '5', 'Sam', '80', '1')
insert into reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) values ('20', '5', 'Tara', '70', '2')

# Write your MySQL, MSSQL, PostgreSQL query statement below
SELECT
    b.*,
    r.rating_spread,
    r.polarization_score
FROM (
    SELECT
        book_id,
        COUNT(1) AS sessions_count,
        MAX(session_rating) - MIN(session_rating) AS rating_spread,
        ROUND(1.0 * COUNT(CASE WHEN session_rating <= 2 OR session_rating >= 4 THEN 1 END) / COUNT(1), 2) AS polarization_score
    FROM reading_sessions
    GROUP BY book_id
    HAVING COUNT(CASE WHEN session_rating <= 2 THEN 1 END) > 0 AND COUNT(CASE WHEN session_rating >= 4 THEN 1 END) > 0
) r
INNER JOIN books b ON r.book_id = b.book_id AND r.polarization_score >= 0.6 AND sessions_count >= 5
ORDER BY polarization_score DESC, b.title DESC

/*
Test Cases
{"headers":{"books":["book_id","title","author","genre","pages"],"reading_sessions":["session_id","book_id","reader_name","pages_read","session_rating"]},"rows":{"books":[[1,"The Great Gatsby","F. Scott","Fiction",180],[2,"To Kill a Mockingbird","Harper Lee","Fiction",281],[3,"1984","George Orwell","Dystopian",328],[4,"Pride and Prejudice","Jane Austen","Romance",432],[5,"The Catcher in the Rye","J.D. Salinger","Fiction",277]],"reading_sessions":[[1,1,"Alice",50,5],[2,1,"Bob",60,1],[3,1,"Carol",40,4],[4,1,"David",30,2],[5,1,"Emma",45,5],[6,2,"Frank",80,4],[7,2,"Grace",70,4],[8,2,"Henry",90,5],[9,2,"Ivy",60,4],[10,2,"Jack",75,4],[11,3,"Kate",100,2],[12,3,"Liam",120,1],[13,3,"Mia",80,2],[14,3,"Noah",90,1],[15,3,"Olivia",110,4],[16,3,"Paul",95,5],[17,4,"Quinn",150,3],[18,4,"Ruby",140,3],[19,5,"Sam",80,1],[20,5,"Tara",70,2]]}}
*/
