# 🔍 كيفية العثور على Database Connection String في Supabase

## الخطوات المفصلة:

### 1. من صفحة Database الحالية:
- انظر إلى **القائمة الجانبية اليسرى**
- ابحث عن **Settings** (أيقونة الترس ⚙️ في الأسفل)

### 2. اضغط على Settings:
- ستجد قائمة جانبية:
  - General
  - API
  - **Database** ← اضغط هنا!
  - Auth
  - Storage
  - وغيرها...

### 3. اضغط على Database:
- ستفتح صفحة Database Settings

### 4. في صفحة Database Settings:
- انزل للأسفل
- ستجد قسم **"Connection string"** أو **"Connection pooling"**
- ستجد عدة خيارات:
  - URI
  - Connection pooling
  - Direct connection

### 5. اختر "URI" أو "Connection pooling":
- اضغط على Tab **"URI"**
- ستجد Connection String يبدأ بـ:
  ```
  postgresql://postgres.[PROJECT]:[PASSWORD]@...
  ```

### 6. انسخ Connection String:
- اضغط على زر **"Copy"** بجانب Connection String
- أو انسخ النص يدوياً

---

## 📸 بديل: استخدام Connection Pooling

إذا لم تجد "Connection string"، جرب:

1. في صفحة Database Settings
2. ابحث عن **"Connection pooling"**
3. انسخ Connection String من هناك

---

## ⚠️ مهم:

- ✅ **Connection String** يبدأ بـ `postgresql://`
- ❌ **ليس** API Key
- ❌ **ليس** Project URL

---

## 🎯 مثال Connection String:

```
postgresql://postgres.bxaapyvtgsfjieiacgqj:[YOUR-PASSWORD]@aws-0-us-east-1.pooler.supabase.com:6543/postgres
```

---

## 💡 نصيحة:

إذا لم تجد Connection String في Database Settings:
1. اذهب إلى **Settings → Database**
2. انزل للأسفل
3. ابحث عن **"Connection string"** أو **"Connection info"**
4. أو جرب **"Connection pooling"** tab

