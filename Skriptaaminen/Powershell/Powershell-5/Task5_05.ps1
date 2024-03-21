function Add-MyEvent{
    param(
        [string]$filename,
        [array]$Type,
        [string]$Message
        
    )
    $Eventnames = "Information","Warning","Error"
    $Type = $Eventnames



try {

    Get-LocalUser | Select-Object Name,Fullname,SID,LastLogon | Export-Csv -Path .\$filename.csv
    $Message = "Csv file was exported succesfully" 
    
    Write-EventLog -LogName MyPowerShell -Source "MyPowerShell" -EventId 3001 -EntryType $Type[0] -Message $Message
}

catch{
    $Message = "Something went wrong"
    Write-EventLog -LogName MyPowerShell -Source "MyPowershell" -EventId 3001 -EntryType $Type[2] -Message $Message

}
}


