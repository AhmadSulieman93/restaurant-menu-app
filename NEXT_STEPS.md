# 📋 الخطوات التالية - بعد إنشاء Supabase Project

## ✅ ما أنجزته:
- ✅ أنشأت Supabase Project
- ✅ Project URL: `https://bxaapyvtgsfjieiacgqj.supabase.co`

---

## 🔄 الخطوة التالية: الحصول على Database Connection String

### في Supabase Dashboard:

1. **من القائمة الجانبية اليسرى:**
   - اضغط على **Settings** (أيقونة الترس ⚙️)

2. **في صفحة Settings:**
   - اضغط على **Database** من القائمة

3. **في صفحة Database:**
   - ابحث عن قسم **"Connection string"** أو **"Connection pooling"**
   - اختر **"URI"** أو **"Connection pooling"**
   - ستجد Connection String يبدأ بـ: `postgresql://...`

4. **انسخ Connection String:**
   - اضغط على زر **Copy** بجانب Connection String
   - **مهم:** هذا مختلف عن API Key!

---

## 📝 الخطوة 2: تحديث Backend Configuration

افتح الملف: `backend/RestaurantMenu.API/appsettings.json`

**استبدل هذا:**
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=restaurant_menu_db;Username=postgres;Password=postgres;Port=5432"
}
```

**بهذا (الصق Connection String الذي نسخته):**
```json
"ConnectionStrings": {
  "DefaultConnection": "postgresql://postgres.[PROJECT]:[PASSWORD]@aws-0-[REGION].pooler.supabase.com:6543/postgres"
}
```

**مثال:**
```json
"ConnectionStrings": {
  "DefaultConnection": "postgresql://postgres.xxxxx:YOUR_PASSWORD@aws-0-us-east-1.pooler.supabase.com:6543/postgres"
}
```

---

## 🚀 الخطوة 3: تشغيل Backend

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
- ✅ إنشاء الحسابات (Admin + Owners)
- ✅ إنشاء المطاعم (2 مطاعم)
- ✅ إنشاء الأصناف (80+ صنف)

**النتيجة:** Backend يعمل على `http://localhost:5000`

---

## ✅ الخطوة 4: التحقق

افتح: http://localhost:5000

**يجب أن ترى:** Swagger UI (صفحة API Documentation)

---

## ✅ الخطوة 5: تشغيل Frontend

```bash
# في Terminal جديد
cd C:\Projects\restaurant-menu-app
npm run dev
```

**النتيجة:** Frontend يعمل على `http://localhost:3001`

---

## ✅ الخطوة 6: تسجيل الدخول

افتح: http://localhost:3001/login

**استخدم:**
- Email: `admin@restaurantmenu.com`
- Password: `Admin@123`

---

## 📍 ملخص:

1. ✅ Supabase Project - **تم**
2. ⏳ الحصول على Database Connection String - **الآن**
3. ⏳ تحديث `appsettings.json`
4. ⏳ تشغيل Backend
5. ⏳ تشغيل Frontend
6. ⏳ تسجيل الدخول

---

## 🔍 أين أجد Connection String؟

**في Supabase:**
- Settings → Database → Connection string → URI

**يجب أن يبدأ بـ:**
```
postgresql://postgres...
```

**ليس:**
- ❌ API Key
- ❌ Project URL
- ✅ Connection String فقط!

