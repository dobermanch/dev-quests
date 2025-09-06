from ..order_context import OrderContext
from abc import ABC, abstractmethod


class OrderState(ABC):
    def __init__(self, context: OrderContext):
        self.context = context

    @abstractmethod
    def process(self):
        pass

    def state_info(self):
        pass

    def _next_state(self, state, execute: bool = False):
        self.context.vm._state = state
        state.state_info()
        if execute:
            self.context.vm._state.process()
