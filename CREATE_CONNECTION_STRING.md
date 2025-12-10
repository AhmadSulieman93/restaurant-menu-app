# 🔗 بناء Connection String يدوياً

## ✅ المعلومات التي لدينا:

من Supabase Project:
- **Project Reference:** `bxaapyvtgsfjieiacgqj`
- **Host:** `aws-0-us-east-1.pooler.supabase.com` (أو مشابه)
- **Port:** `6543` (للـConnection Pooling) أو `5432` (للـDirect Connection)

---

## 📝 نحتاج:

1. **Database Password** - من صفحة Database Settings
   - ابحث عن **"Database password"**
   - أو اضغط **"Reset database password"** إذا لم تكن تعرفه

---

## 🔨 بناء Connection String:

### خيار 1: Connection Pooling (موصى به):

```
postgresql://postgres.bxaapyvtgsfjieiacgqj:[YOUR-PASSWORD]@aws-0-us-east-1.pooler.supabase.com:6543/postgres
```

### خيار 2: Direct Connection:

```
postgresql://postgres.bxaapyvtgsfjieiacgqj:[YOUR-PASSWORD]@aws-0-us-east-1.pooler.supabase.com:5432/postgres
```

---

## 🔍 كيفية الحصول على Database Password:

1. في صفحة **Database Settings** (الصفحة الحالية)
2. ابحث عن قسم **"Database password"**
3. إذا لم يكن موجوداً:
   - اضغط **"Reset database password"**
   - سيتم إنشاء كلمة مرور جديدة
   - **انسخها فوراً** (لن تتمكن من رؤيتها مرة أخرى!)

---

## ⚡ الحل السريع:

1. في صفحة Database Settings
2. ابحث عن **"Connection string"** أو **"Connection info"**
3. أو جرب التمرير للأسفل في الصفحة
4. ستجد Connection String جاهز!

---

## 📋 أو أخبرني:

أرسل لي:
1. **Database Password** (من صفحة Database Settings)
2. وسأبني لك Connection String جاهز! 🚀

