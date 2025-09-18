from pydantic import BaseModel, Field

class AuthorBase(BaseModel):
    name: str = Field(..., example="Robert C. Martin")
    bio: str | None = Field(None, example="Software engineer and author of Clean Code.")

class AuthorCreate(AuthorBase):
    pass

class AuthorUpdate(BaseModel):
    name: str | None
    bio: str | None

class AuthorResponse(AuthorBase):
    id: int
    books: list[int] | None = None  # or nested BookOut if needed
    links: list[dict] | None = None

    class Config:
        orm_mode = True
