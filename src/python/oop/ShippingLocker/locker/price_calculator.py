from datetime import datetime, timedelta

from .locker import *

class PriceCalculator:
    def calculate_price(self, locker: Locker) -> float:
        policy = locker.package.user_account.locker_policy

        free_date = locker.assignment_date + timedelta(days=policy.free_days_period)
        if datetime.now() <= free_date:
            return 0.0

        match locker.size.type:
            case LockerSizeType.SMALL:
                return 1
            case LockerSizeType.MEDIUM:
                return 2
            case LockerSizeType.LARGE:
                return 3

    def calculate_expiration_price(self, locker: Locker) -> float:
        price = self.calculate_price(locker)
        expiration_rate = 1.0

        return price * expiration_rate
