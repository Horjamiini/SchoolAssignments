param(
    [string]$a,
    [string]$b,
    [string]$c
)
Write-Host "Parameters are: $a $b $c"
$abc = $a, $b, $c | Sort-Object {$_.length}

Write-Host "Your ordered words are: $abc"