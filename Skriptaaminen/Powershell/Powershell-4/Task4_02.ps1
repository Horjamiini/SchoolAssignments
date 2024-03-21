function dirf2{
param($Extension)
Get-ChildItem $HOME | Where Name -like *.$Extension |  Format-Table Name, Length, LastWriteTime 
}