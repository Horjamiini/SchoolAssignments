param(
    [string]$foldername
)
$folder = Test-Path $foldername
$Path = $HOME
if ($folder -eq $true){
    $Names = @()
    $Names += Get-Childitem -Path $foldername -Name
    Add-Content -Path $Path\files.txt -Value $Names
    Write-Host $Names.count "filenames were written to file $Path\files.txt"
}

elseif ($folder -eq $false){
    Write-Host "Sorry, $foldername does not exist"
}