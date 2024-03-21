$download = New-Object System.Net.WebClient
$url = 'https://file-examples-com.github.io/uploads/2017/10/file_example_PNG_500kB.png'
$outputfile = "$((New-TemporaryFile).FullName).png"
$download.DownloadFile($url,$outputfile)