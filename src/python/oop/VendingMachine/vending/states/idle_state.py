from ..order_context import OrderContext
from .order_state import OrderState
from .waiting_for_money_state import WaitingForMoneyState


class IdleState(OrderState):

    def __init__(self, vending_machine):
        super().__init__(OrderContext(vending_machine))

    def process(self):
        self._next_state(WaitingForMoneyState(self.context))
