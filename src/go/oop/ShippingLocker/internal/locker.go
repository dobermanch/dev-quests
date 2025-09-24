package internal

import "time"

type LockerSizeType int

const (
	SmallLocker LockerSizeType = iota
	MediumLocker
	LargeLocker
)

type LockerSize struct {
	Type       LockerSizeType
	Dimensions Dimensions
}

type Locker struct {
	Id         string
	Size       LockerSize
	pkg        *Package
	AccessCode *string
	AssignDate *time.Time
}

func (l *Locker) AddPackage(accessCode string, pkg *Package) {
	l.pkg = pkg
	l.AccessCode = &accessCode

	time := time.Now()
	l.AssignDate = &time
}

func (l *Locker) IsAssigned() bool {
	return l.pkg != nil
}

func (l *Locker) Release() {
	l.pkg = nil
	l.AccessCode = nil
	l.AssignDate = nil
}

func (l *Locker) IsExpired() bool {
	if l.AssignDate == nil || l.pkg == nil {
		return false
	}

	expireDate := l.AssignDate.AddDate(0, 0, l.pkg.User.Policy.MaxDaysPeriod)
	return time.Now().After(expireDate)
}
