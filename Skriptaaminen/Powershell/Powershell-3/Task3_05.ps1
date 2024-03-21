#Ei toimi

param (
    [string]$foldername,
    [string]$newname
    )

$folder = Test-Path $foldername

if ($folder -eq $true){
    $files = Get-ChildItem $foldername
    $filec = $files.count
    

    Write-Host "All $filec files will be renamed with name $newname"
    Do{
        $answer = Read-Host -Prompt "Y/N"
            if ($answer -notmatch "Y|N") {
            Write-Host "Please input Y or N"
            }
    }
        until ($answer -match "Y|N")
            if ($answer -eq "Y"){
                    $files | Get-ChildItem "" | ForEach-Object -Begin {$count = 1} -Process {Rename-Item $_ -NewName $newname$count.txt; $count++}
                        
            }
            
            elseif ($answer -eq "N"){
                Write-Host "I will not rename files "
            }
}

elseif ($folder -eq $false){
    Write-Host "Folder $foldername does not exist"
}



#for ($i = 0;$i -lt $filec;$i++){
    #$i | foreach-object{Rename-Item -Path $foldername\ -NewName $newname}
    #}
