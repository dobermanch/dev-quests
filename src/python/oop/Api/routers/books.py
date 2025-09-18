# routers/books.py
from fastapi import APIRouter, Depends, HTTPException, Query
from sqlalchemy.orm import Session
from typing import List
from models.book import Book
from schemas.book import BookCreate, BookResponse, BookUpdate
from database import get_db

router = APIRouter(prefix="/books", tags=["Books"])

@router.get("/", response_model=List[BookResponse])
def list_books(
    db: Session = Depends(get_db),
    page: int = Query(1, ge=1),
    limit: int = Query(10, le=100),
    sort: str | None = Query(None),
):
    offset = (page - 1) * limit
    query = db.query(Book).offset(offset).limit(limit)
    books = query.all()
    return [
        BookResponse(**book.__dict__, links=generate_book_links(book.id))
        for book in books
    ]

@router.post("/", response_model=BookResponse, status_code=201)
def create_book(book: BookCreate, db: Session = Depends(get_db)):
    db_book = Book(**book.dict())
    db.add(db_book)
    db.commit()
    db.refresh(db_book)
    return BookResponse(**db_book.__dict__, links=generate_book_links(db_book.id))

@router.get("/{book_id}", response_model=BookResponse)
def get_book(book_id: int, db: Session = Depends(get_db)):
    book = db.query(Book).filter(Book.id == book_id).first()
    if not book:
        raise HTTPException(status_code=404, detail="Book not found")
    return BookResponse(**book.__dict__, links=generate_book_links(book.id))

@router.put("/{book_id}", response_model=BookResponse)
def update_book(book_id: int, update: BookUpdate, db: Session = Depends(get_db)):
    book = db.query(Book).filter(Book.id == book_id).first()
    if not book:
        raise HTTPException(status_code=404, detail="Book not found")
    for key, value in update.dict(exclude_unset=True).items():
        setattr(book, key, value)
    db.commit()
    db.refresh(book)
    return BookResponse(**book.__dict__, links=generate_book_links(book.id))

@router.delete("/{book_id}", status_code=204)
def delete_book(book_id: int, db: Session = Depends(get_db)):
    book = db.query(Book).filter(Book.id == book_id).first()
    if not book:
        raise HTTPException(status_code=404, detail="Book not found")
    db.delete(book)
    db.commit()

def generate_book_links(book_id: int) -> list:
    return [
        {"rel": "self", "href": f"/books/{book_id}"},
        {"rel": "reviews", "href": f"/books/{book_id}/reviews"},
        {"rel": "author", "href": f"/authors/{book_id}"}
    ]
