#1.0.7

function Main()
{
    $version = GetNextVersion
    
    $publishRoot = "./_build"
    $containerRoot = "./_build/bin"
    $imageName = "litedb-test"    
    $platforms = @("armhf","amd64")

    rmdir -Force -Recurs $publishRoot
    dotnet publish -c Release /p:Version=$version -o $containerRoot
    
    foreach ($p in $platforms)
    {
        $version
        docker build --pull --platform $p -t "maxbl4/$imageName-$($p):$version" -t "maxbl4/$imageName-$($p):latest" -f dockerfile $publishRoot
        docker push "maxbl4/$imageName-$($p):$version"
        docker push "maxbl4/$imageName-$($p):latest"
    }

    UpdateVersion $version
}

function GetNextVersion()
{
    $lines = Get-Content $MyInvocation.ScriptName
    $version = [System.Version]::Parse($lines[0].Substring(1))
    return "$($version.Major).$($version.Minor).$($version.Build + 1)"
}

function UpdateVersion($version)
{
    $lines = Get-Content $MyInvocation.ScriptName
    $lines[0] = "#$version"
    $lines > $MyInvocation.ScriptName
}

Main
