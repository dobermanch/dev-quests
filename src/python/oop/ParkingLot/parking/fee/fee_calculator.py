from .rate_strategy_base import RateStrategyBase
from ..ticket import Ticket

class FeeCalculator:
    def __init__(self, strategies: list[RateStrategyBase]):
        self.__strategies = strategies

    def calculate(self, ticket: Ticket) -> float:
        rate = 0.0
        for strategy in self.__strategies:
            rate = strategy.calculate(ticket, rate)

        duration = ticket.leave_time - ticket.park_time
        hours = duration.total_seconds() / 3600

        hours = hours if hours >= 1 else 1

        return hours * rate
