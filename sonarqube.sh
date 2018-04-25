dotnet /Users/ifew/Downloads/sonar-scanner-msbuild-4.2.0.1214-netcoreapp2.0/SonarScanner.MSBuild.dll begin /k:"workshop-shoppingcart" /d:sonar.organization="ifew-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="af3402002ed294b9b2a0fd28dbf67d96c2b5d4ff"
dotnet build
dotnet /Users/ifew/Downloads/sonar-scanner-msbuild-4.2.0.1214-netcoreapp2.0/SonarScanner.MSBuild.dll end /d:sonar.login="af3402002ed294b9b2a0fd28dbf67d96c2b5d4ff"
echo "Access on => https://sonarcloud.io/dashboard?id=workshop-shoppingcart"