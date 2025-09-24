package internal

import (
	"fmt"
	"math/rand"
	"sort"
	"strconv"
	"time"
)

type LockerManager struct {
	lockers      map[LockerSizeType][]*Locker
	sizes        []LockerSize
	lockerToCode map[string]string
	codeToLocker map[string]*Locker
}

func Site(lockerConfig map[LockerSize]int) LockerManager {
	lockers := map[LockerSizeType][]*Locker{}
	sizes := []LockerSize{}

	for size, count := range lockerConfig {
		if _, ok := lockers[size.Type]; !ok {
			lockers[size.Type] = []*Locker{}
			sizes = append(sizes, size)
		}

		for i := range count {
			lockers[size.Type] = append(lockers[size.Type], &Locker{
				Id:   fmt.Sprintf("%d-%d", size.Type, i),
				Size: size})
		}
	}

	sort.Slice(sizes, func(i, j int) bool {
		return sizes[i].Type < sizes[j].Type
	})

	return LockerManager{
		lockers:      lockers,
		sizes:        sizes,
		lockerToCode: map[string]string{},
		codeToLocker: map[string]*Locker{},
	}
}

func (l *LockerManager) AssignLocker(pkg *Package) (*Locker, error) {
	locker := l.findLocker(pkg.Dimensions)
	if locker == nil {
		return nil, fmt.Errorf("locker not found")
	}

	code := l.generateAccessCode()
	locker.AddPackage(code, pkg)

	l.codeToLocker[code] = locker
	l.lockerToCode[locker.Id] = code

	return locker, nil
}

func (l *LockerManager) GetLocker(code string) *Locker {
	if locker, ok := l.codeToLocker[code]; ok {
		return locker
	}

	return nil
}

func (l *LockerManager) ReleaseLocker(locker *Locker) (*Package, error) {
	if _, ok := l.lockerToCode[locker.Id]; !ok {
		return nil, fmt.Errorf("the '%s' locker is already released", locker.Id)
	}

	pkg := locker.pkg
	locker.Release()

	code := l.lockerToCode[locker.Id]
	delete(l.codeToLocker, code)
	delete(l.lockerToCode, locker.Id)

	return pkg, nil
}

func (l *LockerManager) GetExpiredLockers() []*Locker {
	lockers := []*Locker{}

	for _, locker := range l.codeToLocker {
		if locker.IsExpired() {
			lockers = append(lockers, locker)
		}
	}

	return lockers
}

func (l *LockerManager) findLocker(dimensions Dimensions) *Locker {
	for _, size := range l.sizes {
		if size.Dimensions.Width < dimensions.Width ||
			size.Dimensions.Height < dimensions.Height ||
			size.Dimensions.Depth < dimensions.Depth {
			continue
		}

		for _, locker := range l.lockers[size.Type] {
			if locker.IsAssigned() {
				continue
			}

			return locker
		}
	}

	return nil
}

func (l *LockerManager) generateAccessCode() string {
	random := rand.New(rand.NewSource(time.Now().UnixNano()))
	var result string
	for i := 0; i < 7; i++ {
		d := random.Intn(10)
		result += strconv.Itoa(d)
	}

	return result
}
