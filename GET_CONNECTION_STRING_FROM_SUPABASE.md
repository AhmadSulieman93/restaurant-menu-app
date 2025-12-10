# 🔍 كيفية الحصول على Connection String الصحيح

## ⚠️ المشكلة:
Host name غير صحيح: `db.bxaapyvtgsfjieiacgqj.supabase.co` لا يعمل

---

## ✅ الحل في Supabase:

### 1. اذهب إلى Settings → Database

### 2. ابحث عن:

**في صفحة Database Settings:**
- **"Connection string"** section
- أو **"Connection info"** 
- أو **"Connection pooling"** tab

### 3. انسخ Connection String الكامل:

**يجب أن يكون مثل:**
```
postgresql://postgres.bxaapyvtgsfjieiacgqj:[PASSWORD]@aws-0-us-east-1.pooler.supabase.com:6543/postgres?pgbouncer=true
```

**أو:**
```
Host=aws-0-us-east-1.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.bxaapyvtgsfjieiacgqj;Password=[PASSWORD];
```

---

## 📋 معلومات مهمة:

من Project URL: `https://bxaapyvtgsfjieiacgqj.supabase.co`

**Host name قد يكون:**
- ❌ `db.bxaapyvtgsfjieiacgqj.supabase.co` (غير صحيح)
- ✅ `aws-0-us-east-1.pooler.supabase.com` (للـConnection Pooling)
- ✅ `db.PROJECT_REF.supabase.co` (Direct Connection - مختلف)

---

## 💡 بعد النسخ:

**أرسل لي Connection String الكامل** (بعد استبدال Password) وسأحدث الملفات مباشرة! 🚀

