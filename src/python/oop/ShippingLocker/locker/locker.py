from dataclasses import dataclass
from enum import IntEnum
from datetime import datetime, timedelta

from .dimensions import Dimensions
from .package import Package

class LockerSizeType(IntEnum):
    SMALL = 1
    MEDIUM = 2
    LARGE = 3

@dataclass
class LockerSize:
    type: LockerSizeType
    dimensions: Dimensions

class Locker:
    def __init__(self, id: str, size: LockerSize):
        self.id = id
        self.size = size
        self._package: Package = None
        self._assignment_date: datetime = None
        self._access_code = None

    @property
    def is_assigned(self) -> bool:
        return True if self._assignment_date else False

    @property
    def package(self) -> Package:
        return self._package

    @property
    def access_code(self) -> str:
        return self._access_code

    @property
    def assignment_date(self) -> datetime:
        return self._assignment_date

    def is_expired(self):
        if not self._assignment_date or not self._package:
            return False

        policy = self._package.user_account.locker_policy
        expireDate = self._assignment_date + timedelta(days=policy.max_days_period)
        return datetime.now() > expireDate

    def add_package(self, code: str, package: Package, date: datetime):
        self._access_code = code
        self._package = package
        self._assignment_date = date

    def release_locker(self):
        self._package = None
        self._assignment_date = None
        self._access_code = None
