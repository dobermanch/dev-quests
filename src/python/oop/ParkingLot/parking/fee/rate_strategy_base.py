from ..ticket import Ticket

class RateStrategyBase:
    # it can be improved by passing start time and end time, then we could calculate rate more accurate
    def calculate(self, ticket: Ticket, current_rate: float) -> float:
        pass
