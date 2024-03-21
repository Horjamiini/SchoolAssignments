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
        Do{
        Write-Host "$filename does not exist. Create the file $filename?"
        $answer = Read-Host -Prompt "Y/N"
            if ($answer -notmatch "Y|N") {
            Write-Host "Please input Y or N"
            }
        }
        until ($answer -match "Y|N")
            if ($answer -eq "Y"){
                Write-Host "I will create the file $filename to the folder $foldername"
                New-Item -Path $foldername\$filename -Itemtype File
            }
            elseif ($answer -eq "N"){
                Write-Host "I will not create the file $filename "
            }
    }
}
elseif ($folder -eq $false){
    Write-Host "Sorry folder $foldername cannot be found"
}