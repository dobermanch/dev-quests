from dataclasses import dataclass
from enum import IntEnum

from .user_account import UserAccount
from .package import *
from .dimensions import Dimensions

class PackageStatus(IntEnum):
    CREATED = 1
    IN_LOCKER = 2
    RETRIEVED = 3
    EXPIRED = 4

@dataclass
class Package:
    user_account: UserAccount
    order_id: str
    dimensions: Dimensions
    status: PackageStatus
