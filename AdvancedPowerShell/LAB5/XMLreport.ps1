[xml]$xml = Get-Content inventory.xml

foreach ($computer in $xml.computers.computer) {

    $osinfo = Get-OSInfo -ComputerName $computer.name
    $computer.OSName = $osinfo.OSName
    $computer.OSArchitecture = $osinfo.OSArchitecture
    $computer.OSLanguage = $osinfo.OSLanguage
    $computer.OSVersion = $osinfo.OSVersion
    $computer.OSBuild = $osinfo.OSBuild

    $disks = Get-DiskInfo -computername $computer.name

    if ($computer.HasChildNodes) {
        $disks_node = $computer.SelectSingleNode('disks')
        $computer.RemoveChild($disks_node) | Out-Null
    }

    $disks_node = $xml.CreateElement('element','disks','')

    foreach ($disk in $disks) {
        $disk_node = $xml.CreateElement('element','disk','')
        $disk_node.InnerText = $disk.driveletter
        $disks_node.AppendChild($disk_node) | Out-Null
    }
    $computer.AppendChild($disks_node) | Out-Null
}

Get-OSInfo | Get-Member 

$xml.Save($(Get-Location).Path + '\Inventory.xml')