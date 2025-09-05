from .rate_strategy_base import RateStrategyBase
from ..ticket import Ticket

class HourlyRateStrategy(RateStrategyBase):
    __PEAK_HOUR_RATE_MULTIPLIER = 1.5

    def calculate(self, ticket: Ticket, current_rate: float) -> float:
        hour = ticket.park_time.hour
        if (hour >= 7 and hour <= 10) or (hour >= 16 and hour <= 19):
            return current_rate * self.__PEAK_HOUR_RATE_MULTIPLIER

        return current_rate