$Who = whoami
$Date = Get-Date
$text1 = "Logged user is: $Who"
$text2 = " and today is: $Date"
$text12 = $text1 + $text2
Write-Host $text12
