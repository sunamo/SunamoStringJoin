# SunamoStringJoin

A .NET library for joining multiple strings into one using various formats and delimiters.

## Features

- Join strings with custom delimiters (comma, newline, space, etc.)
- Join dictionary key-value pairs with configurable formatting
- Join from/to specific indexes within collections
- Wrap non-numeric words with quotes during joining
- Exclude specific indexes during joining
- Repeat text a specified number of times

## Installation

```
dotnet add package SunamoStringJoin
```

## Usage

```csharp
using SunamoStringJoin;

// Basic join with delimiter
var result = SHJoin.Join(",", new List<string> { "a", "b", "c" }); // "a,b,c"

// Join with newlines
var lines = SHJoin.JoinNL(new List<string> { "line1", "line2" }); // "line1\nline2"

// Join with comma
var csv = SHJoin.JoinComma("a", "b", "c"); // "a,b,c"

// Join dictionary
var dict = new Dictionary<string, string> { { "key1", "val1" }, { "key2", "val2" } };
var joined = SHJoin.JoinDictionary(dict, "="); // "key1=val1\nkey2=val2\n"
```

## Target Frameworks

**TargetFrameworks:** `net10.0;net9.0;net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

For feature requests or bug reports: [Email](mailto:radek.jancik@sunamo.cz) or on GitHub
