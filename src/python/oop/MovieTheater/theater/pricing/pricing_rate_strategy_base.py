from ..ticket import Ticket

class PricingRateStrategyBase:
    def calculate(self, ticket: Ticket, rate: float) -> float:
        pass
