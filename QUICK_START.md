# ⚡ Quick Start - تشغيل سريع

## المشكلة: "Failed to fetch"

**السبب:** الـBackend غير مشغل أو Database غير موصول

---

## ✅ الحل السريع:

### الخطوة 1: إعداد Database (SQLite للتجربة السريعة)

إذا لم يكن لديك PostgreSQL، استخدم SQLite:

```bash
# 1. تحديث appsettings.json لاستخدام SQLite
```

أو استخدم Supabase (مجاني):
1. https://supabase.com → New Project
2. Settings → Database → Copy Connection String
3. الصق في `backend/RestaurantMenu.API/appsettings.json`

---

### الخطوة 2: تشغيل Backend

```bash
cd backend/RestaurantMenu.API

# تثبيت EF Tools (مرة واحدة فقط)
dotnet tool install --global dotnet-ef

# إنشاء Migration
dotnet ef migrations add InitialCreate

# تطبيق Migration + Seed Data
dotnet ef database update

# تشغيل Backend
dotnet run
```

**النتيجة:** Backend يعمل على `http://localhost:5000`

✅ Database سيتم إنشاؤها تلقائياً
✅ الحسابات سيتم إنشاؤها تلقائياً (Admin, Owners)
✅ المطاعم والبيانات سيتم إنشاؤها تلقائياً

---

### الخطوة 3: تشغيل Frontend

```bash
# في Terminal جديد
cd C:\Projects\restaurant-menu-app

# تأكد من وجود .env.local
# (تم إنشاؤه بالفعل)

# تشغيل
npm run dev
```

**النتيجة:** Frontend يعمل على `http://localhost:3001`

---

## ✅ الآن جرب Login:

- Email: `admin@restaurantmenu.com`
- Password: `Admin@123`

---

## 🔍 إذا لم يعمل:

1. **تأكد Backend يعمل:**
   - افتح: http://localhost:5000
   - يجب أن ترى Swagger UI

2. **تأكد Database:**
   - تحقق من Connection String في `appsettings.json`
   - تأكد من أن PostgreSQL يعمل (إذا تستخدمه)

3. **تحقق من CORS:**
   - تأكد أن `http://localhost:3001` موجود في `Cors:AllowedOrigins`

---

## 📝 ملاحظات:

- ✅ Database Migration تعمل تلقائياً عند تشغيل Backend
- ✅ Seed Data (الحسابات + المطاعم) تعمل تلقائياً
- ✅ كل شيء جاهز!

**جرب الآن!** 🚀

