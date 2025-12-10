# 🔧 حل مشكلة Backend

## المشكلة:
- ❌ Backend لا يعمل على localhost:5000
- ❌ Login يفشل (Failed to fetch)

---

## ✅ الحل:

### 1. تأكد أن Backend يعمل:

في Terminal، شغّل:
```bash
cd backend/RestaurantMenu.API
dotnet run
```

**يجب أن ترى:**
```
Now listening on: http://localhost:5000
```

---

### 2. إذا كان هناك خطأ في Connection String:

قد تحتاج لتجربة Connection String مختلف. في Supabase:
- اذهب إلى: **Settings → Database**
- ابحث عن **"Connection info"** أو **"Connection string"**
- جرب **"Connection pooling"** tab

---

### 3. اختبار الاتصال:

افتح: http://localhost:5000

**يجب أن ترى:** Swagger UI

---

### 4. إذا كان Backend لا يعمل:

**تحقق من:**
- هل هناك أخطاء في Terminal عند تشغيل `dotnet run`?
- هل Connection String صحيح؟
- هل الـTables موجودة في Supabase?

---

## 🔍 خطوات التشخيص:

1. شغّل Backend: `dotnet run`
2. ابحث عن أخطاء في Terminal
3. تأكد أن Port 5000 متاح
4. تحقق من Connection String

---

## 💡 نصيحة:

**إذا لم يعمل Backend:**
- أرسل لي الأخطاء من Terminal
- أو أخبرني ماذا ترى عند تشغيل `dotnet run`

