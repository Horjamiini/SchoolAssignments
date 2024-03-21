param(
    [string]$filename
)

$userpath = Test-Path $filename
$answerlist = @()
if ($userpath -eq $true){ 
    


    Import-Csv .\users.csv | ForEach-Object {Write-Host "A new local account"  $($_.Lastname.substring(0,4) + $_.Firstname.substring(0,2)).ToLower()  "will be created for" $_.Firstname $_.Lastname; $answer = Read-Host -Prompt Y/N
    if ($answer -eq "Y"){
        ForEach-Object {New-LocalUser -Name $($_.Lastname.substring(0,4) + $_.Firstname.substring(0,2)).ToLower() -NoPassword}
        $answerlist += 1
        Write-Host "Account created"
    }

    elseif ($answer -eq "N"){
        Write-Host "Account was not created"
        }

    elseif ($answer -ne "Y|N"){
        Write-Host "Invalid input"
        }
    
    
    }

    Write-Host $answerlist.count "accounts were created"
}

elseif ($userpath -ne $true){
    Write-Host "Error, invalid filename"
}
