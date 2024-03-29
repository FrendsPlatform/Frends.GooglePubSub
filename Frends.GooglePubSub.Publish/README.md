# Frends.GooglePubSub.Publish
Frends Task for publishing messages on Google Cloud PubSub service.

[![Frends.GooglePubSub.Publish Main](https://github.com/FrendsPlatform/Frends.GooglePubSub/actions/workflows/Publish_build_and_test_on_main.yml/badge.svg)](https://github.com/FrendsPlatform/Frends.GooglePubSub/actions/workflows/Publish_build_and_test_on_main.yml)
 ![GitHub](https://img.shields.io/github/license/FrendsPlatform/Frends.GooglePubSub?label=License)
 ![Coverage](https://app-github-custom-badges.azurewebsites.net/Badge?key=FrendsPlatform/Frends.GooglePubSub|Frends.GooglePubSub.Publish|main)

Returns a boolean depicting if the input text matches with the specified regular expression.

## Installing

You can install the Task via Frends UI Task View.

## Building

Clone a copy of the repository

`git clone https://github.com/FrendsPlatform/Frends.GooglePubSub.git`

### Build the project

```
cd Frends.GooglePubSub.Publish
dotnet build
```

### Run tests

```
cd Frends.GooglePubSub.Publish.Tests
docker-compose up -d
dotnet test
```

### Create a NuGet package

`dotnet pack --configuration Release`
