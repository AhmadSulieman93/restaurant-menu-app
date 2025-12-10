# ⚡ الحل السريع - بدون Connection String!

## ✅ الخطوات:

### 1️⃣ افتح SQL Editor في Supabase:

1. من القائمة الجانبية: اضغط **SQL Editor**
2. اضغط **"New query"**

---

### 2️⃣ انسخ SQL Script:

1. افتح الملف: `backend/RestaurantMenu.API/Migrations/SQL_SCRIPT.sql`
2. **انسخ كل المحتوى**
3. **الصقه** في SQL Editor في Supabase
4. اضغط **"Run"** (أو F5)

---

### 3️⃣ شغّل Backend:

```bash
cd backend/RestaurantMenu.API
dotnet run
```

**✅ Backend سيتم Seed Data تلقائياً:**
- الحسابات
- المطاعم
- الأصناف

---

### 4️⃣ شغّل Frontend:

```bash
cd C:\Projects\restaurant-menu-app
npm run dev
```

---

### 5️⃣ سجّل دخول:

افتح: http://localhost:3001/login

- Email: `admin@restaurantmenu.com`
- Password: `Admin@123`

---

## 🎉 جاهز!

**لا تحتاج Connection String للـMigration - فقط أنشئ الـTables يدوياً!**

