from ..order_context import OrderContext
from .order_state import OrderState
from .process_payment_state import ProcessPaymentState
from .select_product_state import SelectProductState

class WaitingForMoneyState(OrderState):
    def __init__(self, context: OrderContext):
        super().__init__(context)

    def process(self):
        if self.context.balance <= 0:
            self.context.vm._notify("Please insert money")
            return

        self.context.vm._notify(f"Current balance: {self.context.balance:.2f}")
        if self.context.missing_amount > 0:
            self._next_state(ProcessPaymentState(self.context), True)
        else:
            self._next_state(SelectProductState(self.context))

    def state_info(self):
        if self.context.missing_amount > 0:
            self.context.vm._notify(f"Not enough money, please add '{self.context.missing_amount:.2f}'")
        else:
            self.context.vm._notify("Please insert money")
