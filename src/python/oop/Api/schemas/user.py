from pydantic import BaseModel, EmailStr, Field

class UserBase(BaseModel):
    email: EmailStr = Field(..., example="user@example.com")

class UserCreate(UserBase):
    password: str = Field(..., min_length=8, example="strongpassword123")

class UserResponse(UserBase):
    id: int
    is_active: bool
    is_admin: bool

    class Config:
        orm_mode = True

class Token(BaseModel):
    access_token: str
    token_type: str = "bearer"

class TokenData(BaseModel):
    user_id: int
