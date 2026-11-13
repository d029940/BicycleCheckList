# .NET Version Upgrade Plan

## Overview

**Target**: Upgrade BicycleCheckList from .NET 10 / .NET MAUI 10 to .NET 11 / .NET MAUI 11 and modernize its iOS and Android platform targets.
**Scope**: One SDK-style MAUI project; preserve its existing Windows target.

### Selected Strategy
**All-at-Once** — All projects upgraded simultaneously in a single operation.
**Rationale**: One SDK-style project, a straightforward dependency graph, and no incompatible packages or API migration issues reported by the assessment.

## Upgrade Options

| Option | Selected | Why |
|--------|----------|-----|
| Upgrade Strategy | All-at-Once | The assessment found one SDK-style project and no incompatible packages or API migration issues. |

## Tasks

### 01-upgrade-bicyclechecklist: Upgrade .NET, MAUI, and mobile targets

Upgrade the `BicycleCheckList` MAUI project from .NET 10 to .NET 11 across its Android, iOS, and existing Windows targets. Update the MAUI and related centrally managed package versions to compatible .NET 11 releases, including the logging packages flagged by the assessment. The assessment's proposed target list only advances Windows, so explicitly validate and retarget Android and iOS as requested rather than treating that proposal as complete.

Modernize the iOS deployment minimum and Android minimum/target API settings to values supported by the .NET 11 MAUI toolchain and current distribution requirements, retaining the broadest practical device compatibility. Check the existing project settings and platform manifests for consistency, and preserve the app's current behavior and identifiers.

**Done when**: All project target frameworks and package versions are compatible with .NET 11 / MAUI 11; Android and iOS platform settings are current and consistent; the app builds for every target available in the environment without warnings or errors.

### 02-validate-bicyclechecklist: Validate upgraded targets

Validate the upgraded project across Android, iOS, and Windows, and run any available automated tests. Confirm that the target framework and platform configuration resolve as intended and that no compatibility warnings remain. Where iOS build or runtime validation requires an unavailable Apple toolchain or paired Mac, record that concrete limitation and the verification still possible in this environment.

**Done when**: All feasible target builds and available tests pass without warnings or errors, and any environment-blocked platform validation is explicitly documented.
