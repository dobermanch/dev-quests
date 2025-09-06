from ..order_context import OrderContext
from .order_state import OrderState
from .idle_state import IdleState


class CompleteOrderState(OrderState):
    def __init__(self, context: OrderContext):
        super().__init__(context)

    def process(self):
        self._next_state(IdleState(self.context.vm), True)

    def state_info(self):
        self.context.vm._notify(f"Thank you for purchase")
