#ModuleName - CorpTools.psm1
Function Get-FileVersion  {
    [CmdletBinding()]
    param (
        [Parameter()]
        [string]$Filename
    )
        Write-Verbose "Checking $FileName"
        Get-ItemPropertyValue -Path $Filename -Name VersionInfo | 
        Select-Object ProductVersion, FileVersion, CompanyName, FileName

}