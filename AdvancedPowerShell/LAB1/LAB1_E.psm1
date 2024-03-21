Function Get-FileVersion  {
    [CmdletBinding()]
    param (
        [Alias('ItemName')]
        [Parameter(Mandatory = $true, HelpMessage = "Enter a Filename!",
        ValueFromPipeline=$true, ValueFromPipelineByPropertyName=$true)]
        [ValidatePattern("exe$")]
        [string[]]$Filename
    )
        
        PROCESS
        {
            foreach ($File in $FileName) {
                Write-Verbose "Checking $File"
                Get-ItemPropertyValue -Path $File -Name VersionInfo | 
                Select-Object ProductVersion, FileVersion, CompanyName, FileName
            }
        }

}