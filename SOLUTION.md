# ✅ الحل الكامل - كل شيء جاهز!

## المشكلة:
"Failed to fetch" - الـBackend غير مشغل

---

## ✅ الحل:

### 1️⃣ إعداد Database (اختر واحد):

#### ⭐ خيار 1: Supabase (الأسهل - مجاني)
1. اذهب: https://supabase.com
2. Sign Up / Login  
3. New Project → اكتب اسم المشروع
4. Settings → Database → Connection String
5. انسخ Connection String

**مثال:**
```
postgresql://postgres:[PASSWORD]@db.xxxxx.supabase.co:5432/postgres
```

#### خيار 2: محلي
- تثبيت PostgreSQL
- إنشاء Database: `restaurant_menu_db`

---

### 2️⃣ تحديث Backend Configuration

افتح: `backend/RestaurantMenu.API/appsettings.json`

**الصق Connection String هنا:**
```json
"ConnectionStrings": {
  "DefaultConnection": "YOUR_CONNECTION_STRING_HERE"
}
```

---

### 3️⃣ تشغيل Backend

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

**✅ ما سيحدث تلقائياً:**
- ✅ إنشاء جميع الـTables في Database
- ✅ إنشاء Super Admin: `admin@restaurantmenu.com` / `Admin@123`
- ✅ إنشاء Owner 1: `mario@marioskitchen.com` / `Mario@123`
- ✅ إنشاء Owner 2: `chef@tokyosushi.com` / `Tokyo@123`
- ✅ إنشاء مطعمين (Mario's Italian + Tokyo Sushi)
- ✅ إنشاء 80+ صنف مع صور

**النتيجة:** Backend يعمل على `http://localhost:5000`

**تأكد:** افتح http://localhost:5000 - يجب أن ترى Swagger UI

---

### 4️⃣ تشغيل Frontend

```bash
# في Terminal جديد
cd C:\Projects\restaurant-menu-app

# .env.local موجود بالفعل ✅
# محتواه: NEXT_PUBLIC_API_URL=http://localhost:5000/api

# تشغيل
npm run dev
```

**النتيجة:** Frontend يعمل على `http://localhost:3001`

---

### 5️⃣ تسجيل الدخول

افتح: http://localhost:3001/login

**استخدم:**
- Email: `admin@restaurantmenu.com`
- Password: `Admin@123`

---

## ✅ الحسابات الجاهزة (تم إنشاؤها تلقائياً):

| Role | Email | Password |
|------|-------|----------|
| Super Admin | admin@restaurantmenu.com | Admin@123 |
| Owner 1 | mario@marioskitchen.com | Mario@123 |
| Owner 2 | chef@tokyosushi.com | Tokyo@123 |

---

## 🔍 التحقق من أن كل شيء يعمل:

1. **Backend:**
   - افتح: http://localhost:5000
   - يجب أن ترى Swagger UI

2. **Database:**
   - تحقق من Connection String
   - تأكد من أن Migration تمت بنجاح

3. **Frontend:**
   - تأكد من وجود `.env.local`
   - تأكد من `NEXT_PUBLIC_API_URL=http://localhost:5000/api`

---

## ✅ كل شيء جاهز!

- ✅ Database Schema جاهز
- ✅ Backend API كامل
- ✅ Frontend محدّث
- ✅ Seed Data (الحسابات + المطاعم + الأصناف)
- ✅ Migration تعمل تلقائياً

**فقط شغّل Backend و Frontend!** 🚀

