from ..order_context import OrderContext
from .order_state import OrderState
from .select_product_state import SelectProductState
from .dispense_product_state import DispenseProductState

class ProcessPaymentState(OrderState):
    def __init__(self, context: OrderContext):
        super().__init__(context)

    def process(self):
        if not self.context.rack:
            self._next_state(SelectProductState(self.context))
            return

        from .waiting_for_money_state import WaitingForMoneyState
        if self.context.rack.product.price <= 0:
            self._next_state(WaitingForMoneyState(self.context))
            return

        self.context.missing_amount = 0.0
        if self.context.rack.product.price > self.context.balance:
            self.context.missing_amount = self.context.rack.product.price - self.context.balance
            self._next_state(WaitingForMoneyState(self.context))
            return

        self.context.change = self.context.balance - self.context.rack.product.price
        self._next_state(DispenseProductState(self.context))

    def state_info(self):
        self.context.vm._notify("Processing payment...")
