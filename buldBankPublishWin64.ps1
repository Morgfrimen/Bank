Set-Location Bank
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained true -c Release -o ..\Win64\Publish