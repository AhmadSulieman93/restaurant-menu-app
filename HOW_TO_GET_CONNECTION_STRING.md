# 🔗 كيفية الحصول على Connection String من Supabase

## 📍 الخطوات:

### 1. في Supabase Dashboard:

1. اذهب إلى: **Settings** (⚙️ في القائمة الجانبية)
2. اضغط على **Database**
3. **انزل للأسفل** في الصفحة

### 2. ابحث عن:

- **"Connection string"** section
- أو **"Connection pooling"** section
- أو **"Connection info"** section

### 3. ستجد Tabs:

- **URI** ← اختر هذا!
- **Connection pooling**
- **Direct connection**

### 4. انسخ Connection String:

- يجب أن يبدأ بـ: `postgresql://...`
- أو: `Host=...`

---

## 📋 مثال Connection String:

```
postgresql://postgres.bxaapyvtgsfjieiacgqj:[PASSWORD]@aws-0-us-east-1.pooler.supabase.com:6543/postgres?pgbouncer=true
```

أو:

```
Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.bxaapyvtgsfjieiacgqj;Password=[PASSWORD];Pooling=true;
```

---

## ⚡ بعد النسخ:

1. افتح: `backend/RestaurantMenu.API/appsettings.json`
2. استبدل `REPLACE_WITH_CONNECTION_STRING_FROM_SUPABASE` بـ Connection String الذي نسخته
3. احفظ الملف
4. جرب: `dotnet ef database update`

---

## 💡 نصيحة:

إذا كان Connection String يبدأ بـ `postgresql://`، يمكن استخدامه مباشرة.

إذا لم تجد Connection String جاهز، أخبرني وسأساعدك في بناء واحد! 🚀

