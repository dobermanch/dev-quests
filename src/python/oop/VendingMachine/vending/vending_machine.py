
from .states import *
from .inventory_manager import *
from .product import *

class VendingMachine:
    def __init__(self):
        self._inventory_manager = InventoryManager()
        self._state = IdleState(self)
        self._state.process()

    def add_product(self, rack_number: str, product: Product, count: int) -> None:
        if self._inventory_manager.add_product_to_rack(rack_number, product, count):
            print(f"Added {product.name} to the {rack_number} rack")
        else:
            print(f"Failed add {product.name} to the {rack_number} rack")

    def insert_money(self, amount: float) -> None:
        if not isinstance(self._state, WaitingForMoneyState):
            return

        self._state.context.balance += amount
        self._state.process()

    def select_product(self, code: str) -> None:
        if not isinstance(self._state, SelectProductState):
            return

        self._state.context.rack_code = code
        self._state.process()

    def pickup_change(self) -> None:
        if not isinstance(self._state, ReturnChangeState):
            return

        self._state.process()

    def dispense_product(self) -> None:
        if not isinstance(self._state, DispenseProductState):
            return

        self._state.process()

    def _notify(self, message: str) -> None:
        print(message)
