from ..order_context import OrderContext
from .order_state import OrderState

class ReturnChangeState(OrderState):
    def __init__(self, context: OrderContext):
        super().__init__(context)

    def process(self):
        self.context._change = 0.0
        from .complete_order_state import CompleteOrderState
        self._next_state(CompleteOrderState(self.context), True)

    def state_info(self):
        if self.context.change <= 0:
            from .complete_order_state import CompleteOrderState
            self._next_state(CompleteOrderState(self.context), True)
            return

        self.context.vm._notify(f"Please peak up the change: '{self.context.change:.2f}'")
