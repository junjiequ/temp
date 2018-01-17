# Test solution for package AWSSDK.Extensions.NETCore.Setup
issure report URL: https://github.com/aws/aws-sdk-net/issues/828

## Working version:
The project is referencing package "AWSSDK.Extensions.NETCore.Setup" version 3.3.0.3.
It's working as expected

## Reproduce the issue:
Update the nuget package reference of "AWSSDK.Extensions.NETCore.Setup" to version 3.3.1 or higher.
Run the dummy console app
You should see the exception is thrown.
