# Progress: Upgrade .NET, MAUI, and mobile targets

## Changes

- Retargeted the MAUI app to .NET 11 for Android (`net11.0-android37.0`), iOS (`net11.0-ios`), and the existing Windows target (`net11.0-windows10.0.26100.0`). Updated the matching configuration conditions and retained the app identifiers and versions.
- Set Android minimum API to 24 and target API to 37; set the iOS minimum to 12.2.
- Updated centrally managed MAUI Controls to 11.0.10 and Microsoft.Extensions.Logging packages to 11.0.0. CommunityToolkit.Mvvm remains at 8.4.2.
- Removed MAUI 11 build warnings by replacing the deprecated named font size, removing the unused ListView style, and matching the nullable event-handler signature.

## Validation

- `dotnet build BicycleCheckList\BicycleCheckList.csproj -v:minimal` succeeded for iOS Simulator x64, Android, and Windows with 0 warnings and 0 errors.
- Test Explorer found no tests for `BicycleCheckList`.
- iOS compilation was validated for the available simulator target; device deployment/runtime behavior was not exercised.
