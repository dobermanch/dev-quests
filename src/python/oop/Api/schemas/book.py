from datetime import date
from pydantic import BaseModel, Field

class BookBase(BaseModel):
    title: str = Field(..., description="The book title")
    description: str | None = Field(None, description="The book description")
    price: float = Field(..., gt=0, description="The book price")
    published_date: date | None = Field(None, description="The date when book was published")
    author_id: int = Field(..., description="The book author id")

class BookCreate(BookBase):
    pass

class BookUpdate(BaseModel):
    title: str | None
    description: str | None
    price: float | None
    published_date: date | None

class BookResponse(BookBase):
    id: int
    links: list[dict] | None = None

    class Config:
        orm_mode = True
