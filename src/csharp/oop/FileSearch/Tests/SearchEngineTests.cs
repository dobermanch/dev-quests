using System.Collections;
using FileSearch.Search;
using FileSearch.Search.Attributes;
using FileSearch.Search.Operands;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace FileSearch.Tests;

public class SearchEngineTests
{
    [Fact]
    public void ShouldFoundFilesAccordingToTheCriteria()
    {
        // find . -r --predicate "(name = 'file1' OR name = 'file2') AND ext *= 'sln.' AND size > 10 AND size < 100"
        // find . -r --name 'file1' --name 'file2' --ext-reg 'sln.' --size >10 --size <100
        
        var criteria = new AndOperand([
            new OrOperand([
                new ByNameMatchCriteria("dir1-file1"),
                new ByNameMatchCriteria("dir1-file3")
            ]),
            new ByExtensionMatchCriteria("t.*", true),
            new BySizeMatchCriteria(10, ComparisonOperandType.GreaterThan),
            new BySizeMatchCriteria(100, ComparisonOperandType.LessThan)
        ]);

        var result = new SearchEngine(new FileProviderMock()).Search(criteria, new SearchOptions
        {
            IsRecursive = true,
            IsCaseSensitive = false
        }).ToArray();

        Assert.Equal(2, result.Length);
        Assert.Equal("dir1-file1.txt", result[0].Name);
        Assert.Equal("dir1-file1.txd", result[1].Name);
    }
}

class FileProviderMock : IFileProvider
{
    public IDirectoryContents GetDirectoryContents(string subpath)
    {
        if (subpath == "\\dir1")
        {
            return new DirectoryContentsMock([
                new FileInfoMock(true, 0, null, "sub-dir1", DateTimeOffset.UtcNow.AddHours(-1), true),
                new FileInfoMock(true, 20, null, "dir1-file1.txt", DateTimeOffset.UtcNow.AddMinutes(-1), false),
                new FileInfoMock(true, 25, null, "dir1-file1.txd", DateTimeOffset.UtcNow.AddMinutes(-1.1), false),
                new FileInfoMock(true, 35, null, "dir1-file1.cs", DateTimeOffset.UtcNow.AddMinutes(-1.2), false),
                new FileInfoMock(true, 30, null, "dir1-file2.txt", DateTimeOffset.UtcNow.AddMinutes(-2), false),
                new FileInfoMock(true, 10, null, "dir1-file3.txt", DateTimeOffset.UtcNow.AddMinutes(-3), false),
            ], true);
        }
        
        if (subpath == "\\dir1\\sub-dir1")
        {
            return new DirectoryContentsMock([
                new FileInfoMock(true, 10, null, "sub-dir1-file1.txt", DateTimeOffset.UtcNow.AddMinutes(-4), false),
                new FileInfoMock(true, 20, null, "sub-dir1-file2.txt", DateTimeOffset.UtcNow.AddMinutes(-5), false),
                new FileInfoMock(true, 30, null, "sub-dir1-file3.txt", DateTimeOffset.UtcNow.AddMinutes(-6), false),
            ], true);
        }
        
        if (subpath == "\\dir2")
        {
            return new DirectoryContentsMock([
                new FileInfoMock(true, 1, null, "dir2-file1.txt", DateTimeOffset.UtcNow.AddMinutes(-7), false),
                new FileInfoMock(true, 100, null, "dir2-file2.txt", DateTimeOffset.UtcNow.AddMinutes(-8), false),
                new FileInfoMock(true, 200, null, "dir2-file3.txt", DateTimeOffset.UtcNow.AddMinutes(-9), false),
            ], true);
        }
        
        return new DirectoryContentsMock([
            new FileInfoMock(true, 0, null, "dir1", DateTimeOffset.UtcNow.AddHours(-1), true),
            new FileInfoMock(true, 10, null, "dir2", DateTimeOffset.UtcNow.AddHours(-2), true),
            new FileInfoMock(true, 10, null, "root-file1.txt", DateTimeOffset.UtcNow.AddMinutes(-10), false),
            new FileInfoMock(true, 10, null, "root-file2.txt", DateTimeOffset.UtcNow.AddMinutes(-11), false),
            new FileInfoMock(true, 10, null, "root-file3.txt", DateTimeOffset.UtcNow.AddMinutes(-12), false),
        ], true);
    }

    public IFileInfo GetFileInfo(string subpath) => throw new NotImplementedException();

    public IChangeToken Watch(string filter) => throw new NotImplementedException();
}

sealed record DirectoryContentsMock(IEnumerable<IFileInfo> Content, bool Exists) : IDirectoryContents
{
    public IEnumerator<IFileInfo> GetEnumerator() => Content.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Exists { get; } = Exists;
}

sealed record FileInfoMock(
    bool Exists,
    long Length,
    string? PhysicalPath,
    string Name,
    DateTimeOffset LastModified,
    bool IsDirectory)
    : IFileInfo
{
    public Stream CreateReadStream() => throw new NotImplementedException();
}
