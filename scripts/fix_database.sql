-- =============================================================================
-- fix_database.sql
-- Run this in SSMS when the app crashes with "too many arguments" or
-- "Index was outside the bounds of the array" on the password column.
--
-- Safe to run multiple times — uses IF EXISTS / IF NOT EXISTS guards.
-- =============================================================================

USE My_Daniel;
GO

-- ─── Step 1: Add password column if missing ───────────────────────────────────

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('Employees') AND name = 'password'
)
BEGIN
    ALTER TABLE Employees ADD password NVARCHAR(100) NOT NULL DEFAULT '';
    PRINT 'Added password column to Employees.';
END
ELSE
    PRINT 'Employees.password already exists — skipped.';
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('Customers') AND name = 'password'
)
BEGIN
    ALTER TABLE Customers ADD password NVARCHAR(100) NOT NULL DEFAULT '';
    PRINT 'Added password column to Customers.';
END
ELSE
    PRINT 'Customers.password already exists — skipped.';
GO

-- ─── Step 2: Drop old stored procedures ──────────────────────────────────────

DROP PROCEDURE IF EXISTS sp_employees_create;
DROP PROCEDURE IF EXISTS sp_employees_update;
DROP PROCEDURE IF EXISTS sp_employees_get_all;
DROP PROCEDURE IF EXISTS sp_employees_get_by_id;
DROP PROCEDURE IF EXISTS sp_customers_create;
DROP PROCEDURE IF EXISTS sp_customers_update;
DROP PROCEDURE IF EXISTS sp_customers_get_all;
DROP PROCEDURE IF EXISTS sp_customers_get_by_id;
GO

PRINT 'Old stored procedures dropped.';
GO

-- ─── Step 3: Recreate stored procedures with password ────────────────────────

CREATE PROCEDURE sp_employees_create
    @employee_id NVARCHAR(20),
    @full_name   NVARCHAR(100),
    @role        NVARCHAR(50),
    @start_date  DATE,
    @phone       NVARCHAR(20),
    @email       NVARCHAR(100),
    @password    NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Employees (employee_id, full_name, role, start_date, phone, email, password)
    VALUES (@employee_id, @full_name, @role, @start_date, @phone, @email, @password);
END
GO

CREATE PROCEDURE sp_employees_update
    @employee_id NVARCHAR(20),
    @full_name   NVARCHAR(100),
    @role        NVARCHAR(50),
    @start_date  DATE,
    @phone       NVARCHAR(20),
    @email       NVARCHAR(100),
    @password    NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Employees
    SET full_name  = @full_name,
        role       = @role,
        start_date = @start_date,
        phone      = @phone,
        email      = @email,
        password   = @password
    WHERE employee_id = @employee_id;
END
GO

CREATE PROCEDURE sp_employees_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT employee_id, full_name, role, start_date, phone, email, password
    FROM Employees;
END
GO

CREATE PROCEDURE sp_employees_get_by_id
    @employee_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT employee_id, full_name, role, start_date, phone, email, password
    FROM Employees
    WHERE employee_id = @employee_id;
END
GO

CREATE PROCEDURE sp_customers_create
    @customer_id       NVARCHAR(20),
    @full_name         NVARCHAR(100),
    @phone             NVARCHAR(20),
    @email             NVARCHAR(100),
    @address           NVARCHAR(200),
    @birth_date        DATE,
    @start_date        DATE,
    @emergency_contact NVARCHAR(100),
    @payment_date      DATE,
    @customer_status   NVARCHAR(50),
    @payment_status    NVARCHAR(50),
    @password          NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Customers (
        customer_id, full_name, phone, email, address,
        birth_date, start_date, emergency_contact,
        payment_date, customer_status, payment_status, password
    )
    VALUES (
        @customer_id, @full_name, @phone, @email, @address,
        @birth_date, @start_date, @emergency_contact,
        @payment_date, @customer_status, @payment_status, @password
    );
END
GO

CREATE PROCEDURE sp_customers_update
    @customer_id       NVARCHAR(20),
    @full_name         NVARCHAR(100),
    @phone             NVARCHAR(20),
    @email             NVARCHAR(100),
    @address           NVARCHAR(200),
    @birth_date        DATE,
    @start_date        DATE,
    @emergency_contact NVARCHAR(100),
    @payment_date      DATE,
    @customer_status   NVARCHAR(50),
    @payment_status    NVARCHAR(50),
    @password          NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Customers
    SET full_name         = @full_name,
        phone             = @phone,
        email             = @email,
        address           = @address,
        birth_date        = @birth_date,
        start_date        = @start_date,
        emergency_contact = @emergency_contact,
        payment_date      = @payment_date,
        customer_status   = @customer_status,
        payment_status    = @payment_status,
        password          = @password
    WHERE customer_id = @customer_id;
END
GO

CREATE PROCEDURE sp_customers_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT customer_id, full_name, phone, email, address,
           birth_date, start_date, emergency_contact,
           payment_date, customer_status, payment_status, password
    FROM Customers;
END
GO

CREATE PROCEDURE sp_customers_get_by_id
    @customer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT customer_id, full_name, phone, email, address,
           birth_date, start_date, emergency_contact,
           payment_date, customer_status, payment_status, password
    FROM Customers
    WHERE customer_id = @customer_id;
END
GO

PRINT 'All stored procedures recreated successfully.';
GO
