from .rate_strategy_base import RateStrategyBase
from ..ticket import Ticket
from ..spot_size import SpotSize

class BaseRatesStrategy(RateStrategyBase):
    def calculate(self, ticket: Ticket, current_rate: float) -> float:
        match ticket.parking_spot.size:
            case SpotSize.COMPACT:
                return 1.0
            case SpotSize.NORMAL:
                return 1.5
            case SpotSize.OVERSIZE:
                return 2.0

        return 1.5
