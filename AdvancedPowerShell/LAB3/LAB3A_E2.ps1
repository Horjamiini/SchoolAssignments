$loop = $true
while($loop){
    Write-Host "1. Display information of the operating system of the computer"
    Write-Host "2. Display disk information of the computer"
    Write-Host "3. Display memory information of the computer"
    Write-Host "4. Shut down and turn off the computer"
    Write-Host "S. Close the menu"

    $choice = Read-Host -Prompt "Enter option"

    switch ($choice) {
        1 { Get-OSInfo }
        2 { Get-DiskInfo }
        3 { Get-MemInfo }
        4 { Stop-Computer }
        'S' { $loop = !$loop }
        Default { Write-Host "Unidentified choice" -ForegroundColor Red }
    }
}
