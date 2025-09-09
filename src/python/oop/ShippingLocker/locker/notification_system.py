from .locker import Locker
from .package import Package


class NotificationSystem:
    def package_placed_in_locker(self, site: str, locker: Locker, package: Package):
        print(f"Hello {package.user_account.user_name}!\r\nYou package placed at {site}.\r\nUse '{locker.access_code}' code to get you package.")

    def package_retrieved(self, package: Package):
        print(f"The {package.user_account.user_name} retrieved the package.")

    def package_expired(self, package: Package):
        print(f"Hello {package.user_account.user_name}!\r\nYou package was removed from locker due to expiration date.")
