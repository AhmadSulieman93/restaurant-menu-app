# 🔧 إصلاح Connection String

## المشكلة:
Connection String الحالي لا يعمل.

---

## ✅ الحل:

### في Supabase Dashboard:

1. اذهب إلى: **Settings → Database**
2. انزل للأسفل في الصفحة
3. ابحث عن قسم **"Connection string"** أو **"Connection pooling"**
4. ستجد Connection String جاهز!

---

## 📋 أو استخدم هذا التنسيق:

في صفحة Database Settings، يجب أن ترى Connection String جاهز مثل:

```
postgresql://postgres.bxaapyvtgsfjieiacgqj:[PASSWORD]@aws-0-[REGION].pooler.supabase.com:6543/postgres?pgbouncer=true
```

**أو:**

```
postgresql://postgres:[PASSWORD]@db.bxaapyvtgsfjieiacgqj.supabase.co:5432/postgres
```

---

## ⚡ الحل السريع:

1. في Supabase: **Settings → Database**
2. انزل للأسفل
3. ابحث عن **"Connection string"**
4. **انسخ** Connection String الجاهز
5. **الصقه** في `appsettings.json`

---

## 🔍 إذا لم تجده:

جرب البحث عن:
- **"Connection info"**
- **"Connection pooling"**
- **"Database URL"**

أو أخبرني وسأساعدك في العثور عليه! 🚀

