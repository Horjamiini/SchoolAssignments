$currentUser = [System.Security.Principal.WindowsIdentity]::GetCurrent()
$principal = [System.Security.Principal.WindowsPrincipal]$currentUser
$role = [System.Security.Principal.WindowsBuiltInRole]::Administrator

$principal.IsInRole($role)