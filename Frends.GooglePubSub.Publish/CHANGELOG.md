# Changelog

## [2.0.0] - 2026-08-12
### Added
- [Breaking Change] Renamed the `Errors` field in the `Result` class to `MessageErrors`.
- New **Options** parameter with `ThrowErrorOnFailure` and `ErrorMessageOnFailure` settings, giving you control over whether publishing failures raise an exception or return a result object.
- The result now includes a `Success` flag (true when the batch completes, even if some individual messages fail) and an `Error` property populated when the overall operation fails and `ThrowErrorOnFailure` is false.
### Changed
- Upgraded target framework from .NET 6 to .NET 8.

## [1.0.2] - 2023-02-08
### Added
- Missing documentation examples.
### Fixed
- Memory leak fix by unloading assembly context after Task execution.

## [1.0.1] - 2022-10-18
### Fixed
- Fixed a problem with message ordering failing

## [1.0.0] - 2022-10-04
### Added
- Initial implementation
