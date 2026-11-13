# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: `net11.0`
- **Modernization Scope**: Upgrade .NET and MAUI, and modernize the iOS and Android platform targets.

## Source Control
- **Source Branch**: master
- **Working Branch**: upgrade-dotnet-11
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Auto (Merge)

## Upgrade Options

### Strategy
- Upgrade Strategy: All-at-Once

## Strategy
**Selected**: All-at-Once
**Rationale**: The solution contains one SDK-style MAUI project with a clean dependency graph and no reported incompatible packages or API migration issues.

### Execution Constraints
- Upgrade the app's .NET target frameworks, MAUI and logging packages, and mobile platform targets together as one atomic change.
- Preserve the existing Windows target while bringing the iOS and Android targets onto the selected framework.
- Align iOS and Android deployment/target API settings with the supported .NET MAUI toolchain and current distribution requirements, retaining compatibility where feasible.
- Build every target that the environment can validate and run available tests; resolve build warnings as well as errors.

## Key Decisions Log
- **2026-11-13**: User confirmed upgrading .NET/MAUI and the iOS and Android targets. .NET 11 is treated as GA based on current Microsoft documentation, despite the upgrade-options tool still reporting Preview.
- **2026-11-13**: User confirmed the All-at-Once strategy. The commit strategy was changed to Single Commit at End to match the strategy recommendation for an atomic upgrade.
