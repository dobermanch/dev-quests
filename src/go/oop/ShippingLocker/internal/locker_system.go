package internal

import "fmt"

type LockerSystem struct {
	location     string
	notification *Notification
	site         *LockerManager
	calculator   *PriceCalculator
}

func System(location string, lockerConfig map[LockerSize]int) LockerSystem {
	site := Site(lockerConfig)
	return LockerSystem{
		location:     location,
		notification: &Notification{},
		site:         &site,
		calculator:   &PriceCalculator{},
	}
}

func (s *LockerSystem) AddPackage(pkg *Package) (*Locker, error) {
	locker, err := s.site.AssignLocker(pkg)
	if err != nil {
		return nil, err
	}

	pkg.Status = InLocker
	s.notification.PackagePlaced(s.location, locker, *pkg)

	return locker, nil
}

func (s *LockerSystem) GetPackage(code string) (*Package, error) {
	locker := s.site.GetLocker(code)
	if locker == nil {
		return nil, fmt.Errorf("access code not valid")
	}

	price := s.calculator.Calculate(locker)

	pkg, err := s.site.ReleaseLocker(locker)
	if err != nil {
		return nil, err
	}

	pkg.User.BillingAmount += price
	pkg.Status = Delivered

	s.notification.PackageRetrieved(*pkg)

	return pkg, nil
}

func (s *LockerSystem) ReleaseExpiredPackages() {
	lockers := s.site.GetExpiredLockers()

	for _, locker := range lockers {
		price := s.calculator.CalculateExpirationPrice(locker)

		pkg, err := s.site.ReleaseLocker(locker)
		if err != nil {
			fmt.Println(err)
			continue
		}

		pkg.User.BillingAmount += price
		pkg.Status = Expired

		s.notification.PackageExpired(*pkg)
	}
}
