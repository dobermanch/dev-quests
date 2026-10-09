# Overview

A collection of my solutions to diverse development challenges.

[![example workflow](https://github.com/dobermanch/leetcode/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/dobermanch/leetcode/actions/workflows/dotnet-desktop.yml)

## Problems

- [LeetCode](docs/challenges/README.md) problems.
- [OOP](docs/oop/README.md) problems.

## Commands

### LeetCode

Fetch a LeetCode problem and generate solution snippet files. This command creates a Markdown file for the problem along with code templates in the specified languages.

``` bash
make challenge SLUG=two-sum LANGS=csharp,python,golang
```

Where:

- `SLUG`: The unique identifier for the LeetCode problem, typically found in the problem's URL.
- `LANGS`: Specifies which languages to generate placeholder solution files for. Supported options include: `csharp`, `python`, `golang`, `rust`, `javascript`, `typescript`, `mysql`, `mssql`, and `pandas`.

### .NET

Build the .NET solution and run the tests.

``` bash
make dotnet_build                           # build the solution
make dotnet_test                            # run all tests
make dotnet_test TEST=NumBusesToDestination # run tests whose name contains TEST
make dotnet_test FILTER="FullyQualifiedName=LeetCode.Problems.TwoSum" # run tests matching a dotnet test filter
```
