from .locker_policy import LockerPolicy

class UserAccount:
    def __init__(self, id: str, name: str, policy: LockerPolicy):
        self.account_id = id
        self.user_name = name
        self.locker_policy = policy
        self._billing_amount = 0.0

    def charge_price(self, price: float):
        self._billing_amount += price
