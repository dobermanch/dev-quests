from fastapi import APIRouter, Depends, HTTPException
from sqlalchemy.orm import Session
from typing import List
from models.author import Author
from schemas.author import AuthorCreate, AuthorResponse, AuthorUpdate
from database import get_db

router = APIRouter(prefix="/authors", tags=["Authors"])

@router.get("/", response_model=List[AuthorResponse])
def list_authors(db: Session = Depends(get_db)):
    authors = db.query(Author).all()
    return [
        AuthorResponse(
            **author.__dict__,
            books=[book.id for book in author.books],
            links=generate_author_links(author.id)
        )
        for author in authors
    ]

@router.post("/", response_model=AuthorResponse, status_code=201)
def create_author(author: AuthorCreate, db: Session = Depends(get_db)):
    db_author = Author(**author.dict())
    db.add(db_author)
    db.commit()
    db.refresh(db_author)
    return AuthorResponse(**db_author.__dict__, links=generate_author_links(db_author.id))

@router.get("/{author_id}", response_model=AuthorResponse)
def get_author(author_id: int, db: Session = Depends(get_db)):
    author = db.query(Author).filter(Author.id == author_id).first()
    if not author:
        raise HTTPException(status_code=404, detail="Author not found")
    return AuthorResponse(
        **author.__dict__,
        books=[book.id for book in author.books],
        links=generate_author_links(author.id)
    )

@router.put("/{author_id}", response_model=AuthorResponse)
def update_author(author_id: int, update: AuthorUpdate, db: Session = Depends(get_db)):
    author = db.query(Author).filter(Author.id == author_id).first()
    if not author:
        raise HTTPException(status_code=404, detail="Author not found")
    for key, value in update.dict(exclude_unset=True).items():
        setattr(author, key, value)
    db.commit()
    db.refresh(author)
    return AuthorResponse(**author.__dict__, links=generate_author_links(author.id))

@router.delete("/{author_id}", status_code=204)
def delete_author(author_id: int, db: Session = Depends(get_db)):
    author = db.query(Author).filter(Author.id == author_id).first()
    if not author:
        raise HTTPException(status_code=404, detail="Author not found")
    db.delete(author)
    db.commit()

def generate_author_links(author_id: int) -> list:
    return [
        {"rel": "self", "href": f"/authors/{author_id}"},
        {"rel": "books", "href": f"/books?author_id={author_id}"}
    ]
