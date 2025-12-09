# إعداد Database - خطوة بخطوة

## الطريقة السريعة (مع SQLite للتجربة)

إذا لم يكن لديك PostgreSQL، يمكن استخدام SQLite للتطوير المحلي:

### 1. تحديث Schema لاستخدام SQLite
```bash
# في prisma/schema.prisma - تم بالفعل!
# provider = "sqlite"
```

### 2. تشغيل Migration
```bash
cd backend/RestaurantMenu.API
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## الطريقة الكاملة (PostgreSQL)

### خيار 1: Supabase (مجاني)
1. اذهب إلى: https://supabase.com
2. Sign Up / Login
3. New Project
4. Settings > Database
5. انسخ Connection String
6. الصق في `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "postgresql://postgres:[YOUR-PASSWORD]@db.[PROJECT-REF].supabase.co:5432/postgres"
}
```

### خيار 2: محلي (PostgreSQL)
1. تثبيت PostgreSQL
2. أنشئ Database:
```sql
CREATE DATABASE restaurant_menu_db;
```
3. في `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=restaurant_menu_db;Username=postgres;Password=YOUR_PASSWORD;Port=5432"
}
```

---

## بعد إعداد Database:

```bash
cd backend/RestaurantMenu.API
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

ستتم Migration و Seed تلقائياً عند التشغيل!

