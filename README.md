[![Build Status](https://travis-ci.com/hmlendea/ck2-mod-tests.svg?branch=master)](https://travis-ci.com/hmlendea/ck2-mod-tests)

# CK2 Mod Tests

CK2 Mod unit tests, intended to be used with Travis-CI for GIT repositories of any CK2 mod

## Usage

You will need to add this repository as a submodule into your repository
You will then need to create a .travis.yml file to instruct Travis to run the tests

**For adding the submodule:**
```console
git submodule add https://github.com/hmlendea/ck2-mod-tests.git
git submodule init
git submodule update
```

**The required .travis.yml file**
```yml
language: csharp
mono: none
dotnet: 2.2
dist: xenial

install:
- dotnet restore ck2-mod-tests

script:
 - dotnet build ck2-mod-tests
 - dotnet test ck2-mod-tests
 
```

**Update the submodule to the latest version using:**
```console
git submodule update --remote --merge
```
