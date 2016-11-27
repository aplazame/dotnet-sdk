# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/) 
and this project adheres to [Semantic Versioning](http://semver.org/).

## [Unreleased]
### Added
- [Api] Add `HttpStatusCode` to `ApiClientException` and `ApiServerException`. This method returns the response HTTP status code.
- [Serializer] New component focused only in assist the conversion of C# types to JSON compatible types.

### Changed
- [Api] Change in `ApiClientException` and `ApiServerException` constructor signature.
- [BusinessModel] This component has been replaced by [Serializer]

### Deprecated

### Removed
- [BusinessModel] This component has been replaced by [Serializer]

### Fixed

### Security

## [0.1.3] - 2016-11-10
### Added

### Changed

### Deprecated

### Removed

### Fixed
- [Api] Fix request URI
- [Api] Fix sandbox header
- Fix outdated version in ApiRequest.SdkVersion

### Security

## [0.1.2] - 2016-11-10
### Added

### Changed

### Deprecated

### Removed

### Fixed
- Fix assembly release number.

### Security

## [0.1.1] - 2016-11-10
### Added

### Changed

### Deprecated

### Removed

### Fixed
- [Http] Fix headers assignment when there are restricted headers present in the collection.

### Security

## [0.1.0] - 2016-10-04
### Added
- [Api]
- [BusinessModels]
- [Http]

[Unreleased]: https://github.com/aplazame/dotnet-sdk/compare/v0.1.3...HEAD
[0.1.3]: https://github.com/aplazame/dotnet-sdk/compare/v0.1.2...v0.1.3
[0.1.2]: https://github.com/aplazame/dotnet-sdk/compare/v0.1.1...v0.1.2
[0.1.1]: https://github.com/aplazame/dotnet-sdk/compare/v0.1.0...v0.1.1
[0.1.0]: https://github.com/aplazame/dotnet-sdk/commit/3ed234e0430e98b4d6edefe06192a8ba7eb7d0cb
