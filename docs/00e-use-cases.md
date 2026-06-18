# Use Case Specifications — My Daniel Management System

**Phase:** Analysis (Phase A)  
**Version:** 1.0 | **Date:** June 2026  
**Course:** Software Analysis and Design — Ben-Gurion University

> **Purpose of this document:**  
> This file is the primary analytical input for the development phase. It maps each functional requirement to a Use Case and provides detailed VP18-style specifications for representative UCs. An AI coding agent given any single UC specification below has sufficient information to generate the corresponding panel, entity method, and stored procedure without additional clarification.

---

## 0. Authentication — Non-Functional Requirement

**Login/Logout are NOT use cases in this system.**

Authentication is a cross-cutting non-functional requirement. The `LoginPanel` is a technical precondition that runs before any actor can reach a functional panel:

- The application starts at `LoginPanel`.
- The system verifies the user's identity using their credentials.
- On success: the authenticated user is held in session; the system navigates to the relevant dashboard based on the user's role (Manager, Coordinator, Instructor, Accountant, or Customer).
- All UC preconditions below assume the actor is already authenticated.

---

## 1. Actors

| Actor | Type | Role in the System |
| :--- | :--- | :--- |
| **Center Manager** | Human — Primary | Has overall responsibility for the center. Accesses all management modules, BI reports, and employee profiles. |
| **Accounting Manager** | Human — Primary | Manages billing, customer subscriptions, discount approvals, and payroll synchronization. |
| **Coordinator** | Human — Primary | Manages day-to-day operations, including boat maintenance, instructor scheduling, and equipment allocation. |
| **Instructor** | Human — Primary | Leads activities. Reports attendance, documents events, and uploads reserve duty approvals. |
| **Customer** | Human — Primary | End-user participating in center activities. Views schedule, fills registration forms, and tracks requests. |
| **System** | Automated | Triggers scheduled syncs, backups, and automated reports. |

---
> **Note:** The Coordinator is part of the center's management team and does not require instructor-level permissions.


## 2. Use Case Inventory

| UC ID | Name | Primary Actor | Status | Detailed Spec |
| :--- | :--- | :--- | :--- | :--- |
| **UC-01** | Create New Customer | Accounting Manager | 🔮 Future | - |
| **UC-02** | Manage Customer Profile | Coordinator | 🔮 Future | - |
| **UC-03** | Attendance and Exceptional Events | Instructor | 🔮 Future | ✅ §5.1 (MSS) |
| **UC-04** | Assign Boats to Activities | Coordinator | 🔮 Future | - |
| **UC-05** | Manage Watercraft (CRUD) | Coordinator | 🔮 Future | - |
| **UC-06** | Report Attendance | Instructor | 🔮 Future | ✅ §5.2 (MSS) |
| **UC-07** | Upload Reserve Duty (Miluim) | Instructor | 🔮 Future | - |
| **UC-08** | Approve Discount Request | Accounting Manager | 🔮 Future | - |
| **UC-09** | Generate BI/Operational Report | Center Manager | 🔮 Future | - |
| **UC-10** | Lesson Cancellation Update | Coordinator | 🔮 Future | ✅ §5.3 (MSS) |
| **UC-11** | Cross-Reference Payroll | Accounting Manager | 🔮 Future | - |
| **UC-12** | View Active Operations | Center Manager | 🔮 Future | - |
| **UC-13** | Update Resources | Coordinator | 🔮 Future | - |
| **UC-14** | Approve Payroll Exceptions | Center Manager | 🔮 Future | ✅ §5.4 (MSS) |
| **UC-15** | View Missing Hours Report | Coordinator | 🔮 Future | - |
| **UC-16** | Sync Reserve Duty to Payroll | Instructor | 🔮 Future | - |
| **UC-17** | Manage Employees (CRUD) | Center Manager | 🔮 Future | ✅ §5.5 (MSS) |
| **UC-18** | Notification on New Customer Request | Accounting Manager | 🔮 Future | - |
| **UC-19** | View Customer Request Status | Accounting Manager | 🔮 Future | - |
| **UC-20** | Auto-Update Request Status | Accounting Manager | 🔮 Future | - |

### Legend:
* **Status:**
    * ✅ **Implemented**: Fully built in the current version.
    * 🔮 **Future**: Planned for a future version (initial baseline).
* **Detailed Spec:**
    * ✅ **§[Number] (MSS)**: Indicates a formal Microsoft Specification document exists in the project documentation directory.
    * **-**: No formal detailed specification document exists at this stage.

## 3. UC Diagram

For the detailed interactive visual diagrams and the formal Microsoft Specification (MSS) documents, please refer to the project repository:

**Path:** `/Project_Daniel_Center-SAD-/docs/UC_overview`

The diagram is structured into functional domains to ensure clarity:
- **Tab 1 — Operations:** Scheduling, Attendance, and Equipment Allocation (Coordinator, Instructor).
- **Tab 2 — Administration:** Customer Registration, Financial/Discount Management, and Payroll (Accounting Manager, Center Manager).

Please consult the files within the specified directory for the full behavioral analysis and flow of events for each Use Case.

---
## 4. UC Relationships

### 4.1 Actor Generalization

Center Manager ──▷ Coordinator
- **Center Manager** inherits all **Coordinator** use cases.
- Arrow direction: child to parent (hollow triangle at parent end).

### 4.2 «include»

- **UC-02 (Activity Resource Assignment)** `«include»`s **UC-03 (Assign Boats)**.
- **UC-02 (Activity Resource Assignment)** `«include»`s **UC-04 (Assign Instructors and Students)**.

**Justification:** Both "Assign Boats" and "Assign Instructors and Students" are mandatory sub-behaviors that always execute as part of the "Activity Resource Assignment" process. Neither sub-behavior has a direct actor association in this context; they are functional steps required to complete the base Use Case.

### 4.3 «extend»

- **UC-0501 (Outsource Boats Assignment)** `«extend»`s **UC-05 (Replace Boat/Instructor)**.

**Justification:** The base UC (Replace Boat/Instructor) functions independently for standard in-house replacements. The extension (Outsource Boats Assignment) is conditional: it occurs only when the required equipment is unavailable in-house and the coordinator chooses to outsource, triggering the extension point `UC-05.Replace Boat/Instructor`.

---

## 5. Detailed Use Case Specifications

### 5.1 UC-02 — Activity Resource Assignment
| Field | Value |
| :--- | :--- |
| **UC ID** | UC-02 |
| **Name** | Activity Resource Assignment |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator |
| **Status** | 🔮 Future |

**Description:** Coordinator assigns necessary resources (instructors, boats) to a planned activity to ensure safe execution.

**Preconditions:**
- Coordinator is authenticated.
- The activity is already created in the system.

**Main Success Scenario:**
1. Coordinator selects the activity from the schedule.
2. System displays available instructors and boats.
3. Coordinator selects resources and assigns them to the activity.
4. System validates resource availability (no conflicts).
5. System persists assignments.

**Implementation Notes:**
- **UI:** `ResourceAssignmentPanel`
- **Logic:** `SP_assign_resource`
- **Validation:** Check `ActivityResources` table for time conflicts.

---

### 5.2 UC-05 — Replace Boat/Instructor
| Field | Value |
| :--- | :--- |
| **UC ID** | UC-05 |
| **Name** | Replace Boat/Instructor |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator |
| **Status** | 🔮 Future |

**Description:** Allows real-time updates to assigned resources for an existing activity due to unexpected changes.

**Preconditions:**
- Activity is already assigned resources.

**Main Success Scenario:**
1. Coordinator selects an active activity.
2. System displays current resource assignments.
3. Coordinator selects the resource to replace and the new resource.
4. System validates the new resource is available.
5. System updates assignment records.

**Extensions:**
- 4a. Resource unavailable: System displays a warning and blocks the update.

**Implementation Notes:**
- **UI:** `ReplaceResourcePanel`
- **Logic:** `SP_update_resource_assignment`

---

### 5.3 UC-06 — Report Attendance
| Field | Value |
| :--- | :--- |
| **UC ID** | UC-06 |
| **Name** | Report Attendance |
| **Source Diagram** | `UC Diagram 2- Employees and Customers (1).vpp` |
| **Primary Actor** | Instructor |
| **Status** | 🔮 Future |

**Description:** Instructor records student attendance, documenting presence, excused absences, and exceptional events.

**Preconditions:**
- Instructor is assigned to the specific activity.

**Main Success Scenario:**
1. Instructor opens the activity roster.
2. Instructor marks status for each student (Present / Absent-Excused / Absent-Unexcused).
3. Instructor adds notes for exceptional events.
4. Instructor submits the report.

**Implementation Notes:**
- **UI:** `AttendancePanel`
- **Logic:** `SP_save_attendance`
- **Validation:** Ensure only past or current activities can be updated.

---

### 5.4 UC-11 — Cross-Reference Payroll
| Field | Value |
| :--- | :--- |
| **UC ID** | UC-11 |
| **Name** | Cross-Reference Payroll |
| **Source Diagram** | `UC Diagram 2- Employees and Customers (1).vpp` |
| **Primary Actor** | Accounting Manager / Center Manager |
| **Status** | 🔮 Future |

**Description:** Automates the comparison between worker reported hours and actual activity hours to identify discrepancies.

**Preconditions:**
- Payroll and activity data are available for the period.

**Main Success Scenario:**
1. User triggers the sync process.
2. System compares `ReportedHours` with `ActualActivityHours`.
3. System displays a report of all discrepancies/exceptions.
4. User reviews and marks exceptions for approval.

**Implementation Notes:**
- **Logic:** `SP_compare_hours`
- **Output:** `ExceptionsReportView`

---

### 5.5 UC-01 — Digital Registration
| Field | Value |
| :--- | :--- |
| **UC ID** | UC-01 |
| **Name** | Digital Registration |
| **Source Diagram** | `UC Diagram 2- Employees and Customers (1).vpp` |
| **Primary Actor** | Customer |
| **Status** | 🔮 Future |

**Description:** Customer submits personal details and documentation via a digital form.

**Preconditions:**
- Customer has access to the registration portal.

**Main Success Scenario:**
1. Customer enters personal details and contact info.
2. Customer uploads required documents.
3. System validates format and completeness.
4. System stores the record and notifies the management.

**Implementation Notes:**
- **UI:** `RegistrationFormPanel`
- **Logic:** `SP_create_customer`

---

### 5.6 UC-10 — Lesson Cancellation Update
| Field | Value |
| :--- | :--- |
| **UC ID** | UC-10 |
| **Name** | Lesson Cancellation Update |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator |
| **Status** | 🔮 Future |

**Description:** Coordinator cancels a lesson and updates all stakeholders.

**Main Success Scenario:**
1. Coordinator selects the lesson and clicks "Cancel".
2. Coordinator enters the reason.
3. System updates status and triggers automated notifications to customers.

**Implementation Notes:**
- **Notification:** `System.SendNotification()`

---

## 6. AI Agent Usage Notes

The following fields in each UC spec are directly actionable by a coding agent:

| UC Field | AI Generation Logic |
| :--- | :--- |
| **Primary Actor + Preconditions** | Defines the authentication/role-based security middleware (e.g., `if (user.Role != Role.Coordinator) throw Unauthorized;`). |
| **Flow of Events** | Maps directly to the sequence of method calls, API requests, and UI state transitions within the event handler. |
| **Extensions** | Defines input validation, error handling, and guard clauses (e.g., `if (input == null) return Error;`). |
| **CRUD Fields** | Specifies the Data Model properties (DTOs/Entities) and the corresponding UI form control validation logic. |
| **Postconditions** | Defines the success criteria for state mutation and the required data persistence confirmation. |
| **Implementation Notes** | Provides the specific Class/Panel names, Stored Procedure (SP) mappings, and existing system components to reuse. |
| **Linked USs** | Serves as the source of truth for Unit Testing and Acceptance Criteria. |

### Generation Strategy
For optimal code generation, the agent must process these fields in the following order:
1.  **Architecture:** Review `Implementation Notes` to identify the relevant `Panel` and `SP`.
2.  **Security:** Validate `Primary Actor` permissions.
3.  **Validation:** Implement `Extensions` and `CRUD Fields` constraints first.
4.  **Logic:** Map `Flow of Events` to the method body, ensuring each step updates the system state as defined in `Postconditions`.

> **Note:** The `Description` and `User Stories` are for high-level context only; the functional logic is derived exclusively from the structured fields listed above.
