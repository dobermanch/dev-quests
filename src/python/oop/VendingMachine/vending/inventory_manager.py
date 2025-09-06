from .rack import Rack
from .product import Product


class InventoryManager:
    def __init__(self):
        self._racks_by_number = {}

    def get_rack(self, rack_number: str) -> Rack:
        if rack_number not in self._racks_by_number:
            raise ValueError(f"The '{rack_number}' not found")

        return self._racks_by_number[rack_number]

    def add_product_to_rack(self, rack_number: str, product: Product, count: int) -> bool:
        self._racks_by_number[rack_number] = Rack(rack_number, product, count)

        return True

    def dispense_product_from_rack(self, rack_number: str) -> Product:
        if rack_number not in self._racks_by_number:
            raise ValueError(f"The '{rack_number}' not found")

        rack = self._racks_by_number[rack_number]
        if rack.is_empty:
            raise Exception(f"The '{rack_number}' rack is empty")

        rack.count = rack.count - 1

        return rack.product
