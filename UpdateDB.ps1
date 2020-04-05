$r = Invoke-RestMethod https://raw.githubusercontent.com/khaffner/booze/12bd02b9a9e85cc5dc7a38d2c4e081e6cc784fed/dump.json

Write-Host "Updating DB..." -ForegroundColor Yellow
$r | ForEach-Object {
    $b = $PSItem | ConvertTo-Json
    $body = [System.Text.Encoding]::UTF8.GetBytes($b)

    Invoke-RestMethod -Method Post -Uri http://172.18.0.2/api/BoozeItems -Body $body -ContentType application/json | Out-Null
}
Write-Host "DB update done!" -ForegroundColor Green