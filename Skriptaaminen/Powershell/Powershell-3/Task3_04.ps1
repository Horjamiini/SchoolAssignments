param (
    [string]$foldername,
    [string]$filename,
    [int]$number
    )

$folder = Test-Path $foldername

if ($folder -eq $true){
    Write-Host "Folder $foldername already exists!"
}

elseif ($folder -eq $false){
    Write-Host "I will create the folder $foldername and $number files to the folder"
    New-Item -Path $foldername -ItemType Directory
    for ($i = 0; $i -lt $number;$i++){
    $i | foreach-object{New-Item -Path $foldername\$_-$filename -ItemType File }
    }
    
    Write-Host "$number files created into the folder $foldername `n"
    $files = Get-ChildItem $foldername
    foreach($file in $files){
        $file.name
    }
}
