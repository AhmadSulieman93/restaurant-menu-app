# 🔄 How to Restart the Backend

## The Error You're Seeing:
```
The file is locked by: "RestaurantMenu.API (53060)"
```

This happens when you try to rebuild while the backend is already running.

---

## ✅ Solution: Stop First, Then Restart

### Option 1: Stop in the Terminal (Recommended)
1. In the terminal where `dotnet run` is running
2. Press **Ctrl+C** to stop it
3. Wait 2-3 seconds
4. Run `dotnet run` again

### Option 2: Stop via PowerShell
```powershell
# Find and stop the process
Get-Process | Where-Object {$_.ProcessName -eq "dotnet" -or $_.ProcessName -like "*RestaurantMenu*"} | Stop-Process -Force

# Wait a moment
Start-Sleep -Seconds 2

# Then restart
cd C:\Projects\restaurant-menu-app\backend\RestaurantMenu.API
dotnet run
```

### Option 3: Stop by Port
```powershell
# Find process using port 5000
$process = Get-NetTCPConnection -LocalPort 5000 -ErrorAction SilentlyContinue | Select-Object -ExpandProperty OwningProcess -Unique

# Stop it
if ($process) { Stop-Process -Id $process -Force }

# Wait and restart
Start-Sleep -Seconds 2
cd C:\Projects\restaurant-menu-app\backend\RestaurantMenu.API
dotnet run
```

---

## ⚠️ When Do You Need to Restart?

You only need to restart the backend when:
- ✅ You change backend code (C# files)
- ✅ You update `appsettings.json`
- ✅ You add new dependencies

You DON'T need to restart for:
- ❌ Frontend changes (Next.js auto-reloads)
- ❌ Database changes (handled automatically)
- ❌ Just viewing the app

---

## 💡 Pro Tip

**If the backend is already running and working fine, you don't need to restart it!**

Only restart when you make backend code changes.

---

## 🎯 Current Status

Your backend is running fine on port 5000. Unless you're making backend code changes, you can leave it running! 🚀

