$Num1 = Read-Host "Give an integer"
$Num2 = Read-Host "Give another integer"
$Num1 = [int]$Num1
$Num2 = [int]$Num2
$Sum = $Num1 + $Num2
$Subs = $Num1 - $Num2
$Multi = $Num1 * $Num2
$Divi = $Num1 / $Num2
Write-Host "Sum is $Sum" 
Write-Host "Substraction is $Subs"
Write-Host "Multiplication is $Multi"
Write-Host "Division is $Divi"
