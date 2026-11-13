# BicycleCheckList\BicycleCheckList.csproj

[← Back to the assessment index](../../assessment.md)

## Project Info

- **Current Target Framework:** net10.0-android;net10.0-ios;net10.0-windows10.0.26100.0
- **Proposed Target Framework:** net10.0-android;net10.0-ios;net10.0-windows10.0.26100.0;net11.0-windows
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 36
- **Number of Files with Incidents**: 1
- **Lines of Code**: 3580
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

## Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["BicycleCheckList.csproj"]
        MAIN["<b>📦&nbsp;BicycleCheckList.csproj</b><br/><small>net10.0-android;net10.0-ios;net10.0-windows10.0.26100.0</small>"]
        click MAIN "../projects/BicycleCheckList.md"
    end

```

## API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

## NuGet Package Issues

| Package | Current Version | Suggested Version | Severity | Issue |
| :--- | :---: | :---: | :---: | :--- |
| Microsoft.Extensions.Logging | 10.0.5 | 10.0.15 | 🟡 Potential | NuGet package upgrade is recommended |
| Microsoft.Extensions.Logging.Debug | 10.0.5 | 10.0.15 | 🟡 Potential | NuGet package upgrade is recommended |

Every project affected by these packages, and the versions the repository settles on: [aggregate NuGet packages](../nuget/aggregate-packages.md).

