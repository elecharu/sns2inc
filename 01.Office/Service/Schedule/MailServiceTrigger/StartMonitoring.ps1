### SET FOLDER TO WATCH + FILES TO WATCH + SUBFOLDERS YES/NO
    $watcher = New-Object System.IO.FileSystemWatcher
    $watcher.Path = "D:\ITSCO\Hmail\hMailServer\Data\yeungjin.co.kr"
    $watcher.Filter = "*.*"
    $watcher.IncludeSubdirectories = $true
    $watcher.EnableRaisingEvents = $true
    $working = 0
    $test = ""

### DEFINE ACTIONS AFTER AN EVENT IS DETECTED
    $action = { $path = $Event.SourceEventArgs.FullPath
                $info = $path.Replace("D:\ITSCO\Hmail\hMailServer\Data\","").Split("\")
                $infoleng = $info.Length
                $domain = $info[0]
                $id = $info[1]
                $changeType = $Event.SourceEventArgs.ChangeType
                $logline = "$(Get-Date), $changeType, $path"

                Set-ExecutionPolicy Bypass -Force
                if($infoleng -eq 4){

                    Add-content "D:\ITSCO\MailService_HOST\Log\EventLog.txt" -value "$logline"
                    try{
                        Start-Process -FilePath "D:\ITSCO\MailService_HOST\MailServiceTrigger.exe" -ArgumentList "$id $domain"
                    }
                    catch{
                        Write-Host $_.Exception.Message -ForegroundColor Yellow
                    }
                    ###Invoke-item C:\Users\Administrator\Desktop\MailServiceDay.exe

                    #if($test -eq $id){
                    #    $working++
                    #}
                    #else{
                    #    $working = 1
                    #}
                    #if($working -eq 1){
                    #    $test = $id
                    #    Add-content "M:\Program Files (x86)\ITSCO\MailService_HOST\Log\EventLog.txt" -value "$logline"
                    #    try{
                    #        Start-Process -FilePath "M:\Program Files (x86)\ITSCO\MailService_HOST\dir\MailServiceTrigger.exe" -ArgumentList "$id $domain"
                    #    }
                    #    catch{
                    #        Write-Host $_.Exception.Message -ForegroundColor Yellow
                    #    }
                        ###Invoke-item C:\Users\Administrator\Desktop\MailServiceDay.exe
                        
                    #}    
                    #else{
                    #    $working--
                    #}          
                }  
              }    
### DECIDE WHICH EVENTS SHOULD BE WATCHED 
    Register-ObjectEvent $watcher "Created" -Action $action
    Register-ObjectEvent $watcher "Changed" -Action $action
    ###Register-ObjectEvent $watcher "Deleted" -Action $action
    ###Register-ObjectEvent $watcher "Renamed" -Action $action
    while ($true) {sleep 5}