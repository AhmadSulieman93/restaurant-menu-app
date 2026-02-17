# Login Still Not Working – Troubleshooting

If you see **"Failed to fetch"** or **CORS** errors pointing to `localhost:5000`, do this:

---

## 1. Check: Which Repo Is Vercel Using?

**Critical:** Vercel must deploy from **this repo** (with the proxy code).

1. Go to: https://vercel.com/ahmadadnan93s-projects/resturent-app/settings/git  
2. Check **"Connected Git Repository"**  
3. It must be: `AhmadSulieman93/restaurant-menu-app` (or wherever this project lives)  
4. If it shows a different repo (e.g. `AhmadAdnan93/app-restaurant`), **disconnect and reconnect** the correct repo

---

## 2. Push & Redeploy

Ensure the latest code is on GitHub and Vercel redeploys:

```powershell
cd c:\Projects\restaurant-menu-app
git add -A
git status
git commit -m "Fix: uploadApi use getApiBaseUrl"
git push origin main
```

Then in Vercel:

- Go to: https://vercel.com/ahmadadnan93s-projects/resturent-app  
- **Deployments** → latest deployment → **⋮** → **Redeploy**  
- Or push a new commit to trigger a deploy

---

## 3. Set BACKEND_API_URL on Vercel

The proxy needs your **Railway** backend URL. Without it, the proxy falls back to localhost and fails.

1. Go to: https://vercel.com/ahmadadnan93s-projects/resturent-app/settings/environment-variables  
2. Add (or edit):
   - **Name:** `BACKEND_API_URL`
   - **Value:** `https://YOUR-RAILWAY-URL/api`  
     (e.g. `https://restaurant-menu-app-production-xxxx.up.railway.app/api`)
   - **Environment:** Production (and Preview if you use it)
3. Click **Save**
4. **Redeploy** (Deployments → ⋮ → Redeploy)

---

## 4. Ensure Backend Runs on Railway

If the backend is not deployed or not reachable, login will fail with 502 or connection errors.

- Follow `COMPLETE_THIS_NOW.md` to deploy the .NET API on Railway  
- The Railway service must have a **Generated Domain**  
- CORS_ORIGINS must include `https://resturent-app-taupe.vercel.app`

---

## Checklist

- [ ] Vercel Git repo = this project (with proxy code)  
- [ ] Latest code pushed to `main`  
- [ ] Vercel redeployed after push  
- [ ] `BACKEND_API_URL` set on Vercel = `https://YOUR-RAILWAY-URL/api`  
- [ ] Backend deployed on Railway with domain  
- [ ] Railway CORS_ORIGINS includes `https://resturent-app-taupe.vercel.app`  

---

## What the Fix Does

- **Client (browser):** On `resturent-app-taupe.vercel.app`, the app calls `/api/backend/auth/login` (same-origin, no CORS)  
- **Vercel proxy:** Forwards to `BACKEND_API_URL/auth/login` (your Railway backend)  
- **Result:** Login works without the browser ever touching `localhost`
