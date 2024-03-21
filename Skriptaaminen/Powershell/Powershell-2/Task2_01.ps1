$files = (Get-ChildItem $HOME -File | Measure-Object).count
Write-host "$files files found at $home"
