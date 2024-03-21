$path = Read-Host "Please, give the folder to search"
$things = (Get-ChildItem $path | Measure-Object).count
Write-Host "$things files and folders found at $path"