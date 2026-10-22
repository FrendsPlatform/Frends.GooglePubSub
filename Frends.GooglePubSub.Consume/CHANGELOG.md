# Changelog

## [2.0.0] - 2026-10-22
### Added
- Added `ThrowErrorOnFailure` and `ErrorMessageOnFailure` options. When `ThrowErrorOnFailure` is false, errors are returned in the result instead of being thrown.
- Result now contains `Success` and `Error` properties.

### Changed
- Task now targets .NET 8.
- Errors that previously occurred while creating the client or validating parameters are now handled according to the error handling options.

## [1.0.0] - 2024-02-27
### Changed
- Initial implementation
