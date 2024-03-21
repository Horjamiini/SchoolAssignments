Function Get-NetAdapterInfo {
    [CmdletBinding()]
    Param(
        [string[]]$computername=@("localhost")
    )

    PROCESS {
        foreach ($computer in $computername) {
            Write-Verbose "Connectin to computer $computer"
            $session = New-CimSession
            $adapters = Get-NetAdapter -CimSession $session
            foreach ($adapter in $adapters) {
                $addresses = Get-NetIPAddress -InterfaceIndex ($adapter.InterfaceIndex) -CimSession $session

                foreach ($address in $addresses) {
                    $output = [PSCustomObject]@{
                        'ComputerName' = $computer
                        'AdapterName' = $adapter.Name
                        'InterfaceIndex' = $adapter.InterfaceIndex
                        'IPAddress' = $address.IPAddress
                        'AddressFamily' = $address.AddressFamily
                    }
                    Write-Output $output
                } #address
            }#adapters
            Write-Verbose "Closing session to $computer"
            Remove-CimSession -CimSession $session
        } #computers
    } #Process
} #function