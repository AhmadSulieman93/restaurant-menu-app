# 🔧 Database Connection Issue - How to Fix

## Current Problem:
Getting error: **"XX000: Tenant or user not found"**

This means the connection is working, but the **username or password is incorrect**.

---

## ✅ Solution: Get the Correct Connection String from Supabase

### Step 1: Go to Supabase Dashboard
1. Open: https://supabase.com/dashboard
2. Select your project: `bxaapyvtgsfjieiacgqj`

### Step 2: Get Connection String
1. Go to: **Settings → Database**
2. Scroll down to **"Connection string"** section
3. You'll see tabs: **URI**, **Connection pooling**, **Direct connection**

### Step 3: Copy the Connection String

**Option A: Use Connection Pooling (Recommended)**
- Click on **"Connection pooling"** tab
- Copy the connection string (it will look like):
  ```
  postgresql://postgres.bxaapyvtgsfjieiacgqj:[PASSWORD]@aws-0-us-east-1.pooler.supabase.com:6543/postgres
  ```

**Option B: Use Direct Connection**
- Click on **"URI"** or **"Direct connection"** tab
- Copy the connection string (it will look like):
  ```
  postgresql://postgres:[PASSWORD]@db.bxaapyvtgsfjieiacgqj.supabase.co:5432/postgres
  ```

### Step 4: Convert to .NET Format

If you got a `postgresql://` URI, convert it to .NET format:

**For Pooling:**
```
Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.bxaapyvtgsfjieiacgqj;Password=[YOUR-PASSWORD];SSL Mode=Require;Trust Server Certificate=true;
```

**For Direct:**
```
Host=db.bxaapyvtgsfjieiacgqj.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=[YOUR-PASSWORD];SSL Mode=Require;Trust Server Certificate=true;
```

### Step 5: Update the Connection String

1. Open: `backend/RestaurantMenu.API/appsettings.json`
2. Replace the `DefaultConnection` value with your new connection string
3. **Make sure to use the actual password** (not `[YOUR-PASSWORD]`)

### Step 6: Restart Backend

```powershell
# Stop the backend (Ctrl+C in the terminal)
# Then restart:
cd backend\RestaurantMenu.API
dotnet run
```

---

## 🔍 If You Don't Know the Password

1. In Supabase: **Settings → Database**
2. Look for **"Database password"** section
3. If you don't see it, click **"Reset database password"**
4. **Copy the new password immediately** (you won't see it again!)
5. Use this password in the connection string

---

## ⚠️ Important Notes

- The password in the connection string must match the Supabase database password
- The username format differs:
  - **Pooler**: `postgres.bxaapyvtgsfjieiacgqj` (with project ref)
  - **Direct**: `postgres` (just postgres)
- Make sure you're using the correct password (not the Supabase account password)

---

## ✅ After Fixing

Once you update the connection string with the correct password:
1. Restart the backend
2. Try logging in again at http://localhost:3001/login
3. It should work! 🎉

---

**Need help?** Share the connection string format you see in Supabase (with password hidden) and I'll help you format it correctly!



