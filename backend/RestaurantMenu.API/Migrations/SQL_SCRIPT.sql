-- SQL Script to create tables manually in Supabase
-- Copy and paste this in Supabase SQL Editor

-- Users Table
CREATE TABLE IF NOT EXISTS "Users" (
    "Id" TEXT PRIMARY KEY,
    "Email" TEXT NOT NULL UNIQUE,
    "PasswordHash" TEXT NOT NULL,
    "FirstName" TEXT,
    "LastName" TEXT,
    "Phone" TEXT,
    "Role" INTEGER NOT NULL DEFAULT 2,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "EmailVerified" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW()
);

-- Restaurants Table
CREATE TABLE IF NOT EXISTS "Restaurants" (
    "Id" TEXT PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Slug" TEXT NOT NULL UNIQUE,
    "Logo" TEXT,
    "CoverImage" TEXT,
    "Description" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 2,
    "Phone" TEXT,
    "Email" TEXT,
    "Website" TEXT,
    "Address" TEXT,
    "City" TEXT,
    "Country" TEXT,
    "QrCode" TEXT NOT NULL UNIQUE,
    "IsPublished" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW()
);

-- RestaurantOwners Table
CREATE TABLE IF NOT EXISTS "RestaurantOwners" (
    "Id" TEXT PRIMARY KEY,
    "UserId" TEXT NOT NULL UNIQUE,
    "RestaurantId" TEXT NOT NULL UNIQUE,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    FOREIGN KEY ("UserId") REFERENCES "Users"("Id") ON DELETE CASCADE,
    FOREIGN KEY ("RestaurantId") REFERENCES "Restaurants"("Id") ON DELETE CASCADE
);

-- Categories Table
CREATE TABLE IF NOT EXISTS "Categories" (
    "Id" TEXT PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Description" TEXT,
    "Order" INTEGER NOT NULL DEFAULT 0,
    "IsActive" BOOLEAN NOT NULL DEFAULT TRUE,
    "RestaurantId" TEXT NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    FOREIGN KEY ("RestaurantId") REFERENCES "Restaurants"("Id") ON DELETE CASCADE
);

-- MenuItems Table
CREATE TABLE IF NOT EXISTS "MenuItems" (
    "Id" TEXT PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Description" TEXT NOT NULL,
    "Price" DECIMAL(10,2) NOT NULL,
    "Image" TEXT,
    "Order" INTEGER NOT NULL DEFAULT 0,
    "IsAvailable" BOOLEAN NOT NULL DEFAULT TRUE,
    "CategoryId" TEXT NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    FOREIGN KEY ("CategoryId") REFERENCES "Categories"("Id") ON DELETE CASCADE
);

-- Ratings Table
CREATE TABLE IF NOT EXISTS "Ratings" (
    "Id" TEXT PRIMARY KEY,
    "Value" INTEGER NOT NULL,
    "Comment" TEXT,
    "MenuItemId" TEXT NOT NULL,
    "CustomerId" TEXT,
    "CustomerName" TEXT,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    FOREIGN KEY ("MenuItemId") REFERENCES "MenuItems"("Id") ON DELETE CASCADE
);

-- Orders Table
CREATE TABLE IF NOT EXISTS "Orders" (
    "Id" TEXT PRIMARY KEY,
    "OrderNumber" TEXT NOT NULL UNIQUE,
    "RestaurantId" TEXT NOT NULL,
    "UserId" TEXT,
    "CustomerName" TEXT,
    "CustomerEmail" TEXT,
    "CustomerPhone" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "TotalAmount" DECIMAL(10,2) NOT NULL,
    "Notes" TEXT,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "ConfirmedAt" TIMESTAMP,
    "DeliveredAt" TIMESTAMP,
    FOREIGN KEY ("RestaurantId") REFERENCES "Restaurants"("Id")
);

-- OrderItems Table
CREATE TABLE IF NOT EXISTS "OrderItems" (
    "Id" TEXT PRIMARY KEY,
    "OrderId" TEXT NOT NULL,
    "MenuItemId" TEXT NOT NULL,
    "Quantity" INTEGER NOT NULL,
    "Price" DECIMAL(10,2) NOT NULL,
    "Subtotal" DECIMAL(10,2) NOT NULL,
    FOREIGN KEY ("OrderId") REFERENCES "Orders"("Id") ON DELETE CASCADE,
    FOREIGN KEY ("MenuItemId") REFERENCES "MenuItems"("Id")
);

-- Payments Table
CREATE TABLE IF NOT EXISTS "Payments" (
    "Id" TEXT PRIMARY KEY,
    "OrderId" TEXT NOT NULL UNIQUE,
    "UserId" TEXT,
    "Amount" DECIMAL(10,2) NOT NULL,
    "Method" INTEGER NOT NULL,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "PaypalOrderId" TEXT UNIQUE,
    "PaypalTransactionId" TEXT,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "CompletedAt" TIMESTAMP,
    FOREIGN KEY ("OrderId") REFERENCES "Orders"("Id") ON DELETE CASCADE,
    FOREIGN KEY ("UserId") REFERENCES "Users"("Id")
);

-- FileUploads Table
CREATE TABLE IF NOT EXISTS "FileUploads" (
    "Id" TEXT PRIMARY KEY,
    "FileName" TEXT NOT NULL,
    "OriginalName" TEXT NOT NULL,
    "MimeType" TEXT NOT NULL,
    "Size" BIGINT NOT NULL,
    "Url" TEXT NOT NULL,
    "UploadedBy" TEXT,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW()
);

-- Create Indexes
CREATE INDEX IF NOT EXISTS "IX_Users_Email" ON "Users"("Email");
CREATE INDEX IF NOT EXISTS "IX_Restaurants_Slug" ON "Restaurants"("Slug");
CREATE INDEX IF NOT EXISTS "IX_Categories_RestaurantId" ON "Categories"("RestaurantId");
CREATE INDEX IF NOT EXISTS "IX_MenuItems_CategoryId" ON "MenuItems"("CategoryId");
CREATE INDEX IF NOT EXISTS "IX_Orders_RestaurantId" ON "Orders"("RestaurantId");
CREATE INDEX IF NOT EXISTS "IX_Orders_OrderNumber" ON "Orders"("OrderNumber");

