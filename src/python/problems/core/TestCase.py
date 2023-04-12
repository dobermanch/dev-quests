import copy

# TODO: Fix, new testcase overrides previous one
class TestCase:

    def __init__(self, name: str, params: list = {}, result: any = None, disabled: bool = False):
        self.name = name
        self.params = params
        self.result = result
        self.disabled = disabled

    def Param(self, name, param):
        self.params[name] = param
        return self

    def Result(self, result):
        if self.result:
            raise ValueError(result)

        self.result = result
        return self

    def Disable(self, disabled: bool):
        self.disabled = disabled
        return self

    def Clone(self, name: str):
        return TestCase(name, copy.deepcopy(self.params), self.result, self.disabled)