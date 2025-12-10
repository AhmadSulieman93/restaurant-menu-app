# 🔍 How to Find Connection String in Supabase - Step by Step

## You're Currently In:
- **Schema Visualizer** (Database Management section)

## ✅ Where to Go:

### Step 1: Look at the LEFT SIDEBAR
You should see a section called **"CONFIGURATION"**

### Step 2: Click on "Settings"
Under the **"CONFIGURATION"** section, click on **"Settings"**

### Step 3: Click on "Database" Tab
Once you're in Settings, you'll see tabs at the top:
- General
- API
- **Database** ← Click here!
- Auth
- Storage
- etc.

### Step 4: Scroll Down
In the Database settings page, scroll down. You'll find:
- **Connection string** section
- Or **"Connection pooling"** section
- Or **"Connection info"** section

---

## 📋 Alternative: Direct URL

If you can't find it, try going directly to:
```
https://supabase.com/dashboard/project/bxaapyvtgsfjieiacgqj/settings/database
```

(Replace `bxaapyvtgsfjieiacgqj` with your project ID if different)

---

## 🔍 What to Look For:

You should see something like:

**Connection string:**
```
postgresql://postgres.bxaapyvtgsfjieiacgqj:[YOUR-PASSWORD]@aws-0-us-east-1.pooler.supabase.com:6543/postgres
```

**Or tabs showing:**
- URI
- Connection pooling  
- Direct connection

---

## 💡 If You Still Can't Find It:

### Option 1: Check "Connection Pooling" Tab
Look for a tab called **"Connection pooling"** - the connection string is usually there.

### Option 2: Look for "Connection Info"
Some Supabase versions show it as "Connection info" instead of "Connection string"

### Option 3: Check "Database URL"
Sometimes it's labeled as "Database URL"

---

## 🚨 If You Need to Reset Password:

1. In the same Database Settings page
2. Look for **"Database password"** section
3. Click **"Reset database password"**
4. **Copy the new password immediately!**
5. Then construct the connection string manually (see below)

---

## 🔨 Manual Construction (If Needed):

If you have the password but can't find the connection string, I can help you build it:

**For Connection Pooling:**
```
Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.bxaapyvtgsfjieiacgqj;Password=[YOUR-PASSWORD];SSL Mode=Require;Trust Server Certificate=true;
```

**For Direct Connection:**
```
Host=db.bxaapyvtgsfjieiacgqj.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=[YOUR-PASSWORD];SSL Mode=Require;Trust Server Certificate=true;
```

---

## 📸 Screenshot Locations:

The connection string is usually found:
- At the bottom of the Database Settings page
- In a section labeled "Connection string" or "Connection info"
- Sometimes in a collapsible section - try clicking to expand

---

**Try clicking on "Settings" in the left sidebar, then "Database" tab, and scroll down!** 🚀

