from .pricing_rate_strategy_base import PricingRateStrategyBase
from ..person_age import PersonAge
from ..ticket import Ticket

class DefaultPricingRateStrategy(PricingRateStrategyBase):
    def calculate(self, ticket: Ticket, rate: float) -> float:
        match ticket.age:
            case PersonAge.CHILD:
                return 1.0
            case PersonAge.ADULT:
                return 2.0
            case PersonAge.SENIOR:
                return 1.5
        return 2.0
