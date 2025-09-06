from .rack import Rack
from dataclasses import dataclass


@dataclass
class OrderContext:
    vm: any
    balance: float
    rack_code: str
    rack: Rack
    missing_amount: float
    change: float

    def __init__(self, machine):
        self.vm = machine
        self.vm._context = self
        self.balance = 0.0
        self.rack_code = None
        self.rack = None
        self.missing_amount = 0.0
        self.change = 0.0
