USE My_Daniel;
GO

-- =============================================================================
-- My Daniel Center Management System — CRUD Stored Procedures
-- Source:    scripts/create_database.sql
-- Generated: 2026-06-20
--
-- Convention: sp_<table>_create / _update / _delete / _get_all / _get_by_id
-- Rules:
--   • PK is the first parameter of every _create SP.
--   • No SCOPE_IDENTITY(). PKs are assigned in C#.
--   • No business logic — mechanical CRUD only.
--   • SET NOCOUNT ON in every procedure.
--   • Nullable parameters default to NULL.
-- =============================================================================


-- =============================================================================
-- Employees
-- =============================================================================

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

CREATE PROCEDURE sp_employees_delete
    @employee_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Employees WHERE employee_id = @employee_id;
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


-- =============================================================================
-- Customers
-- =============================================================================

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

CREATE PROCEDURE sp_customers_delete
    @customer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Customers WHERE customer_id = @customer_id;
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


-- =============================================================================
-- Boats
-- =============================================================================

CREATE PROCEDURE sp_boats_create
    @boatNumber_id           INT,
    @boat_type               NVARCHAR(50),
    @water_craft_name        NVARCHAR(100),
    @boat_status             NVARCHAR(50),
    @purchase_date           DATE,
    @license_date            DATE,
    @annual_maintenance_date DATE,
    @source_type             NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Boats (
        boatNumber_id, boat_type, water_craft_name, boat_status,
        purchase_date, license_date, annual_maintenance_date, source_type
    )
    VALUES (
        @boatNumber_id, @boat_type, @water_craft_name, @boat_status,
        @purchase_date, @license_date, @annual_maintenance_date, @source_type
    );
END
GO

CREATE PROCEDURE sp_boats_update
    @boatNumber_id           INT,
    @boat_type               NVARCHAR(50),
    @water_craft_name        NVARCHAR(100),
    @boat_status             NVARCHAR(50),
    @purchase_date           DATE,
    @license_date            DATE,
    @annual_maintenance_date DATE,
    @source_type             NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Boats
    SET boat_type               = @boat_type,
        water_craft_name        = @water_craft_name,
        boat_status             = @boat_status,
        purchase_date           = @purchase_date,
        license_date            = @license_date,
        annual_maintenance_date = @annual_maintenance_date,
        source_type             = @source_type
    WHERE boatNumber_id = @boatNumber_id;
END
GO

CREATE PROCEDURE sp_boats_delete
    @boatNumber_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Boats WHERE boatNumber_id = @boatNumber_id;
END
GO

CREATE PROCEDURE sp_boats_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT boatNumber_id, boat_type, water_craft_name, boat_status,
           purchase_date, license_date, annual_maintenance_date, source_type
    FROM Boats;
END
GO

CREATE PROCEDURE sp_boats_get_by_id
    @boatNumber_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT boatNumber_id, boat_type, water_craft_name, boat_status,
           purchase_date, license_date, annual_maintenance_date, source_type
    FROM Boats
    WHERE boatNumber_id = @boatNumber_id;
END
GO


-- =============================================================================
-- ExternalCenters
-- =============================================================================

CREATE PROCEDURE sp_external_centers_create
    @external_center_id INT,
    @center_name        NVARCHAR(100),
    @contact_name       NVARCHAR(100),
    @phone              NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ExternalCenters (external_center_id, center_name, contact_name, phone)
    VALUES (@external_center_id, @center_name, @contact_name, @phone);
END
GO

CREATE PROCEDURE sp_external_centers_update
    @external_center_id INT,
    @center_name        NVARCHAR(100),
    @contact_name       NVARCHAR(100),
    @phone              NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ExternalCenters
    SET center_name  = @center_name,
        contact_name = @contact_name,
        phone        = @phone
    WHERE external_center_id = @external_center_id;
END
GO

CREATE PROCEDURE sp_external_centers_delete
    @external_center_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM ExternalCenters WHERE external_center_id = @external_center_id;
END
GO

CREATE PROCEDURE sp_external_centers_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT external_center_id, center_name, contact_name, phone
    FROM ExternalCenters;
END
GO

CREATE PROCEDURE sp_external_centers_get_by_id
    @external_center_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT external_center_id, center_name, contact_name, phone
    FROM ExternalCenters
    WHERE external_center_id = @external_center_id;
END
GO


-- =============================================================================
-- Activities
-- =============================================================================

CREATE PROCEDURE sp_activities_create
    @activityNum_id INT,
    @activity_type  NVARCHAR(50),
    @date_time      DATETIME2,
    @location       NVARCHAR(100),
    @age_group      NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Activities (activityNum_id, activity_type, date_time, location, age_group)
    VALUES (@activityNum_id, @activity_type, @date_time, @location, @age_group);
END
GO

CREATE PROCEDURE sp_activities_update
    @activityNum_id INT,
    @activity_type  NVARCHAR(50),
    @date_time      DATETIME2,
    @location       NVARCHAR(100),
    @age_group      NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Activities
    SET activity_type = @activity_type,
        date_time     = @date_time,
        location      = @location,
        age_group     = @age_group
    WHERE activityNum_id = @activityNum_id;
END
GO

CREATE PROCEDURE sp_activities_delete
    @activityNum_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Activities WHERE activityNum_id = @activityNum_id;
END
GO

CREATE PROCEDURE sp_activities_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT activityNum_id, activity_type, date_time, location, age_group
    FROM Activities;
END
GO

CREATE PROCEDURE sp_activities_get_by_id
    @activityNum_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT activityNum_id, activity_type, date_time, location, age_group
    FROM Activities
    WHERE activityNum_id = @activityNum_id;
END
GO


-- =============================================================================
-- DiscountRequests
-- =============================================================================

CREATE PROCEDURE sp_discount_requests_create
    @discount_request_Num_id INT,
    @customer_id             NVARCHAR(20),
    @discount_type           NVARCHAR(100),
    @file_path               NVARCHAR(500) = NULL,
    @discount_status         NVARCHAR(50),
    @discount_percent        DECIMAL(5,2)  = NULL,
    @submitted_at            DATE,
    @resolved_at             DATE          = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DiscountRequests (
        discount_request_Num_id, customer_id, discount_type, file_path,
        discount_status, discount_percent, submitted_at, resolved_at
    )
    VALUES (
        @discount_request_Num_id, @customer_id, @discount_type, @file_path,
        @discount_status, @discount_percent, @submitted_at, @resolved_at
    );
END
GO

CREATE PROCEDURE sp_discount_requests_update
    @discount_request_Num_id INT,
    @customer_id             NVARCHAR(20),
    @discount_type           NVARCHAR(100),
    @file_path               NVARCHAR(500) = NULL,
    @discount_status         NVARCHAR(50),
    @discount_percent        DECIMAL(5,2)  = NULL,
    @submitted_at            DATE,
    @resolved_at             DATE          = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DiscountRequests
    SET customer_id      = @customer_id,
        discount_type    = @discount_type,
        file_path        = @file_path,
        discount_status  = @discount_status,
        discount_percent = @discount_percent,
        submitted_at     = @submitted_at,
        resolved_at      = @resolved_at
    WHERE discount_request_Num_id = @discount_request_Num_id;
END
GO

CREATE PROCEDURE sp_discount_requests_delete
    @discount_request_Num_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM DiscountRequests WHERE discount_request_Num_id = @discount_request_Num_id;
END
GO

CREATE PROCEDURE sp_discount_requests_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT discount_request_Num_id, customer_id, discount_type, file_path,
           discount_status, discount_percent, submitted_at, resolved_at
    FROM DiscountRequests;
END
GO

CREATE PROCEDURE sp_discount_requests_get_by_id
    @discount_request_Num_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT discount_request_Num_id, customer_id, discount_type, file_path,
           discount_status, discount_percent, submitted_at, resolved_at
    FROM DiscountRequests
    WHERE discount_request_Num_id = @discount_request_Num_id;
END
GO


-- =============================================================================
-- Maintenances
-- =============================================================================

CREATE PROCEDURE sp_maintenances_create
    @maintenance_id  INT,
    @boatNumber_id   INT,
    @reported_at     DATE,
    @description     NVARCHAR(MAX),
    @status          NVARCHAR(50),
    @resolved_at     DATE          = NULL,
    @cost            DECIMAL(10,2) = NULL,
    @technician_name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Maintenances (
        maintenance_id, boatNumber_id, reported_at, description,
        status, resolved_at, cost, technician_name
    )
    VALUES (
        @maintenance_id, @boatNumber_id, @reported_at, @description,
        @status, @resolved_at, @cost, @technician_name
    );
END
GO

CREATE PROCEDURE sp_maintenances_update
    @maintenance_id  INT,
    @boatNumber_id   INT,
    @reported_at     DATE,
    @description     NVARCHAR(MAX),
    @status          NVARCHAR(50),
    @resolved_at     DATE          = NULL,
    @cost            DECIMAL(10,2) = NULL,
    @technician_name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Maintenances
    SET boatNumber_id   = @boatNumber_id,
        reported_at     = @reported_at,
        description     = @description,
        status          = @status,
        resolved_at     = @resolved_at,
        cost            = @cost,
        technician_name = @technician_name
    WHERE maintenance_id = @maintenance_id;
END
GO

CREATE PROCEDURE sp_maintenances_delete
    @maintenance_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Maintenances WHERE maintenance_id = @maintenance_id;
END
GO

CREATE PROCEDURE sp_maintenances_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT maintenance_id, boatNumber_id, reported_at, description,
           status, resolved_at, cost, technician_name
    FROM Maintenances;
END
GO

CREATE PROCEDURE sp_maintenances_get_by_id
    @maintenance_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT maintenance_id, boatNumber_id, reported_at, description,
           status, resolved_at, cost, technician_name
    FROM Maintenances
    WHERE maintenance_id = @maintenance_id;
END
GO


-- =============================================================================
-- WorkHoursReports
-- =============================================================================

CREATE PROCEDURE sp_work_hours_reports_create
    @work_hours_report_num_id INT,
    @employee_id              NVARCHAR(20),
    @check_in                 DATETIME2,
    @check_out                DATETIME2,
    @reported_hours           DECIMAL(10,2),
    @actual_hours             DECIMAL(10,2),
    @exception                BIT,
    @is_approved              BIT,
    @approval_note            NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO WorkHoursReports (
        work_hours_report_num_id, employee_id, check_in, check_out,
        reported_hours, actual_hours, exception, is_approved, approval_note
    )
    VALUES (
        @work_hours_report_num_id, @employee_id, @check_in, @check_out,
        @reported_hours, @actual_hours, @exception, @is_approved, @approval_note
    );
END
GO

CREATE PROCEDURE sp_work_hours_reports_update
    @work_hours_report_num_id INT,
    @employee_id              NVARCHAR(20),
    @check_in                 DATETIME2,
    @check_out                DATETIME2,
    @reported_hours           DECIMAL(10,2),
    @actual_hours             DECIMAL(10,2),
    @exception                BIT,
    @is_approved              BIT,
    @approval_note            NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE WorkHoursReports
    SET employee_id              = @employee_id,
        check_in                 = @check_in,
        check_out                = @check_out,
        reported_hours           = @reported_hours,
        actual_hours             = @actual_hours,
        exception                = @exception,
        is_approved              = @is_approved,
        approval_note            = @approval_note
    WHERE work_hours_report_num_id = @work_hours_report_num_id;
END
GO

CREATE PROCEDURE sp_work_hours_reports_delete
    @work_hours_report_num_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM WorkHoursReports WHERE work_hours_report_num_id = @work_hours_report_num_id;
END
GO

CREATE PROCEDURE sp_work_hours_reports_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT work_hours_report_num_id, employee_id, check_in, check_out,
           reported_hours, actual_hours, exception, is_approved, approval_note
    FROM WorkHoursReports;
END
GO

CREATE PROCEDURE sp_work_hours_reports_get_by_id
    @work_hours_report_num_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT work_hours_report_num_id, employee_id, check_in, check_out,
           reported_hours, actual_hours, exception, is_approved, approval_note
    FROM WorkHoursReports
    WHERE work_hours_report_num_id = @work_hours_report_num_id;
END
GO


-- =============================================================================
-- StudentsAttendanceReports
-- =============================================================================

CREATE PROCEDURE sp_students_attendance_reports_create
    @attendance_report_id INT,
    @activityNum_id       INT,
    @customer_id          NVARCHAR(20),
    @attendance_status    NVARCHAR(50),
    @notes                NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO StudentsAttendanceReports (
        attendance_report_id, activityNum_id, customer_id,
        attendance_status, notes
    )
    VALUES (
        @attendance_report_id, @activityNum_id, @customer_id,
        @attendance_status, @notes
    );
END
GO

CREATE PROCEDURE sp_students_attendance_reports_update
    @attendance_report_id INT,
    @activityNum_id       INT,
    @customer_id          NVARCHAR(20),
    @attendance_status    NVARCHAR(50),
    @notes                NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE StudentsAttendanceReports
    SET activityNum_id    = @activityNum_id,
        customer_id       = @customer_id,
        attendance_status = @attendance_status,
        notes             = @notes
    WHERE attendance_report_id = @attendance_report_id;
END
GO

CREATE PROCEDURE sp_students_attendance_reports_delete
    @attendance_report_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM StudentsAttendanceReports WHERE attendance_report_id = @attendance_report_id;
END
GO

CREATE PROCEDURE sp_students_attendance_reports_get_all
AS
BEGIN
    SET NOCOUNT ON;
    SELECT attendance_report_id, activityNum_id, customer_id,
           attendance_status, notes
    FROM StudentsAttendanceReports;
END
GO

CREATE PROCEDURE sp_students_attendance_reports_get_by_id
    @attendance_report_id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT attendance_report_id, activityNum_id, customer_id,
           attendance_status, notes
    FROM StudentsAttendanceReports
    WHERE attendance_report_id = @attendance_report_id;
END
GO


-- =============================================================================
-- Customer State-Machine Transition Procedures
-- States: בהרשמה → ממתין לתשלום → לא שילם → פעיל / בארכיון
-- =============================================================================

CREATE PROCEDURE sp_customers_completeRegistration
    @customer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Customers
            WHERE customer_id = @customer_id AND customer_status = N'בהרשמה'
        )
            RAISERROR(N'הלקוח אינו במצב "בהרשמה" — לא ניתן לסיים הרשמה', 16, 1);

        UPDATE Customers
        SET customer_status = N'ממתין לתשלום'
        WHERE customer_id = @customer_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_customers_requestPayment
    @customer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Customers
            WHERE customer_id = @customer_id AND customer_status = N'ממתין לתשלום'
        )
            RAISERROR(N'הלקוח אינו במצב "ממתין לתשלום" — לא ניתן לדרוש תשלום', 16, 1);

        UPDATE Customers
        SET customer_status = N'לא שילם'
        WHERE customer_id = @customer_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_customers_completePayment
    @customer_id  NVARCHAR(20),
    @payment_date DATE
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Customers
            WHERE customer_id = @customer_id AND customer_status = N'לא שילם'
        )
            RAISERROR(N'הלקוח אינו במצב "לא שילם" — לא ניתן לרשום תשלום', 16, 1);

        UPDATE Customers
        SET customer_status = N'פעיל',
            payment_status  = N'שולם',
            payment_date    = @payment_date
        WHERE customer_id = @customer_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_customers_expireRegistration
    @customer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Customers
            WHERE customer_id = @customer_id AND customer_status = N'לא שילם'
        )
            RAISERROR(N'הלקוח אינו במצב "לא שילם" — לא ניתן לבטל בגין פג תוקף', 16, 1);

        UPDATE Customers
        SET customer_status = N'בארכיון'
        WHERE customer_id = @customer_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_customers_cancelMembership
    @customer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Customers
            WHERE customer_id = @customer_id AND customer_status = N'פעיל'
        )
            RAISERROR(N'הלקוח אינו פעיל — לא ניתן לבטל חברות', 16, 1);

        UPDATE Customers
        SET customer_status = N'בארכיון'
        WHERE customer_id = @customer_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_customers_reactivate
    @customer_id NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Customers
            WHERE customer_id = @customer_id AND customer_status = N'בארכיון'
        )
            RAISERROR(N'הלקוח אינו בארכיון — לא ניתן להפעיל מחדש', 16, 1);

        UPDATE Customers
        SET customer_status = N'ממתין לתשלום'
        WHERE customer_id = @customer_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO


-- =============================================================================
-- Boat State-Machine Transition Procedures
-- States: פעיל ↔ בשימוש → בתחזוקה → פעיל / מושבת → בארכיון
-- =============================================================================

CREATE PROCEDURE sp_boats_assignToActivity
    @boatNumber_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Boats
            WHERE boatNumber_id = @boatNumber_id AND boat_status = N'פעיל'
        )
            RAISERROR(N'הסירה אינה זמינה להשמה לפעילות', 16, 1);

        UPDATE Boats
        SET boat_status = N'בשימוש'
        WHERE boatNumber_id = @boatNumber_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_boats_returnFromActivity
    @boatNumber_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Boats
            WHERE boatNumber_id = @boatNumber_id AND boat_status = N'בשימוש'
        )
            RAISERROR(N'הסירה אינה בשימוש — לא ניתן להחזיר אותה', 16, 1);

        UPDATE Boats
        SET boat_status = N'פעיל'
        WHERE boatNumber_id = @boatNumber_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_boats_reportFault
    @boatNumber_id   INT,
    @maintenance_id  INT,
    @description     NVARCHAR(MAX),
    @technician_name NVARCHAR(100),
    @reported_at     DATE
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Boats
            WHERE boatNumber_id = @boatNumber_id
              AND boat_status IN (N'פעיל', N'בשימוש')
        )
            RAISERROR(N'לא ניתן לדווח על תקלה — הסירה אינה פעילה או בשימוש', 16, 1);

        UPDATE Boats
        SET boat_status = N'בתחזוקה'
        WHERE boatNumber_id = @boatNumber_id;

        INSERT INTO Maintenances (
            maintenance_id, boatNumber_id, reported_at, description,
            status, resolved_at, cost, technician_name
        )
        VALUES (
            @maintenance_id, @boatNumber_id, @reported_at, @description,
            N'פתוח', NULL, NULL, @technician_name
        );

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_boats_completeMaintenance
    @boatNumber_id INT,
    @resolved_at   DATE,
    @cost          DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Boats
            WHERE boatNumber_id = @boatNumber_id AND boat_status = N'בתחזוקה'
        )
            RAISERROR(N'הסירה אינה בתחזוקה — לא ניתן לסגור את הטיפול', 16, 1);

        UPDATE Boats
        SET boat_status = N'פעיל'
        WHERE boatNumber_id = @boatNumber_id;

        UPDATE Maintenances
        SET status      = N'סגור',
            resolved_at = @resolved_at,
            cost        = @cost
        WHERE boatNumber_id = @boatNumber_id
          AND status IN (N'פתוח', N'בטיפול');

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_boats_failRepair
    @boatNumber_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Boats
            WHERE boatNumber_id = @boatNumber_id AND boat_status = N'בתחזוקה'
        )
            RAISERROR(N'הסירה אינה בתחזוקה — לא ניתן לסמן כשל תיקון', 16, 1);

        UPDATE Boats
        SET boat_status = N'מושבת'
        WHERE boatNumber_id = @boatNumber_id;

        UPDATE Maintenances
        SET status      = N'סגור',
            resolved_at = CAST(GETDATE() AS DATE)
        WHERE boatNumber_id = @boatNumber_id
          AND status IN (N'פתוח', N'בטיפול');

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE sp_boats_dispose
    @boatNumber_id INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN;
    BEGIN TRY
        IF NOT EXISTS (
            SELECT 1 FROM Boats
            WHERE boatNumber_id = @boatNumber_id AND boat_status = N'מושבת'
        )
            RAISERROR(N'הסירה אינה מושבתת — לא ניתן להעביר לארכיון', 16, 1);

        UPDATE Boats
        SET boat_status = N'בארכיון'
        WHERE boatNumber_id = @boatNumber_id;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END
GO
