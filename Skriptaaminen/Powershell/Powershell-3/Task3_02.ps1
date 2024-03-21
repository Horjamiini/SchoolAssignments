param (
    [string]$foldername,
    [string]$filename
    )

$folder = Test-Path $foldername

if ($folder -eq $true){
    $File = Test-Path $foldername\$filename
    if ($File -eq $true){
        Write-Host "$filename in the folder $foldername exists!"
    }
    elseif ($file -eq $false){
        Write-Host "Sorry, $filename in the $foldername does not exist :("
    }

}
elseif ($folder -eq $false){
    Write-Host "Sorry folder $foldername cannot be found"
}