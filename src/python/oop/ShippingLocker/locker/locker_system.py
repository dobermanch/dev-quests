from .locker import *
from .locker_site import LockerSite
from .notification_system import NotificationSystem
from .package import *
from .price_calculator import PriceCalculator

class LockerSystem:
    def __init__(self, location: str, locker_sizes: list[(LockerSize, int)]):
        self._location = location
        self._locker_site = LockerSite(locker_sizes)
        self._notification = NotificationSystem()
        self._price_calculator = PriceCalculator()

    def add_package(self, package: Package) -> Locker:
        locker = self._locker_site.assign_locker(package)
        if not locker:
            print("The suitable locker not found")
            return

        package.status = PackageStatus.IN_LOCKER

        self._notification.package_placed_in_locker(self._location, locker, package)

        return locker

    def get_package(self, access_code: str) -> bool:
        locker = self._locker_site.get_locker(access_code)
        if not locker:
            print("The access code is not valid")
            return False

        package = locker.package
        price = self._price_calculator.calculate_price(locker)
        package.user_account.charge_price(price)
        package.status = PackageStatus.RETRIEVED

        self._notification.package_retrieved(package)

        self._locker_site.release_locker(locker)

        return True

    def release_expired_lockers(self) -> None:
        lockers = self._locker_site.get_expired_lockers()

        for locker in lockers:
            package = locker.package
            price = self._price_calculator.calculate_price(locker)
            package.user_account.charge_price(price)
            package.status = PackageStatus.EXPIRED

            self._notification.package_expired(package)

            self._locker_site.release_locker(locker)
