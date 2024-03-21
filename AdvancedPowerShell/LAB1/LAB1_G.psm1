Function Get-FileVersion  {
    <#
    .SYNOPSIS
    Retrieves File and Product version, Creation date and Last Access Date from one or more .exe files.
    .Description
    This comand retrieves specific information drom each file defined in the input. The command will only work wwith .exe files
    .PARAMETER FileName
    .EXAMPLE
    Get-ChildItem *.exe | Get-FileVersion
    This example assumes that there are .exe files in the current directory, and will retrieve information from each file listed.
    .EXAMPLE
    Get-FileVersion -FileName C:\Windows\explorer.exe
    This example retrieves information from one file.
    #>
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