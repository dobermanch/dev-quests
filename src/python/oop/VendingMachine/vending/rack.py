from .product import Product
from dataclasses import dataclass


@dataclass
class Rack:
    number: str
    product: Product

    def __init__(self, number: str, product: Product, count: int):
        self.number = number
        self.product = product
        self._count = count

    @property
    def count(self):
        return self._count

    @count.setter
    def count(self, value: int):
        self._count = value

    @property
    def is_empty(self):
        return self.count <= 0
