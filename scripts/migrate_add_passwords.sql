-- Migration: Add password column to Employees and Customers
-- Run this ONLY if your database already exists (tables were already created).
-- For fresh installations, just re-run create_database.sql and stored_procedures.sql.

USE My_Daniel;
GO

ALTER TABLE Employees ADD password NVARCHAR(100) NOT NULL DEFAULT '';
GO

ALTER TABLE Customers ADD password NVARCHAR(100) NOT NULL DEFAULT '';
GO

-- After running this, also drop and re-create the affected stored procedures:
--   sp_employees_create, sp_employees_update, sp_employees_get_all, sp_employees_get_by_id
--   sp_customers_create,  sp_customers_update,  sp_customers_get_all,  sp_customers_get_by_id
-- (Re-run stored_procedures.sql to recreate them, or use ALTER PROCEDURE manually.)
