# 🚀 الخطوات التالية - تشغيل Backend

## ✅ تم تحديث Connection String!

---

## 🎯 الخطوة 1: تشغيل Backend

افتح Terminal جديد واكتب:

```bash
cd backend/RestaurantMenu.API
```

ثم:

```bash
# تثبيت EF Tools (مرة واحدة فقط)
dotnet tool install --global dotnet-ef
```

ثم:

```bash
# إنشاء Migration
dotnet ef migrations add InitialCreate
```

ثم:

```bash
# تطبيق Migration + Seed Data
dotnet ef database update
```

ثم:

```bash
# تشغيل Backend
dotnet run
```

---

## ✅ ما سيحدث تلقائياً:

- ✅ إنشاء جميع الـTables في Database
- ✅ إنشاء Super Admin: `admin@restaurantmenu.com` / `Admin@123`
- ✅ إنشاء Owner 1: `mario@marioskitchen.com` / `Mario@123`
- ✅ إنشاء Owner 2: `chef@tokyosushi.com` / `Tokyo@123`
- ✅ إنشاء مطعمين (Mario's Italian + Tokyo Sushi)
- ✅ إنشاء 80+ صنف مع صور

---

## ✅ الخطوة 2: التحقق

افتح: http://localhost:5000

**يجب أن ترى:** Swagger UI (صفحة API Documentation)

---

## ✅ الخطوة 3: تشغيل Frontend

في Terminal جديد:

```bash
cd C:\Projects\restaurant-menu-app
npm run dev
```

---

## ✅ الخطوة 4: تسجيل الدخول

افتح: http://localhost:3001/login

**استخدم:**
- Email: `admin@restaurantmenu.com`
- Password: `Admin@123`

---

## 🎉 جاهز!

كل شيء جاهز الآن! فقط شغّل Backend و Frontend! 🚀

