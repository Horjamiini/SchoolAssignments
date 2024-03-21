Param(
    [Parameter(Mandatory=$true)]
    [string]$Filename
)

$inputdata = Get-Content $Filename | ConvertFrom-Json
$outputdata = @()


foreach ($computer in $inputdata) {
    $computer = $computer | Select-Object name
    $computer | Add-Member -Name OsInfo -Value (Get-OSInfo -computername $computer.name) -MemberType NoteProperty
    $computer | Add-Member -Name MemInfo -Value (Get-MemInfo -computername $computer.name) -MemberType NoteProperty
    $computer | Add-Member -Name DiskInfo -Value (Get-DiskInfo -computername $computer.name) -MemberType NoteProperty
    $outputdata += $computer
}

$outputdata | ConvertTo-Json