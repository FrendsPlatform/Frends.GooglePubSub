# Frends.GooglePubSub.Consume
Frends Task for consuming messages from Google Cloud PubSub service.

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Build](https://github.com/FrendsPlatform/Frends.GooglePubSub/actions/workflows/Consume_build_and_test_on_main.yml/badge.svg)](https://github.com/FrendsPlatform/Frends.GooglePubSub/actions)
![Coverage](https://app-github-custom-badges.azurewebsites.net/Badge?key=FrendsPlatform/Frends.GooglePubSub/Frends.GooglePubSub.Consume|main)

## Installing

You can install the Task via frends UI Task View.

## Building

### Clone a copy of the repository

`git clone https://github.com/FrendsPlatform/Frends.GooglePubSub.git`

### Build the project

`dotnet build`

### Build Docker container

`docker-compose -f Frends.GooglePubSub.Consume.Tests/docker-compose.yml up -d`

### Run tests

Run the tests

`dotnet test`

### Create a NuGet package

`dotnet pack --configuration Release`

### Third party licenses

StyleCop.Analyzer version (unmodified version 1.1.118) used to analyze code uses Apache-2.0 license, full text and source code can be found in https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/README.md
