from datetime import datetime
import random
from .locker import *
from .package import *

class LockerSite:
    def __init__(self, sizes: list[(LockerSize, int)]):
        self._locker_to_code = {}
        self._code_to_lockers = {}
        self._sizes = sorted([size for size, _ in sizes], key=lambda x: x.type)

        self._lockers_by_size = {}
        for size, count in sizes:
            self._lockers_by_size[size.type] = [Locker(f"{size.type.name}-{size}", size) for i in range(count)]

    def assign_locker(self, package: Package) -> Locker:
        locker = self._find_locker(package.dimensions)
        if not locker:
            return None

        access_code = self._generate_access_code()
        locker.add_package(access_code, package, datetime.now())

        self._locker_to_code[locker.id] = access_code
        self._code_to_lockers[access_code] = locker

        return locker

    def get_locker(self, access_code: str) -> Locker:
        if access_code in self._code_to_lockers:
            return self._code_to_lockers[access_code]

        return None

    def release_locker(self, locker: Locker) -> None:
        if locker.id not in self._locker_to_code:
            print(f"The '{locker.id}' locker is already released")
            return

        locker.release_locker()

        code = self._locker_to_code[locker.id]
        del self._locker_to_code[locker.id]
        del self._code_to_lockers[code]

    def get_expired_lockers(self) -> list[Locker]:
        return [locker for locker in self._code_to_lockers.values() if locker.is_expired()]

    def _find_locker(self, dimensions: Dimensions) -> Locker:
        for size in self._sizes:
            if size.dimensions.width < dimensions.width \
               or size.dimensions.height < dimensions.height \
               or size.dimensions.depth < dimensions.depth:
                continue

            for locker in self._lockers_by_size[size.type]:
                if locker.is_assigned:
                    continue

                return locker

        return None

    def _generate_access_code(self) -> str:
        return ''.join(str(random.randint(0, 9)) for _ in range(7))
