$port = '55085'
$sln = Get-ChildItem -Filter *.sln | Select-Object -First 1
if ($sln) {
    $slnContent = Get-Content $sln.FullName -Raw
    if ($slnContent -match 'localhost_(\d+)') {
        $port = $Matches[1]
    } elseif ($slnContent -match 'VWDPort = "(\d+)"') {
        $port = $Matches[1]
    }
}
$settingsPath = "$PSScriptRoot/settings.json"
$settings = if (Test-Path $settingsPath) {
    Get-Content $settingsPath -Raw | ConvertFrom-Json
} else {
    [PSCustomObject]@{}
}
if ($settings.'iisexpress.port' -ne $port) {
    $settings | Add-Member -NotePropertyName 'iisexpress.port' -NotePropertyValue $port -Force
    $settings | ConvertTo-Json | Out-File $settingsPath -Encoding utf8
}
Get-Process iisexpress -ErrorAction SilentlyContinue | Stop-Process -Force

# 프로젝트 루트를 루트로 사용
# $sitePath = (Resolve-Path "$PSScriptRoot/..").Path

# 01.Office 폴더를 루트로 사용
$sitePath = Join-Path (Resolve-Path "$PSScriptRoot/..").Path "01.Office"
# 04.Pda 폴더를 /PDA 경로로 매핑
$pdaPath = Join-Path (Resolve-Path "$PSScriptRoot/..").Path "04.Pda"
$configPath = "$PSScriptRoot\applicationhost.config"

# Generate custom applicationhost.config to allow external IP binding (*:port:*)
Copy-Item "C:\Program Files\IIS Express\config\templates\PersonalWebServer\applicationhost.config" $configPath -Force
$xml = [xml](Get-Content $configPath)
$sites = $xml.configuration.'system.applicationHost'.sites
$sites.site | ForEach-Object { [void]$sites.RemoveChild($_) }
$newSite = $xml.CreateElement("site")
$newSite.SetAttribute("name", "Development Web Site")
$newSite.SetAttribute("id", "1")
$newSite.SetAttribute("serverAutoStart", "true")

# 01.Office (루트: /)
$app = $xml.CreateElement("application")
$app.SetAttribute("path", "/")
$vdir = $xml.CreateElement("virtualDirectory")
$vdir.SetAttribute("path", "/")
$vdir.SetAttribute("physicalPath", $sitePath)
[void]$app.AppendChild($vdir)
[void]$newSite.AppendChild($app)

# 04.Pda (경로: /PDA)
if (Test-Path $pdaPath) {
    $pdaApp = $xml.CreateElement("application")
    $pdaApp.SetAttribute("path", "/PDA")
    $pdaVdir = $xml.CreateElement("virtualDirectory")
    $pdaVdir.SetAttribute("path", "/")
    $pdaVdir.SetAttribute("physicalPath", $pdaPath)
    [void]$pdaApp.AppendChild($pdaVdir)
    [void]$newSite.AppendChild($pdaApp)
}
$bindings = $xml.CreateElement("bindings")
$binding = $xml.CreateElement("binding")
$binding.SetAttribute("protocol", "http")
$binding.SetAttribute("bindingInformation", "*:$($port):*")
[void]$bindings.AppendChild($binding)
[void]$newSite.AppendChild($bindings)
[void]$sites.AppendChild($newSite)
$xml.Save($configPath)

& 'C:\Program Files\IIS Express\iisexpress.exe' /config:"$configPath" /site:"Development Web Site"
