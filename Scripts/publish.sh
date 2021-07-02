#!/bin/bash

API_KEY="<Api-Key>"
FOLDER="../Packages/"
SOURCE="https://api.nuget.org/v3/index.json"



for entry in "$FOLDER"*
do
echo "$entry" 
  dotnet nuget push "$entry" --api-key "$API_KEY" --source "$SOURCE" --skip-duplicate
done