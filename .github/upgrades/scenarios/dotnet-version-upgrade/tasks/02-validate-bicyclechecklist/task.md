# 02-validate-bicyclechecklist: Validate upgraded targets

Validate the upgraded project across Android, iOS, and Windows, and run any available automated tests. Confirm that the target framework and platform configuration resolve as intended and that no compatibility warnings remain. Where iOS build or runtime validation requires an unavailable Apple toolchain or paired Mac, record that concrete limitation and the verification still possible in this environment.

**Done when**: All feasible target builds and available tests pass without warnings or errors, and any environment-blocked platform validation is explicitly documented.

## Validation Findings

- The solution contains one SDK-style MAUI project, `BicycleCheckList\BicycleCheckList.csproj`, targeting `net11.0-android37.0`, `net11.0-ios`, and conditionally `net11.0-windows10.0.26100.0` on Windows.
- Platform minima are Android API 24 and iOS 12.2. The Android target API is 37.0; Windows retains its existing target and minimum.
- Central package management resolves MAUI Controls 11.0.10, Microsoft.Extensions.Logging 11.0.0, Microsoft.Extensions.Logging.Debug 11.0.0, and CommunityToolkit.Mvvm 8.4.2.
- The Windows environment has the .NET 11 Android/iOS workloads. iOS compilation is available for the iOS Simulator target; device deployment/runtime validation may require a networked Mac and will not be claimed here.
- Test Explorer reports no tests matching the project. The final solution build completed successfully for all three targets with 0 warnings and 0 errors. iOS compilation covered the iOS Simulator x64 target; no device deployment/runtime test was attempted because that may require a paired/networked Mac.
