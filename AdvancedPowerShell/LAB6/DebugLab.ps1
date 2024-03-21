[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [String[]]$RuleName
)

begin {
    
}

process {
    foreach ($name in $RuleName) {
        Write-Debug $name
        Get-NetFirewallRule -DisplayName $name | Where-Object Enable -eq True | Select-Object -Property DisplayName,Profile,Direction,Action,Description
    }
}

end {
    
}