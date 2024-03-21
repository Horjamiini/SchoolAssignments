param(
    [string]$filename    
)

$folder = $HOME
$workstations = @()
Do {
    $answer = Read-Host -Prompt "Give a workstation name, press Enter to quit:"
    if ($answer -ne "") {$workstations += $answer}
}
Until ($answer -eq "")

Add-Content -Path $folder\$filename.txt  -Value $workstations
Write-Host "$folder\$filename.txt has been created succesfully!"
