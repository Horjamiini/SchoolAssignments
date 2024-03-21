param(
    [string]$filename
)
$urlpath = Test-Path $filename

if ($urlpath -eq $true){ 
    $allurl = @()
    $allurl += Get-Content .\$filename
    
    foreach($url in $allurl){
        Start-Process -FilePath Chrome -Argumentlist $url
    }


}

elseif ($urlpath -ne $true){
    Write-Host "Error, invalid filename"
}