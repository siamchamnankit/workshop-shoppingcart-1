#!/usr/bin/env bash
project=$RUNNING_PROJECT
if [ "$project" == "" ]
then
    echo "No Project Argument: RUNNING_PROJECT - try RUNNING_CLASS=./tests/api.UnitTest/api.UnitTest.csproj"
else
    dotnet test ${RUNNING_PROJECT}
fi
