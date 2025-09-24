package internal

import "fmt"

type Notification struct{}

func (Notification) PackagePlaced(site string, locker *Locker, pkg Package) {
	fmt.Printf("Hello %s!\r\nYou package placed at %s.\r\nUse '%s' code to get you package.", pkg.User.Name, site, *locker.AccessCode)
}

func (Notification) PackageRetrieved(pkg Package) {
	fmt.Printf("The %s retrieved the package.", pkg.User.Name)
}

func (Notification) PackageExpired(pkg Package) {
	fmt.Printf("Hello %s!\r\nYou package was removed from locker due to expiration date.", pkg.User.Name)
}
