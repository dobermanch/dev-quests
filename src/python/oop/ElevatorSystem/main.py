from elevator import *

def main():
    floors = [i for i in range(1, 30)]

    elevators = [
        Elevator(f"Elevator 1", floors),
        Elevator(f"Elevator 2", [i for i in floors if i % 2 == 0]),
        Elevator(f"Elevator 3", [i for i in floors if i % 2 != 0])
    ]

    dispatcher = Dispatcher(elevators, DefaultDispatchStrategy())
    system = ElevatorSystem(elevators, dispatcher)

    HoleButtonsPanel(10, system).press_up()
    HoleButtonsPanel(15, system).press_down()
    HoleButtonsPanel(29, system).press_down()
    HoleButtonsPanel(30, system).press_down()
    HoleButtonsPanel(1, system).press_up()

    for status in system.get_statuses():
        print(f"{status.elevator_id}: {status.current_floor} {status.direction.name}")

    elevator = elevators[0]
    buttons = ElevatorButtonsPanel(elevator, system)
    buttons.press_button(15)
    buttons.press_button(30)
    buttons.press_button(17)

    print(elevator._queue)
    while len(elevator._queue) > 0:
        next = elevator._queue[0]
        while elevator._status.current_floor != next:
            print(f"{elevator.id}: {elevator.get_status().current_floor} {elevator.get_status().direction.name}")
            elevator._go_one_floor()

        print(f"{elevator.id}: Stopped at {elevator.get_status().current_floor} {elevator.get_status().direction.name}")
        elevator._go_one_floor()

        if elevator._status.current_floor == 15:
            buttons.press_button(13)
            buttons.press_button(20)
            elevator.add_system_request(16, Direction.UP)
            elevator.add_system_request(12, Direction.UP)
            elevator.add_system_request(11, Direction.DOWN)
            print(elevator._queue)


if __name__ == "__main__":
    main()
