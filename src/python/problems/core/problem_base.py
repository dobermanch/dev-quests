import unittest

from core.test_case import TestCase

class ProblemBase(unittest.TestCase):
    def __init__(self, methodName: str = "runTest") -> None:
        super().__init__(methodName)


class TestGen:
    def __init__(self, type: object):
        self.type = type
        self.testCases = []
        self.solutions = [ "Solution" ]

    def AddSolution(self, *args):
        for arg in args:
            self.solutions.append(arg)
        return self

    def Add(self, configure):
        testCase = TestCase("Solution")
        configure(testCase)
        self.testCases.append(testCase)

        return self

    def GenerateTest(self, testCase):
        def test(self):
            result = getattr(self, testCase.name)(**testCase.params)
            self.assertEqual(result, testCase.result)

        testName = 'test_' + testCase.name + '_' + str(testCase.params)
        setattr(self.type, testName, test)
        return test

    def Run(self):
        for testCase in self.testCases:
            for solution in self.solutions:
                self.GenerateTest(testCase.Clone(solution))

        unittest.main()
