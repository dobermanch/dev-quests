from locker import *

def main():
    policy = LockerPolicy(10, 15)
    account = UserAccount("1", "John Doe", policy)
    package = Package(account, "order 1", Dimensions(6.0, 10.0, 10.0), PackageStatus.CREATED)

    small = LockerSize(LockerSizeType.SMALL, Dimensions(5.0, 10.0, 10.0))
    medium = LockerSize(LockerSizeType.MEDIUM, Dimensions(10.0, 20.0, 20.0))
    large = LockerSize(LockerSizeType.LARGE, Dimensions(20.0, 30.0, 30.0))

    system = LockerSite("Address 123", [(small, 20), (medium, 10), (large, 5)])

    system.add_package(package)
    print("Enter access code:", end=" ")
    access_code = input()
    system.get_package(access_code)

if __name__ == "__main__":
    main()
