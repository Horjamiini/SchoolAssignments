param(
    [string]$ping = '192.168.8.1',
    [int]$tries = 1
)
    Write-Host "I will ping address $ping $tries times,okay?"
    Do{
    $answer = Read-Host -Prompt "[Y/N]"
    if ($answer -notmatch "Y|N"){
        Write-Output "Not a valid answer, please input Y or N"
    }
}
until ($answer -match "Y|N")
If ($answer -eq "Y"){
    For ($i = 0;$i -lt $tries; $i++){
        Write-Output("Try " + ($i+1) + " to ping: " + $ping)}
}
elseif ($answer -eq "N") {
    Write-Output("I will cancel the ping")}
