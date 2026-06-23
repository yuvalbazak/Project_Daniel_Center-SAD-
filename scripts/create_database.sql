USE My_Daniel;
GO

-- =============================================================================
-- My Daniel Center Management System — DDL
-- Source:    docs/design/class-diagram.md
-- Generated: 2026-06-20
--
-- Rules:
--   • PKs assigned in C#. No IDENTITY. See CLAUDE.md § Primary Key Strategy.
--   • Enum columns: NVARCHAR(50) + named CHECK constraint. No lookup tables.
--   • All columns NOT NULL unless nullability is noted with an inline comment.
--   • FKs: ON DELETE NO ACTION ON UPDATE NO ACTION throughout.
--   • Table order matches initLists() load order in CLAUDE.md § In-Memory Load Order.
-- =============================================================================


-- =============================================================================
-- 1. Employees
--    No foreign keys — load first.
--    employee_id is NVARCHAR — class diagram shows `id: String`.
-- =============================================================================
CREATE TABLE Employees (
    employee_id NVARCHAR(20)  NOT NULL,
    full_name   NVARCHAR(100) NOT NULL,
    role        NVARCHAR(50)  NOT NULL
                    CONSTRAINT CHK_Employees_role
                    CHECK (role IN (
                        'Center Manager',
                        'Administration Staff',
                        'Accounting Manager',
                        'Coordinator',
                        'Instructor'
                    )),
    start_date  DATE          NOT NULL,
    phone       NVARCHAR(20)  NOT NULL,
    email       NVARCHAR(100) NOT NULL,
    password    NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Employees PRIMARY KEY (employee_id)
);
GO


-- =============================================================================
-- 2. Customers
--    No foreign keys — load second.
--    customer_id is NVARCHAR — class diagram shows `id: String`.
-- =============================================================================
CREATE TABLE Customers (
    customer_id       NVARCHAR(20)  NOT NULL,
    full_name         NVARCHAR(100) NOT NULL,
    phone             NVARCHAR(20)  NOT NULL,
    email             NVARCHAR(100) NOT NULL,
    address           NVARCHAR(200) NOT NULL,
    birth_date        DATE          NOT NULL,
    start_date        DATE          NOT NULL,
    emergency_contact NVARCHAR(100) NOT NULL,
    payment_date      DATE          NOT NULL,
    customer_status   NVARCHAR(50)  NOT NULL
                          CONSTRAINT CHK_Customers_customer_status
                          CHECK (customer_status IN (
                              'Active', 'Unpaid', 'Archive'
                          )),
    payment_status    NVARCHAR(50)  NOT NULL
                          CONSTRAINT CHK_Customers_payment_status
                          CHECK (payment_status IN (
                              'Paid', 'Payment In Process', 'Unpaid'
                          )),
    password          NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Customers PRIMARY KEY (customer_id)
);
GO


-- =============================================================================
-- 3. Boats
--    No foreign keys — load third.
--    PK named boatNumber_id — class diagram shows `boatNum: int`.
-- =============================================================================
CREATE TABLE Boats (
    boatNumber_id           INT           NOT NULL,
    boat_type               NVARCHAR(50)  NOT NULL
                                CONSTRAINT CHK_Boats_boat_type
                                CHECK (boat_type IN (
                                    'Kayak', 'Sailing Boat', 'AcademicKayak'
                                )),
    water_craft_name        NVARCHAR(100) NOT NULL,
    boat_status             NVARCHAR(50)  NOT NULL
                                CONSTRAINT CHK_Boats_boat_status
                                CHECK (boat_status IN (
                                    'Active', 'Under Maintenance', 'Out Of Service'
                                )),
    purchase_date           DATE          NOT NULL,
    license_date            DATE          NOT NULL,
    annual_maintenance_date DATE          NOT NULL,
    source_type             NVARCHAR(50)  NOT NULL
                                CONSTRAINT CHK_Boats_source_type
                                CHECK (source_type IN ('External', 'Internal')),

    CONSTRAINT PK_Boats PRIMARY KEY (boatNumber_id)
);
GO


-- =============================================================================
-- 4. ExternalCenters
--    No foreign keys — load fourth.
--    NOTE: class diagram shows `centerID: String`; using INT per Primary Key Strategy.
-- =============================================================================
CREATE TABLE ExternalCenters (
    external_center_id INT           NOT NULL,
    center_name        NVARCHAR(100) NOT NULL,
    contact_name       NVARCHAR(100) NOT NULL,
    phone              NVARCHAR(20)  NOT NULL,

    CONSTRAINT PK_ExternalCenters PRIMARY KEY (external_center_id)
);
GO


-- =============================================================================
-- 5. Activities
--    Load fifth.
--    PK named activityNum_id — class diagram shows `activityNum: int`.
--    FK columns to Employees and Boats are omitted — relationships unconfirmed
--    in the class diagram (see CLAUDE.md § Known Relationships).
-- =============================================================================
CREATE TABLE Activities (
    activityNum_id INT           NOT NULL,
    activity_type  NVARCHAR(50)  NOT NULL
                       CONSTRAINT CHK_Activities_activity_type
                       CHECK (activity_type IN (
                           'Kayaking', 'Sailing', 'Academic Rowing'
                       )),
    date_time      DATETIME2     NOT NULL,
    location       NVARCHAR(100) NOT NULL,
    age_group      NVARCHAR(50)  NOT NULL
                       CONSTRAINT CHK_Activities_age_group
                       CHECK (age_group IN (
                           'Junior', 'Youth', 'Senior', 'Elite'
                       )),
    -- TODO: add employee_id FK → Employees once Activity→Employee (instructor) relationship is confirmed from diagram image
    -- TODO: add boatNumber_id FK or separate association table once Activity→Boat relationship is confirmed from diagram image
    -- TODO: confirm whether Activity→Customer enrollment is a direct FK here or a separate association table

    CONSTRAINT PK_Activities PRIMARY KEY (activityNum_id)
);
GO


-- =============================================================================
-- 6. DiscountRequests
--    FK → Customers (1 Customer : 0..* DiscountRequests).
--    PK named discount_request_Num_id — class diagram shows `requestNum: int`.
--    NOTE: class diagram field is `file: String`; stored as file_path for clarity.
-- =============================================================================
CREATE TABLE DiscountRequests (
    discount_request_Num_id INT           NOT NULL,
    customer_id             NVARCHAR(20)  NOT NULL,
    discount_type           NVARCHAR(100) NOT NULL,
    file_path               NVARCHAR(500) NULL,        -- NULL while status is 'Pending Document Upload'
    discount_status         NVARCHAR(50)  NOT NULL
                                CONSTRAINT CHK_DiscountRequests_discount_status
                                CHECK (discount_status IN (
                                    'Pending Document Upload',
                                    'In Progress',
                                    'Approved',
                                    'Declined'
                                )),
    discount_percent        DECIMAL(5,2)  NULL,        -- NULL until approved; range 0–100 enforced in C#
    submitted_at            DATE          NOT NULL,
    resolved_at             DATE          NULL,        -- NULL until request is approved or declined

    CONSTRAINT PK_DiscountRequests PRIMARY KEY (discount_request_Num_id),
    CONSTRAINT FK_DiscountRequests_Customers
        FOREIGN KEY (customer_id) REFERENCES Customers (customer_id)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO


-- =============================================================================
-- 7. Maintenances
--    FK → Boats (1 Boat : 0..* Maintenances).
--    NOTE: class diagram shows `meintenanceID: String`; using INT per Primary Key Strategy.
--    NOTE: `status` reuses BoatStatus values (matches Maintenance.status in class diagram).
-- =============================================================================
CREATE TABLE Maintenances (
    maintenance_id  INT           NOT NULL,
    boatNumber_id   INT           NOT NULL,
    reported_at     DATE          NOT NULL,
    description     NVARCHAR(MAX) NOT NULL,   -- free-text fault description
    status          NVARCHAR(50)  NOT NULL
                        CONSTRAINT CHK_Maintenances_status
                        CHECK (status IN (
                            'Active', 'Under Maintenance', 'Out Of Service'
                        )),
    resolved_at     DATE          NULL,        -- NULL until maintenance work is completed
    cost            DECIMAL(10,2) NULL,        -- NULL until repair cost is confirmed
    technician_name NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Maintenances PRIMARY KEY (maintenance_id),
    CONSTRAINT FK_Maintenances_Boats
        FOREIGN KEY (boatNumber_id) REFERENCES Boats (boatNumber_id)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO


-- =============================================================================
-- 8. WorkHoursReports
--    FK → Employees (1 Employee : 0..* WorkHoursReports).
--    PK named work_hours_report_num_id — class diagram shows `reportNum: int`.
-- =============================================================================
CREATE TABLE WorkHoursReports (
    work_hours_report_num_id INT           NOT NULL,
    employee_id              NVARCHAR(20)  NOT NULL,
    check_in                 DATETIME2     NOT NULL,
    check_out                DATETIME2     NOT NULL,
    reported_hours           DECIMAL(10,2) NOT NULL,
    actual_hours             DECIMAL(10,2) NOT NULL,
    exception                BIT           NOT NULL,
    is_approved              BIT           NOT NULL,
    approval_note            NVARCHAR(MAX) NULL,    -- NULL when no exception; minimum 10 chars enforced in C#

    CONSTRAINT PK_WorkHoursReports PRIMARY KEY (work_hours_report_num_id),
    CONSTRAINT FK_WorkHoursReports_Employees
        FOREIGN KEY (employee_id) REFERENCES Employees (employee_id)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO


-- =============================================================================
-- 9. StudentsAttendanceReports
--    FK → Activities, FK → Customers.
--    NOTE: class diagram shows `recordID: String`; using INT per Primary Key Strategy.
--    NOTE: exact multiplicity unconfirmed in the class diagram — FKs are based on
--          domain logic. Verify against diagram image before running migrations.
-- =============================================================================
CREATE TABLE StudentsAttendanceReports (
    attendance_report_id INT           NOT NULL,
    activityNum_id       INT           NOT NULL,  -- TODO: confirm multiplicity from diagram image
    customer_id          NVARCHAR(20)  NOT NULL,  -- TODO: confirm multiplicity from diagram image
    attendance_status    NVARCHAR(50)  NOT NULL
                             CONSTRAINT CHK_AttendanceReports_attendance_status
                             CHECK (attendance_status IN (
                                 'Present',
                                 'Absent With Notice',
                                 'Absent Without Notice'
                             )),
    notes                NVARCHAR(MAX) NULL,      -- optional free-text instructor note

    CONSTRAINT PK_StudentsAttendanceReports PRIMARY KEY (attendance_report_id),
    CONSTRAINT FK_AttendanceReports_Activities
        FOREIGN KEY (activityNum_id) REFERENCES Activities (activityNum_id)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT FK_AttendanceReports_Customers
        FOREIGN KEY (customer_id) REFERENCES Customers (customer_id)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO
