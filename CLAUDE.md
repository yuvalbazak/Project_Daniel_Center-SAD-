# CLAUDE.md — My Daniel Center Management System

## What This Project Is

This is a WinForms management system built for the **Daniel Rowing Center** (מרכז דניאל לחתירה), a water-sports club on the Yarkon River in Tel Aviv. It is developed as a coursework project for the Software Analysis and Design (SAD) course at Ben-Gurion University, Industrial Engineering and Management department — Group 10.

The system replaces a collection of disconnected tools (Priority, Synel, Fizikal, Kehila, Coing, Excel spreadsheets, WhatsApp groups, and phone-based registration) with a single integrated platform for managing customers, employees, activities, boats, maintenance, payroll, discounts, and BI reporting.

---

## Database

**Database name:** `My_Daniel`
**Server:** `localhost\SQLEXPRESS` (Windows Authentication)

**Rule — every `execute_sql` call must begin with:**
```sql
USE My_Daniel;
```
This ensures all DDL and DML runs in the correct database, not in `master`. No exceptions.

---

## Document Map

| File / Folder | Purpose |
|---|---|
| `CLAUDE.md` | This file — project context, architecture, entities, use cases, decisions |
| `PATTERNS.md` | Shared SAD architecture conventions — inherited verbatim into this file |
| `docs/00-requirements.md` | 30 User Stories + 10 NFRs + traceability matrix |
| `docs/00e-use-cases.md` | VP18-style UC specs (two-layer: behavioral + implementation notes) for 8 UCs |
| `docs/design/class-diagram.md` | Entities, attributes, methods, enumerations, relationships (sourced from PDF) |
| `docs/design/state-diagram.md` | State diagrams skeleton (TODO — no source available yet) |
| `docs/design/sequence-diagram.md` | Sequence diagrams skeleton (TODO — no source available yet) |
| `docs/org-analysis/01-organization.md` | Org description, existing systems, business processes (Hebrew + English) |
| `docs/org-analysis/02-interviews.md` | Stakeholder interview transcripts + field observations (Hebrew + English) |
| `docs/org-analysis/03-problems.md` | 10-problem table, business impact analysis, proposed solution (Hebrew + English) |
| `docs/org-analysis/04-business-processes.md` | 3 BPMN process descriptions with diagram references (Hebrew + English) |
| `docs/UC_overview/` | Interactive UC diagrams (two tabs: Operations and Administration) |
| `docs/UC_overview/Selected_UC.md` | Summary of the 6 selected use cases and their business value |
| `SAD-sample-project/` | Course sample project (WinForms order management system) — reference only, do not copy domain content |

---

## Architecture Conventions

*The following section is inlined verbatim from `PATTERNS.md` — the shared architecture conventions for all SAD student projects.*

---

### The Human vs. AI Distinction — Course-Wide Principle

This distinction is central to how you should approach work in this course. Do not blur it.

**Humans must do this** (AI cannot substitute, even though AI will later use the output):
- Organizational context: who the business is, what problem it has, why it matters
- Stakeholder identification and needs elicitation
- Problem statement and project scope
- Initial domain modeling: what entities exist, what relationships make sense
- Deciding which use cases exist and which don't (e.g., deciding Login is an NFR, not a UC)
- Prioritization and tradeoffs

**AI can accelerate this** (once the human thinking is done):
- Structuring requirements into user story format
- Writing VP18-style UC specs from a brief description
- Generating the UC diagram HTML from the spec data
- Generating entity classes, stored procedures, and panels from UC specs + implementation notes
- Checking consistency between artifacts (traceability)

Project artifacts are produced in this order: organization/problem context → requirements → UC specs → code. Each is input to the next.

---

### Architecture — Key Patterns

#### Entity Pattern
Every entity class is self-contained. Each one owns:
- Private fields + getters/setters
- Constructor with `bool is_new` — if `true`, calls `getNextXYZId()` to assign a new PK, then calls `createXYZ()`, then adds to `Program.list`; if `false`, just sets fields (used during loading)
- `createXYZ()`, `updateXYZ()`, `deleteXYZ()` — each builds a `SqlCommand` with a stored procedure
- `static initXYZs()` — loads all records from DB into `Program.XYZs`, always calls constructor with `is_new = false`
- `static seekXYZ(id)` — searches `Program.XYZs` by ID
- `static getNextXYZId()` — returns `max(id) + 1` over `Program.XYZs` (or `1` if the list is empty). See "Primary Key Strategy" below.

#### Primary Key Strategy
**Primary keys are assigned in C#, not by the database.**

- DDL: every PK is `INT NOT NULL PRIMARY KEY`. Do **not** use `IDENTITY(1,1)`.
- The entity class's `static getNextXYZId()` returns `max(id) + 1` over the in-memory list.
- The `is_new` constructor calls `getNextXYZId()` before `createXYZ()` to assign the new row's PK.
- Create stored procedures take the PK as the first parameter (`@<entity>_id`). They do **not** use `SCOPE_IDENTITY()` and do **not** return the new ID.

This is deliberate: students can read the full lifecycle of an ID in one place (the C# constructor), and DB writes are deterministic from the entity's state. Concurrency is not a concern in the single-user teaching context.

#### In-Memory Lists
All data lives in `Program.*` static lists after startup. No DB calls during normal use except writes.

`initLists()` load order is strict: **base entities first, then entities with FK references, then association classes last.** Each project's CLAUDE.md states its own concrete order.

#### DB Operations
All DB access goes through stored procedures. **No ad-hoc SQL strings in application code.** This is an NFR.

#### Panel Navigation
Single-window model. All screens are `UserControl` panels. Navigation: `mainForm.showPanel(new XYZPanel())`. Every panel has a Back button. **No additional Forms or dialogs during normal operation.**

#### Inheritance — Table-per-Subclass
When an entity has subtypes, use table-per-subclass: a base table for the parent + one table per subclass holding only the subclass's unique fields + a FK to the base table. Load with a LEFT JOIN and check for `DBNull.Value` to determine subtype. *(Sample project example: `Order` base with `DeliveryOrder` / `PickupOrder` subclasses.)*

#### Association Class
When a many-to-many relationship has its own attributes, model it as an association class linking the two sides. In the C# class, both sides are stored as **object references, not IDs**. *(Sample project example: `OrderItem` linking `Order` ↔ `Product` with quantity and unit price.)*

#### No Service Layer
Entity classes own their own DB methods. One file per entity. This is intentional for teaching — students see the full lifecycle of an entity in one place.

---

### UC Diagram — Conventions

The diagram is generated from inline JavaScript data and rendered by an external shared script. Rules:

- All data globals must use `var` (not `const`/`let`) so they become `window` properties
- Wireframes are embedded as `useCaseDocs[id].wireframe` HTML strings — **not** as separate files
- All wireframe visible text must be in Hebrew; all form fields use `disabled`; no `<script>` tags inside wireframes
- The `[hidden] { display: none !important; }` style override is required in `<head>` for tab switching to work
- **Login/authentication must never appear as a UC.** Note it only in the `assumptions` array.

#### Two-Layer UC Spec Format
Each detailed UC has two sections:
1. **Formal spec** (analysis level) — behavioral, technology-neutral. No class names, SP names, or field names.
2. **Implementation Notes** (design level, clearly labelled) — maps behavioral steps to specific classes, methods, and stored procedures.

This separation is intentional and pedagogically important. Do not merge them.

---

### Language Conventions

| Context | Language |
|---|---|
| C# code (classes, methods, variables) | English |
| UI labels, button text, MessageBox text | Hebrew |
| DB text fields | Hebrew — use `NVARCHAR`, never `VARCHAR` |
| Student guide docs (`docs/*.md`) | Hebrew |
| Requirements and UC spec documents | English |
| UC diagram text (actor labels, UC names, flow steps) | Hebrew |

#### RTL Layout for Hebrew UI

Every `Form` and `UserControl` with Hebrew visible text **must** be set up for right-to-left rendering:

- `RightToLeft = Yes` on the form/panel (mirrors text direction, button alignment, scrollbar position).
- `RightToLeftLayout = true` on the root form (mirrors the entire layout, including TabControl direction and DataGridView column order).
- Set these on the parent — children inherit unless overridden.

Generate panels with these properties set from the start. Retrofitting RTL onto LTR-built panels is painful — labels overlap, alignment breaks, the designer file fights you.

---

### Decisions Already Made — Do Not Revisit Without Discussion

These apply across all SAD projects:

- **Login is not a UC.** Authentication is an NFR precondition. A `LoginPanel` is a technical artifact. Do not add Login to UC diagrams or UC specs.
- **Wireframes belong inside the UC diagram modal**, not in separate files.
- **No ad-hoc SQL.** All DB operations use stored procedures.
- **No service layer.** Entity classes own their own DB methods.
- **Single window, panel navigation.** No additional forms or dialogs during normal operation.

---

## Domain — My Daniel System

### System Context

The Daniel Rowing Center (מרכז דניאל לחתירה) is Israel's largest water-sports club, located on the Yarkon River in Tel Aviv. It serves national competitive teams and the general community through rowing, sailing, and dragon boat programs. The center employs 75 staff, manages ~300 annual adult members and ~350 children in after-school programs, and has an annual turnover of approximately ₪10M.

**Existing systems being replaced / integrated:**

| System | Role |
|---|---|
| **Priority** | Financial ERP (budgets, revenue/expense, suppliers, payroll input) |
| **Synel** | Employee clock-in/clock-out, payroll, gate/locker access |
| **Fizikal** | Activity scheduling, payment processing, membership management |
| **Kehila** | Municipal Tel Aviv resident database — used for fast customer lookup |
| **Coing** | One-time customer payments (camps, events) |
| **Manual/WhatsApp/Excel** | Attendance, maintenance logs, parent communication |

**External systems that My Daniel interfaces with at runtime:**

| External System | Interface |
|---|---|
| **PayrollSystem** | Receives approved work-hours data from WorkHoursReport |
| **Report Hours System** (Synel) | Source of employee clock-in/clock-out records |

---

### Actors

| Actor | Type |
|---|---|
| **Center Manager** | Human — Primary; inherits all Coordinator privileges |
| **Accounting Manager** | Human — Primary; billing, subscriptions, discount approvals, payroll |
| **Coordinator** | Human — Primary; daily operations, scheduling, equipment |
| **Instructor** | Human — Primary; leads activities, reports attendance, uploads miluim |
| **Customer** | Human — Primary; registers, views schedule, submits discount requests |
| **System (Time System)** | Automated; triggers scheduled syncs, backups, and reports |

**Actor generalization:** Center Manager ──▷ Coordinator (hollow triangle at Coordinator end). The Center Manager inherits all Coordinator use cases.

---

### Domain Entities

*Source: `docs/design/class-diagram.md`, extracted from `docs/ClassDiagram/ClassDiagramמתוקן.pdf`.*

#### Employee

| Field | C# type | DB type |
|---|---|---|
| `id` | `string` | `NVARCHAR(20) PK` |
| `fullName` | `string` | `NVARCHAR(100)` |
| `role` | `WorkerType` (enum) | `NVARCHAR(50)` |
| `startDate` | `DateTime` | `DATE` |
| `phone` | `string` | `NVARCHAR(20)` |
| `email` | `string` | `NVARCHAR(100)` |

Methods: `viewEmployeesDetails()`, `updateEmployeeDetails()`, `addToArchive()`, `accessRestriction()`

#### Customer

| Field | C# type | DB type |
|---|---|---|
| `id` | `string` | `NVARCHAR(20) PK` |
| `fullName` | `string` | `NVARCHAR(100)` |
| `phone` | `string` | `NVARCHAR(20)` |
| `email` | `string` | `NVARCHAR(100)` |
| `address` | `string` | `NVARCHAR(200)` |
| `birthDate` | `DateTime` | `DATE` |
| `startDate` | `DateTime` | `DATE` |
| `emergencyContact` | `string` | `NVARCHAR(100)` |
| `paymentDate` | `DateTime` | `DATE` |
| `customerStatus` | `CustomerStatus` (enum) | `NVARCHAR(50)` |
| `paymentStatus` | `PaymentStatus` (enum) | `NVARCHAR(50)` |

Methods: `registrationReport()`, `editCustomerDetails()`, `viewUnregisteredCustomers()`, `viewCustomersDetails()`, `addToArchive()`

#### Activity

| Field | C# type | DB type |
|---|---|---|
| `activityNum` | `int` | `INT PK` |
| `activityType` | `ActivityType` (enum) | `NVARCHAR(50)` |
| `dateTime` | `DateTime` | `DATETIME` |
| `location` | `string` | `NVARCHAR(100)` |
| `ageGroup` | `AgeGroup` (enum) | `NVARCHAR(50)` |

Methods: `createActivity()`, `viewActivitySchedule()`, `resourceAssignment()`, `rescheduleActivity()`, `cancelActivity()`, `replaceBoat()`, `replaceInstructor()`, `viewActivityDetails()`

#### Boat

| Field | C# type | DB type |
|---|---|---|
| `boatNum` | `int` | `INT PK` |
| `boatType` | `BoatType` (enum) | `NVARCHAR(50)` |
| `waterCraftName` | `string` | `NVARCHAR(100)` |
| `boatStatus` | `BoatStatus` (enum) | `NVARCHAR(50)` |
| `purchaseDate` | `DateTime` | `DATE` |
| `licenseDate` | `DateTime` | `DATE` |
| `annualMaintenanceDate` | `DateTime` | `DATE` |
| `sourceType` | `SourceType` (enum) | `NVARCHAR(50)` |

Methods: `viewBoatsStatus()`, `editStatus()`

#### DiscountRequest

| Field | C# type | DB type |
|---|---|---|
| `requestNum` | `int` | `INT PK` |
| `discountType` | `string` | `NVARCHAR(100)` |
| `file` | `string` | `NVARCHAR(500)` |
| `discountStatus` | `DiscountStatus` (enum) | `NVARCHAR(50)` |
| `discountPercent` | `float` | `FLOAT` |
| `submittedAt` | `DateTime` | `DATE` |
| `resolvedAt` | `DateTime` | `DATE` |

Methods: `approveDiscount()`, `rejectDiscount()`, `updateDiscountStatus()`, `uploadDiscountFile()`

*FK: belongs to one Customer (1 Customer → 0..* DiscountRequests).*

#### Maintenance

| Field | C# type | DB type |
|---|---|---|
| `maintenanceID` | `string` | `NVARCHAR(20) PK` |
| `reportedAt` | `DateTime` | `DATE` |
| `description` | `string` | `NVARCHAR(500)` |
| `status` | `BoatStatus` (enum) | `NVARCHAR(50)` |
| `resolvedAt` | `DateTime` | `DATE` |
| `cost` | `float` | `FLOAT` |
| `technicianName` | `string` | `NVARCHAR(100)` |

Methods: `editStatus()`, `reportMaintenance()`, `viewMaintenanceReport()`

*FK: belongs to one Boat (1 Boat → 0..* Maintenance records).*

#### ExternalCenter

| Field | C# type | DB type |
|---|---|---|
| `centerID` | `string` | `NVARCHAR(20) PK` |
| `centerName` | `string` | `NVARCHAR(100)` |
| `contactName` | `string` | `NVARCHAR(100)` |
| `phone` | `string` | `NVARCHAR(20)` |

Methods: `outSourceBoatAssignment()`, `viewContactDetails()`

#### StudentsAttendanceReport

| Field | C# type | DB type |
|---|---|---|
| `recordID` | `string` | `NVARCHAR(20) PK` |
| `notes` | `string` | `NVARCHAR(500)` |
| `attendanceStatus` | `AttendanceStatus` (enum) | `NVARCHAR(50)` |

Methods: `updateStatus()`, `addNote()`, `markAttendance()`

*FK: belongs to one Activity and one Customer. Exact multiplicity — verify against diagram.*

#### WorkHoursReport

| Field | C# type | DB type |
|---|---|---|
| `reportNum` | `int` | `INT PK` |
| `checkIn` | `DateTime` | `DATETIME` |
| `checkOut` | `DateTime` | `DATETIME` |
| `reportedHours` | `float` | `FLOAT` |
| `actualHours` | `float` | `FLOAT` |
| `exception` | `bool` | `BIT` |
| `isApproved` | `bool` | `BIT` |
| `approvalNote` | `string` | `NVARCHAR(500)` |

Methods: `syncActualAndReportedHours()`, `approveHoursException()`, `editWorkHours()`, `addExplanationNote()`, `uploadServiceDutyFile()`, `createExceptionHoursEmployeesReport()`

*FK: belongs to one Employee (1 Employee → 0..* WorkHoursReports).*

---

### Enumerations

All enums are stored as `NVARCHAR(50)` in the DB. Use a `XYZHelper` class for conversions between the `_`-separated enum name and the display/DB string (spaces). See `docs/04-class-diagram-to-database.md` for the pattern.

| Enum | Values |
|---|---|
| `WorkerType` | `Center_Manager`, `Administration_Staff`, `Accounting_Manager`, `Coordinator`, `Instructor` |
| `CustomerStatus` | `Active`, `Unpaid`, `Archive` |
| `PaymentStatus` | `Paid`, `Payment_In_Process`, `Unpaid` |
| `ActivityType` | `Kayaking`, `Sailing`, `Academic_Rowing` |
| `AgeGroup` | `Junior`, `Youth`, `Senior`, `Elite` |
| `BoatType` | `Kayak`, `Sailing_Boat`, `AcademicKayak` |
| `BoatStatus` | `Active`, `Under_Maintenance`, `Out_Of_Service` |
| `DiscountStatus` | `Pending_Document_Upload`, `In_Progress`, `Approved`, `Declined` |
| `AttendanceStatus` | `Present`, `Absent_With_Notice`, `Absent_Without_Notice` |
| `SourceType` | `External`, `Internal` |

---

### In-Memory Load Order

```
initLists() call order in Program.cs:

1. Employee.initEmployees()               — no FKs
2. Customer.initCustomers()               — no FKs
3. Boat.initBoats()                       — no FKs
4. ExternalCenter.initExternalCenters()   — no FKs
5. Activity.initActivities()              — FK → Employee (instructor), FK → Boat
6. DiscountRequest.initDiscountRequests() — FK → Customer
7. Maintenance.initMaintenances()         — FK → Boat
8. WorkHoursReport.initWorkHoursReports() — FK → Employee
9. StudentsAttendanceReport.initAttendanceReports() — FK → Activity, FK → Customer
```

> **Note:** Steps 5–9 ordering may need adjustment once all FK relationships are confirmed against the finalized DB schema. Any many-to-many association classes (e.g., Activity–Boat, Activity–Employee linking tables) must be loaded last.

---

### Known Relationships

| From | Multiplicity | To | Multiplicity | Notes |
|---|:---:|---|:---:|---|
| Customer | 1 | DiscountRequest | 0..* | One customer may have many discount requests |
| Boat | 1 | Maintenance | 0..* | One boat may have many maintenance records |
| Employee | 1 | WorkHoursReport | 0..* | One employee has many work-hour reports |
| Activity | — | StudentsAttendanceReport | — | Exact multiplicity — confirm from diagram |
| Activity | — | Boat | — | TODO: direct or via assignment class? |
| Activity | — | Employee | — | TODO: instructor assignment mechanism |
| Activity | — | Customer | — | TODO: participant enrollment mechanism |
| Boat | — | ExternalCenter | — | `Boat.sourceType = External` implies a link; confirm from diagram |

---

## Use Cases

### UC Inventory

| UC ID | Name | Primary Actor | Detailed Spec |
|---|---|---|---|
| UC-01 | Create New Customer | Accounting Manager | — |
| UC-02 | Manage Customer Profile (Digital Registration) | Customer / Management | ✅ §5.6 |
| UC-03 | Attendance and Exceptional Events | Instructor | ✅ §5.1 |
| UC-04 | Assign Boats to Activities | Coordinator | ✅ §5.2 (included by UC-21) |
| UC-05 | Assign Instructors and Students | Coordinator | ✅ §5.3 (included by UC-21) |
| UC-06 | Report Attendance | Instructor | — |
| UC-07 | Upload Reserve Duty (Miluim) | Instructor | — |
| UC-08 | Approve Discount Request | Accounting Manager | — |
| UC-09 | Generate BI/Operational Report | Center Manager | — |
| UC-10 | Lesson Cancellation Update | Coordinator | ✅ §5.4 |
| UC-11 | Cross-Reference Payroll | Accounting Manager / Center Manager | ✅ §5.5 |
| UC-12 | View Active Operations | Center Manager | — |
| UC-13 | Update Resources (Replace Boat/Instructor) | Coordinator | ✅ §5.8 |
| UC-14 | Approve Payroll Exceptions | Center Manager | — |
| UC-15 | View Missing Hours Report | Coordinator | — |
| UC-16 | Sync Reserve Duty to Payroll | Instructor | — |
| UC-17 | Manage Employees (CRUD) | Center Manager | — |
| UC-18 | Notification on New Customer Request | Accounting Manager | — |
| UC-19 | View Customer Request Status | Accounting Manager | — |
| UC-20 | Auto-Update Request Status | Accounting Manager | — |
| UC-21 | Activity Resource Assignment | Coordinator | ✅ §5.7 |
| UC-0501 | Outsource Boats Assignment | Coordinator | — |

Full spec text is in `docs/00e-use-cases.md`.

### UC Relationships

- **«include»:** UC-21 includes UC-04 and UC-05. Both are mandatory sub-behaviors of Activity Resource Assignment.
- **«extend»:** UC-0501 extends UC-13 at extension point `Replace Boat/Instructor`. Triggered only when no in-house boat is available and the coordinator chooses to outsource.
- **Generalization:** Center Manager ──▷ Coordinator (Center Manager inherits all Coordinator UCs).

### UC Diagram Structure

Two tabs:
- **Tab 1 — Operations:** Activity scheduling, attendance, and equipment allocation (Coordinator, Instructor)
- **Tab 2 — Administration:** Customer registration, financial/discount management, and payroll (Accounting Manager, Center Manager)

### Implementation Notes Known So Far

| UC | Panel | Stored Procedure | Notes |
|---|---|---|---|
| UC-02 | `RegistrationFormPanel` | `SP_create_customer` | Full customer lifecycle: create, edit, archive, discount |
| UC-11 | `ExceptionsReportView` | — | Compares `ReportedHours` vs `ActualHours`; exception flag requires 10-char minimum justification |
| UC-13 | `ReplaceResourcePanel` | `SP_update_resource_assignment` | |
| UC-21 | `ResourceAssignmentPanel` | `SP_assign_resource` | Time-conflict validation required before saving |
| UC-03, 04, 05, 10 | TODO | TODO | |

---

## Project-Specific Decisions

Beyond the cross-project decisions in `PATTERNS.md`:

- **LoginPanel is a technical precondition, not a UC.** On login success, the system navigates to the role-appropriate dashboard (Manager, Coordinator, Instructor, Accountant, or Customer).
- **Employee uses a role enum, not subclasses.** `Employee.role` is typed as `WorkerType`. There are no `InstructorEmployee`, `CoordinatorEmployee` etc. subclasses. Role-based access control is enforced by checking `Employee.role` in the panel/event handler.
- **`Boat.sourceType` (External / Internal)** distinguishes center-owned boats from boats borrowed from an ExternalCenter. When `sourceType = External`, a link to an ExternalCenter record is implied — whether this is a direct FK on the Boat table or an association class is still to be determined against the final DB schema.
- **`Maintenance.status` reuses `BoatStatus`** — a maintenance record captures the boat's status state at the time of the report (`Active`, `Under Maintenance`, `Out Of Service`).
- **UC-11 exception rule:** A payroll discrepancy greater than 2 hours halts automatic approval. Manual override ("Approve Exception") requires a free-text justification of at least 10 characters. The override can be undone ("Undo Approval") to re-enter a red-alert state.
- **UC-03 time window:** Attendance reporting is locked 24 hours after the activity ends. The coordinator must make any corrections manually after that point.
- **Discount percentage validation:** Must be in range 0–100%. The system recalculates the customer's balance immediately on save.
- **All relationship multiplicities involving Activity** (to Employee, to Boat, to Customer/StudentsAttendanceReport) are not yet fully confirmed from the class diagram — the diagram image must be consulted before writing the DB schema for those tables.
