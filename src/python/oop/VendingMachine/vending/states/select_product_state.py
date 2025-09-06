from ..order_context import OrderContext
from .order_state import OrderState


class SelectProductState(OrderState):
    def __init__(self, context: OrderContext):
        super().__init__(context)

    def process(self):
        if not self.context.rack_code:
            self.context.vm._notify("Please select product code")
            return

        try:
            rack = self.context.vm._inventory_manager.get_rack(self.context.rack_code)
            if not rack.is_empty:
                self.context.rack = rack
                self.context.vm._notify(f"Selected rack: {self.context.rack.number}")

                from .process_payment_state import ProcessPaymentState
                self._next_state(ProcessPaymentState(self.context), True)
                return

            self.context.vm._notify("The rack is empty")
        except ValueError as ex:
            self.context.vm._notify(str(ex))

        self.context.vm._notify("Please select product code")

    def state_info(self):
        self.context.vm._notify("Please select product code")
