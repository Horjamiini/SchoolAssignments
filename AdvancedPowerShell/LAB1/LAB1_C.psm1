Function Get-FileVersion  {
    [CmdletBinding()]
    param (
        [Alias('ItemName')]
        [Parameter(Mandatory = $true, HelpMessage = "Enter a Filename!")]
        [ValidatePattern("exe$")]
        [string]$Filename
    )
        Write-Verbose "Checking $FileName"
        Get-ItemPropertyValue -Path $Filename -Name VersionInfo | 
        Select-Object ProductVersion, FileVersion, CompanyName, FileName

}