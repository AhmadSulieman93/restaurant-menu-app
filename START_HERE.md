# 🚀 ابدأ من هنا - خطوات التشغيل الكاملة

## ❌ المشكلة الحالية:
"Failed to fetch" - يعني الـBackend غير مشغل أو Database غير موصول

---

## ✅ الحل - خطوات بسيطة:

### الخطوة 1: إعداد Database (اختر واحد)

#### خيار أ: Supabase (مجاني - الأسهل) ⭐
1. اذهب: https://supabase.com
2. Sign Up / Login
3. New Project
4. Settings → Database → Connection String
5. انسخ Connection String

#### خيار ب: محلي (PostgreSQL)
- تثبيت PostgreSQL
- إنشاء Database: `restaurant_menu_db`

---

### الخطوة 2: تحديث Backend Configuration

افتح: `backend/RestaurantMenu.API/appsettings.json`

**إذا استخدمت Supabase:**
```json
"ConnectionStrings": {
  "DefaultConnection": "postgresql://postgres:[PASSWORD]@db.[PROJECT].supabase.co:5432/postgres"
}
```

**إذا استخدمت محلي:**
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=restaurant_menu_db;Username=postgres;Password=YOUR_PASSWORD;Port=5432"
}
```

---

### الخطوة 3: تشغيل Backend

```bash
cd backend/RestaurantMenu.API

# تثبيت EF Tools (مرة واحدة فقط)
dotnet tool install --global dotnet-ef

# إنشاء Migration
dotnet ef migrations add InitialCreate

# تطبيق Migration (ينشئ Database + Tables)
dotnet ef database update

# تشغيل Backend
dotnet run
```

**✅ ستحدث تلقائياً:**
- ✅ إنشاء جميع الـTables
- ✅ إنشاء الحسابات (Admin + Owners)
- ✅ إنشاء المطاعم (2 مطاعم)
- ✅ إنشاء الأصناف (80+ صنف)

**النتيجة:** Backend يعمل على `http://localhost:5000`
**تأكد:** افتح http://localhost:5000 - يجب أن ترى Swagger UI

---

### الخطوة 4: تشغيل Frontend

```bash
# في Terminal جديد
cd C:\Projects\restaurant-menu-app

# تأكد من وجود .env.local (تم إنشاؤه)
# محتواه: NEXT_PUBLIC_API_URL=http://localhost:5000/api

# تشغيل Frontend
npm run dev
```

**النتيجة:** Frontend يعمل على `http://localhost:3001`

---

### الخطوة 5: تسجيل الدخول

افتح: http://localhost:3001/login

**استخدم:**
- Email: `admin@restaurantmenu.com`
- Password: `Admin@123`

---

## ✅ الحسابات الجاهزة:

| Role | Email | Password |
|------|-------|----------|
| Super Admin | admin@restaurantmenu.com | Admin@123 |
| Owner 1 | mario@marioskitchen.com | Mario@123 |
| Owner 2 | chef@tokyosushi.com | Tokyo@123 |

---

## 🔍 إذا لم يعمل:

### 1. تأكد Backend يعمل:
- افتح: http://localhost:5000
- يجب أن ترى Swagger UI

### 2. تأكد Database:
- تحقق من Connection String
- تأكد من أن Database موجودة ومتصلة

### 3. تأكد Frontend:
- تأكد من وجود `.env.local`
- تأكد من `NEXT_PUBLIC_API_URL=http://localhost:5000/api`

---

## 📝 ملاحظات مهمة:

✅ **Database Migration** - تعمل تلقائياً عند `dotnet ef database update`
✅ **Seed Data** - تعمل تلقائياً في Development Mode
✅ **كل شيء جاهز** - فقط شغّل Backend و Frontend!

---

## 🎉 جاهز!

بعد إكمال الخطوات، كل شيء سيعمل تلقائياً!

