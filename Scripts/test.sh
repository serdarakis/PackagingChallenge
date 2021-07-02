#!/bin/bash
dotnet test ../Test/Com.Mobiquity.Packer.Test --verbosity=quiet

EXIT_STATUS=$?

if [ "$EXIT_STATUS" -eq "0" ]
then
    echo "All tests are passed"
    exit 0
else
    echo "Fix unit tests first"
    exit 1
fi
