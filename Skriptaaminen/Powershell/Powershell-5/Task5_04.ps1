param(
    [string]$filename
)


Get-LocalUser | Select-Object Name,Fullname,SID,LastLogon | Export-Csv -Path .\$filename.csv