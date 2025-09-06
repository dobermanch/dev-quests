from ..order_context import OrderContext
from .order_state import OrderState
from .return_change_state import ReturnChangeState
from .select_product_state import SelectProductState


class DispenseProductState(OrderState):
    def __init__(self, context: OrderContext):
        super().__init__(context)

    def process(self):
        try:
            self.context.vm._inventory_manager.dispense_product_from_rack(self.context.rack.number)
            self._next_state(ReturnChangeState(self.context))
        except Exception as ex:
            self.context.vm._notify(str(ex))
            self._next_state(SelectProductState(self.context))

    def state_info(self):
        self.context.vm._notify(f"Peak up the product: '{self.context.rack.product.name}'")
