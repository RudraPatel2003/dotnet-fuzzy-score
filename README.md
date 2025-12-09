<h1 align="center">
  <br>
    <img src="https://github.com/RudraPatel2003/dotnet-fuzzy-score/blob/main/assets/repository-banner.png" alt="Repository Banner" width="25%">  
  <br>
    FuzzyScore.Net
</h1>

This NuGet package ports the [Apache Commons FuzzyScore text similarity algorithm](https://commons.apache.org/proper/commons-text/apidocs/org/apache/commons/text/similarity/FuzzyScore.html) to .NET

## Installation

You can install this package from [NuGet](https://www.nuget.org/packages/FuzzyScore.Net/):

```powershell
Install-Package FuzzyScore.Net
```

Or run the following command

```bash
dotnet add package FuzzyScore.Net
```

## Usage

```csharp
using FuzzyScore.Net;

string term = "Workshop";
string query = "wo";

int score = FuzzyScore.Score(term, query);

Console.WriteLine($"The score for '{term}' and '{query}' is {score}.");
```
