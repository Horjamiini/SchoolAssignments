param(
    [string]$filename
)

$userpath = Test-Path $filename

if ($userpath -eq $true){ 
    


    Import-Csv .\users.csv | ForEach-Object {Write-Host "Hello my colleague" $_.Firstname $_.Lastname "this is your new account:"
    $($_.Lastname.substring(0,4) + $_.Firstname.substring(0,2)).ToLower() }
    
    

    Write-Host "3 accounts created succesfully"
}

elseif ($userpath -ne $true){
    Write-Host "Error, invalid filename"
}