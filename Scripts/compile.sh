#!/bin/bash

dotnet clean ../Com.Mobiquity.Packer --verbosity=quiet
dotnet restore ../Com.Mobiquity.Packer --verbosity=quiet --force
dotnet build ../Com.Mobiquity.Packer --verbosity=quiet --configuration Release --force
dotnet pack ../Com.Mobiquity.Packer --output ../Packages/