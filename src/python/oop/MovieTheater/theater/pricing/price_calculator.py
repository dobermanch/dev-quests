from .pricing_rate_strategy_base import PricingRateStrategyBase
from ..ticket import Ticket

class PriceCalculator:
    def __init__(self, strategies: list[PricingRateStrategyBase]):
        self._strategies = strategies

    def calculate(self, ticket: Ticket) -> float:
        rate: float = 0.0
        for strategy in self._strategies:
            rate = strategy.calculate(ticket, rate)

        return rate
