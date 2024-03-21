
$filenames = @()
$folder = $HOME
$date = Get-Date -Format "dd.MM.yyyy HH.mm"
Do {
    $answer = Read-Host -Prompt "Give a file name, press Enter to quit:"
    if ($answer -ne "") {$filenames += $answer}
}
Until ($answer -eq "")
ForEach ($file in $filenames) {
    Add-Content -Path $folder/$file -Value $date
}

Write-Host $filenames.count "files were created succesfully"