
/* https://leetcode.com/problems/find-books-with-no-available-copies */

CREATE TABLE library_books (
    book_id INT,
    title VARCHAR(255),
    author VARCHAR(255),
    genre VARCHAR(100),
    publication_year INT,
    total_copies INT
)
CREATE TABLE borrowing_records (
    record_id INT,
    book_id INT,
    borrower_name VARCHAR(255),
    borrow_date DATE,
    return_date DATE
)
Truncate table library_books
insert into library_books (book_id, title, author, genre, publication_year, total_copies) values ('1', 'The Great Gatsby', 'F. Scott', 'Fiction', '1925', '3')
insert into library_books (book_id, title, author, genre, publication_year, total_copies) values ('2', 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', '1960', '3')
insert into library_books (book_id, title, author, genre, publication_year, total_copies) values ('3', '1984', 'George Orwell', 'Dystopian', '1949', '1')
insert into library_books (book_id, title, author, genre, publication_year, total_copies) values ('4', 'Pride and Prejudice', 'Jane Austen', 'Romance', '1813', '2')
insert into library_books (book_id, title, author, genre, publication_year, total_copies) values ('5', 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', '1951', '1')
insert into library_books (book_id, title, author, genre, publication_year, total_copies) values ('6', 'Brave New World', 'Aldous Huxley', 'Dystopian', '1932', '4')
Truncate table borrowing_records
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('1', '1', 'Alice Smith', '2024-01-15', NULL)
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('2', '1', 'Bob Johnson', '2024-01-20', NULL)
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('3', '2', 'Carol White', '2024-01-10', '2024-01-25')
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('4', '3', 'David Brown', '2024-02-01', NULL)
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('5', '4', 'Emma Wilson', '2024-01-05', NULL)
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('6', '5', 'Frank Davis', '2024-01-18', '2024-02-10')
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('7', '1', 'Grace Miller', '2024-02-05', NULL)
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('8', '6', 'Henry Taylor', '2024-01-12', NULL)
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('9', '2', 'Ivan Clark', '2024-02-12', NULL)
insert into borrowing_records (record_id, book_id, borrower_name, borrow_date, return_date) values ('10', '2', 'Jane Adams', '2024-02-15', NULL)

# Write your MySQL, MSSQL, PostgreSQL query statement below
SELECT
    b.book_id,
    b.title,
    b.author,
    b.genre,
    b.publication_year,
    r.current_borrowers
FROM library_books b
INNER JOIN (
    SELECT
        book_id,
        COUNT(book_id) AS current_borrowers
    FROM borrowing_records
    WHERE borrow_date IS NOT NULL AND return_date IS NULL
    GROUP BY book_id
) r ON b.book_id = r.book_id AND b.total_copies = r.current_borrowers
ORDER BY r.current_borrowers DESC, b.title ASC

/*
Test Cases
{"headers":{"library_books":["book_id","title","author","genre","publication_year","total_copies"],"borrowing_records":["record_id","book_id","borrower_name","borrow_date","return_date"]},"rows":{"library_books":[[1,"The Great Gatsby","F. Scott","Fiction",1925,3],[2,"To Kill a Mockingbird","Harper Lee","Fiction",1960,3],[3,"1984","George Orwell","Dystopian",1949,1],[4,"Pride and Prejudice","Jane Austen","Romance",1813,2],[5,"The Catcher in the Rye","J.D. Salinger","Fiction",1951,1],[6,"Brave New World","Aldous Huxley","Dystopian",1932,4]],"borrowing_records":[[1,1,"Alice Smith","2024-01-15",null],[2,1,"Bob Johnson","2024-01-20",null],[3,2,"Carol White","2024-01-10","2024-01-25"],[4,3,"David Brown","2024-02-01",null],[5,4,"Emma Wilson","2024-01-05",null],[6,5,"Frank Davis","2024-01-18","2024-02-10"],[7,1,"Grace Miller","2024-02-05",null],[8,6,"Henry Taylor","2024-01-12",null],[9,2,"Ivan Clark","2024-02-12",null],[10,2,"Jane Adams","2024-02-15",null]]}}
*/
