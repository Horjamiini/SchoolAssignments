param(
    [string]$name = 'unknown',
    [int]$tries = 1
)
for ($i = 0;$i -lt $tries; $i++)
    {Write-Output("Hello $name!")
}