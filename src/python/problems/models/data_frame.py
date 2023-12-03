import pandas as pd
from core.test_case import TestCase

def parseSchema(input):
    columnNames = []
    columnTypes = []
    for line in input.split('\n'):
        if line.strip().startswith('|'):
            parts = [p.strip() for p in line.split('|') if p.strip()]
            columnNames.append(parts[0])
            columnTypes.append(parts[1])

    data = {name: [] for name in columnNames}
    for name, type_ in zip(columnNames, columnTypes):
        if type_ == 'int':
            data[name] = pd.Int64Dtype()
        elif type_ == 'float':
            data[name] = float
        else:
            data[name] = str

    df = pd.DataFrame(data, index=[0])

    return df

def parse(input):
    columnNames = []
    dataRows = []
    for line in input.split('\n'):
        toParse = line.strip()
        if not columnNames and toParse.startswith('|'):
            columnNames = [p.strip() for p in toParse.split('|') if p.strip()]
        elif toParse.startswith('|'):
            row = []
            for p in toParse.split('|')[1:-1]:
                param = p.strip()
                try:
                    row.append(int(param))
                except:                    
                    try:
                        row.append(float(param))
                    except:
                        row.append(param if param else None)
            if row:
                dataRows.append(row)
                    
    df = pd.DataFrame(dataRows, columns=columnNames)
    
    return df

def TestCaseDataFrame(cls):
    def decorator(func):
        setattr(cls, func.__name__, func)
        return func
    return decorator
    
@TestCaseDataFrame(TestCase)
def ParamDataFrame(self, param: any):
    return self.Param(parse(param))

@TestCaseDataFrame(TestCase)
def ResultDataFrame(self, param: any):
    return self.Result(parse(param))