Function Get-DiskInfo{
    [CmdletBinding()]
    Param(
        [string[]]$computername=@("localhost")
    )

    PROCESS {
        $BYTES_PER_GiB = [System.Math]::Pow(1024,3)
        foreach ($computer in $computername) {
            $disks = Get-CimInstance -ClassName Win32_LogicalDisk -Filter "DriveType like '3'"
        }
        foreach ($disk in $disks) {
            $output = [PSCustomObject]@{
                'ComputerName' = $computer
                'DriveLetter' = $disk.deviceid
                'FreeSpace(GiB)' = [System.Math]::Round($disk.FreeSpace / $BYTES_PER_GiB, 2)
                'Size(GiB)' = [System.Math]::Round($disk.Size / $BYTES_PER_GiB, 2)
            }
            Write-Output $output
        }
    }
}