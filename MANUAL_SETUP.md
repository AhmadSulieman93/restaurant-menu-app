# 🔧 إعداد Database يدوياً في Supabase

## ✅ إذا Connection String لا يعمل:

يمكنك إنشاء الـTables يدوياً في Supabase!

---

## 📋 الخطوات:

### 1. في Supabase Dashboard:

1. اذهب إلى: **SQL Editor** (من القائمة الجانبية)
2. اضغط **"New query"**
3. افتح الملف: `backend/RestaurantMenu.API/Migrations/SQL_SCRIPT.sql`
4. **انسخ** كل محتوى الملف
5. **الصقه** في SQL Editor
6. اضغط **"Run"**

---

### 2. بعد إنشاء الـTables:

ستحتاج إلى:
- تشغيل Backend (سيقوم بـ Seed Data تلقائياً)
- أو إضافة البيانات يدوياً

---

## ✅ بعد ذلك:

1. **شغّل Backend:**
   ```bash
   cd backend/RestaurantMenu.API
   dotnet run
   ```

2. **ستتم Seed Data تلقائياً** (الحسابات + المطاعم + الأصناف)

---

## 🔍 أو جرب Connection String من:

1. **Settings → Database → Connection pooling**
2. استخدم **Pooling URL** بدلاً من Direct Connection

---

## 💡 نصيحة:

**أرسل لي Connection String الكامل من Supabase** (بعد استبدال Password) وسأحدث الملفات مباشرة! 🚀

