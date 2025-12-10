# ✅ Connection String جاهز! - الخطوات التالية

## ✅ تم تحديث:
- ✅ `backend/RestaurantMenu.API/appsettings.json`
- ✅ `backend/RestaurantMenu.API/appsettings.Development.json`

---

## 🚀 الخطوات التالية:

### الخطوة 1: اذهب إلى Backend Folder

```bash
cd backend/RestaurantMenu.API
```

---

### الخطوة 2: تثبيت EF Tools (مرة واحدة فقط)

```bash
dotnet tool install --global dotnet-ef
```

---

### الخطوة 3: إنشاء Migration

```bash
dotnet ef migrations add InitialCreate
```

**ستُنشأ ملفات Migration في مجلد `Migrations`**

---

### الخطوة 4: تطبيق Migration + Seed Data

```bash
dotnet ef database update
```

**✅ ما سيحدث:**
- ✅ إنشاء جميع الـTables في Supabase Database
- ✅ إنشاء الحسابات (Admin + Owners)
- ✅ إنشاء المطاعم (2 مطاعم)
- ✅ إنشاء الأصناف (80+ صنف)

---

### الخطوة 5: تشغيل Backend

```bash
dotnet run
```

**النتيجة:** Backend يعمل على `http://localhost:5000`

**تأكد:** افتح http://localhost:5000 - يجب أن ترى Swagger UI

---

## ✅ الخطوة 6: تشغيل Frontend

في Terminal جديد:

```bash
cd C:\Projects\restaurant-menu-app
npm run dev
```

**النتيجة:** Frontend يعمل على `http://localhost:3001`

---

## ✅ الخطوة 7: تسجيل الدخول

افتح: http://localhost:3001/login

**استخدم:**
- Email: `admin@restaurantmenu.com`
- Password: `Admin@123`

---

## 🎉 كل شيء جاهز!

ابدأ من الخطوة 1 وشغّل Backend! 🚀

