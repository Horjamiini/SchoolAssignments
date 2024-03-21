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
                $version = Get-ItemPropertyValue -Path $File -Name VersionInfo | 
                Select-Object ProductVersion, FileVersion, CompanyName, FileName
                $CreationDate = Get-ItemProperty -Path $File | Select-Object -ExpandProperty CreationTime
                $LastAccessDate = Get-ItemProperty -Path C:\Windows | Select-Object -ExpandProperty LastAccessTime

                $properties = @{'FileName'          = $File;
                                'ProductVersion'    = $version.ProductVersion;
                                'FileVersion'       = $version.FileVersion;
                                'CreationDate'      = $CreationDate;
                                'LastAccessDate'    = $LastAccessDate;
                }
                $output = New-Object -TypeName psobject -Property $properties
                Write-Output $output
            }
        }

}