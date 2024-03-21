param (
    [string]$foldername
    )

$folder = Test-Path $foldername

if ($folder -eq $true){
    $files = Get-ChildItem $foldername
    $i = $files.count
    Write-Host "$i files in the folder $foldername"
    foreach($file in $files){
        $file.name
    }
}
elseif ($folder -eq $false){
    Write-Host "Sorry folder $foldername cannot be found"
}