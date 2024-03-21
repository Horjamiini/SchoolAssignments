Function Get-FileVersion  {
    [CmdletBinding()]
    param (
        [Parameter()]
        [string]$Filename
    )
        Get-ItemPropertyValue -Path $Filename -Name VersionInfo | 
        Select-Object ProductVersion, FileVersion, CompanyName, FilenName

}