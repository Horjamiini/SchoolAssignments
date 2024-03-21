Function Get-FileVersion  {
    [CmdletBinding()]
    param (
        [Alias('ItemName')]
        [Parameter(Mandatory = $true, HelpMessage = "Enter a Filename!")]
        [ValidatePattern("exe$")]
        [string[]]$Filename
    )
        

        foreach ($File in $FileName) {
        Write-Verbose "Checking $File"
        Get-ItemPropertyValue -Path $File -Name VersionInfo | 
        Select-Object ProductVersion, FileVersion, CompanyName, FileName
        }

}