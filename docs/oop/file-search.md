# File Search

**Topics:** `OOP`  
**Solutions:** [`C#`](../../src/csharp/oop/FileSearch)  

## Rules

A user initiates a search on a system to locate specific files, such as those owned by a particular user or matching
a text pattern hidden deep within nested directories. By issuing a search command with defined criteria, the system
rapidly returns relevant results.

Behind the scenes, the system efficiently performs recursive directory traversal, inspects file attributes, and applies
the user-defined filters to pinpoint matching files with speed and precision.

## Build and Run

``` bash
dotnet run --project ./FileSearch.csproj
```

``` bash
dotnet test ./FileSearch.csproj
```
