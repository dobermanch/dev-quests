# main.py
from fastapi import FastAPI
from database import Base, engine
from routers import users, books, authors

app = FastAPI(title="Bookstore API")

Base.metadata.create_all(bind=engine)

app.include_router(users.router)
app.include_router(books.router)
app.include_router(authors.router)

