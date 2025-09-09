from dataclasses import dataclass

@dataclass
class LockerPolicy:
    free_days_period: int
    max_days_period: int
