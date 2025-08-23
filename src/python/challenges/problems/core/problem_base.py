import math
import unittest

import pandas as pd

from core.test_case import TestCase

class ProblemBase(unittest.TestCase):
    def __init__(self, methodName: str = "runTest") -> None:
        super().__init__(methodName)


class TestGen:
    def __init__(self, type: object):
        self.type = type
        self.testCases = []
        self.solutions = [attr for attr in dir(self.type) if attr.lower().startswith("solution")]

    def AddSolution(self, *args):
        for arg in args:
            if arg not in self.solutions:
                self.solutions.append(arg)

        return self

    def Add(self, configure):
        testCase = TestCase("Solution")
        configure(testCase)
        self.testCases.append(testCase)

        return self

    def GenerateTest(self, testCase, suffix):
        def test(self):
            result = getattr(self, testCase.name)(*testCase.params)
            if isinstance(result, float):
                self.assertTrue(math.isclose(testCase.result, result, rel_tol=0.01), f"{str(testCase)}, Actual: {result}")
            elif isinstance(result, pd.DataFrame):
                result.reset_index(drop=True, inplace=True)
                self.assertTrue(result.equals(testCase.result), f"{str(testCase)}, Actual: {result}")
            else:
                self.assertEqual(result, testCase.result, f"{str(testCase)}, Actual: {result}")

        testName = 'test_' + testCase.name + '_' + suffix
        setattr(self.type, testName, test)

    def Run(self):
        if not self.solutions:
            raise ValueError("The solution is not found. The solution method should start with 'Solution' prefix.")

        for tIndex, testCase in enumerate(self.testCases):
            for sIndex, solution in enumerate(self.solutions):
                self.GenerateTest(testCase.Clone(solution), f"{tIndex}_{sIndex}")

        unittest.main()
