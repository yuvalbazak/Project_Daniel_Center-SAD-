# Use Case Specifications — My Daniel Management System

**Phase:** Analysis (Phase A)
**Version:** 1.0 | **Date:** June 2026
**Course:** Software Analysis and Design — Ben-Gurion University

> **Purpose of this document:**
> This file maps each functional requirement to a Use Case and provides detailed VP18-style specifications for representative UCs. Each specification uses a two-layer format: a technology-neutral **Behavioral Specification** section followed by a clearly labelled **Implementation Notes** section. Where implementation notes are not yet defined, a TODO placeholder is provided.

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
| **UC-04** | Assign Boats to Activities | Coordinator | 🔮 Future | ✅ §5.2 (MSS) |
| **UC-05** | Assign Instructors and Students | Coordinator | 🔮 Future | ✅ §5.3 (MSS) |
| **UC-06** | Report Attendance | Instructor | 🔮 Future | - |
| **UC-07** | Upload Reserve Duty (Miluim) | Instructor | 🔮 Future | - |
| **UC-08** | Approve Discount Request | Accounting Manager | 🔮 Future | - |
| **UC-09** | Generate BI/Operational Report | Center Manager | 🔮 Future | - |
| **UC-10** | Lesson Cancellation Update | Coordinator | 🔮 Future | ✅ §5.4 (MSS) |
| **UC-11** | Cross-Reference Payroll | Accounting Manager | 🔮 Future | ✅ §5.5 (MSS) |
| **UC-12** | View Active Operations | Center Manager | 🔮 Future | - |
| **UC-13** | Update Resources | Coordinator | 🔮 Future | ✅ §5.6 (MSS) |
| **UC-14** | Approve Payroll Exceptions | Center Manager | 🔮 Future | - |
| **UC-15** | View Missing Hours Report | Coordinator | 🔮 Future | - |
| **UC-16** | Sync Reserve Duty to Payroll | Instructor | 🔮 Future | - |
| **UC-17** | Manage Employees (CRUD) | Center Manager | 🔮 Future | - |
| **UC-18** | Notification on New Customer Request | Accounting Manager | 🔮 Future | - |
| **UC-19** | View Customer Request Status | Accounting Manager | 🔮 Future | - |
| **UC-20** | Auto-Update Request Status | Accounting Manager | 🔮 Future | - |
| **UC-21** | Activity Resource Assignment | Coordinator | 🔮 Future | ✅ §5.7 (MSS) |
| **UC-0501** | Outsource Boats Assignment | Coordinator | 🔮 Future | - |

### Legend
* **Status:** ✅ Implemented / 🔮 Future
* **Detailed Spec:** ✅ §[Number] (MSS) = formal MSS document exists; **-** = not yet specified

---

## 3. UC Diagram

For the detailed interactive visual diagrams and the formal MSS documents, please refer to:

**Path:** `/Project_Daniel_Center-SAD-/docs/UC_overview`

The diagram is structured into two functional domains:
- **Tab 1 — Operations:** Scheduling, Attendance, and Equipment Allocation (Coordinator, Instructor).
- **Tab 2 — Administration:** Customer Registration, Financial/Discount Management, and Payroll (Accounting Manager, Center Manager).

---

## 4. UC Relationships

### 4.1 Actor Generalization

Center Manager ──▷ Coordinator
- **Center Manager** inherits all **Coordinator** use cases.
- Arrow direction: child to parent (hollow triangle at parent end).

### 4.2 «include»

- **UC-21 (Activity Resource Assignment)** `«include»`s **UC-04 (Assign Boats)**.
- **UC-21 (Activity Resource Assignment)** `«include»`s **UC-05 (Assign Instructors and Students)**.

**Justification:** Both "Assign Boats" and "Assign Instructors and Students" are mandatory sub-behaviors that always execute as part of "Activity Resource Assignment." Neither sub-behavior has a direct actor association in this context.

### 4.3 «extend»

- **UC-0501 (Outsource Boats Assignment)** `«extend»`s **UC-13 (Update Resources)**.

**Justification:** The base UC (Update Resources) functions independently for standard in-house replacements. The extension (Outsource Boats Assignment) is conditional: it occurs only when the required equipment is unavailable in-house and the coordinator chooses to outsource, triggering the extension point `UC-13.Replace Boat/Instructor`.

---

## 5. Detailed Use Case Specifications

> **Format:** Each UC is structured in two layers:
> 1. **Behavioral Specification** — technology-neutral; describes what the system does in terms of actors and goals, with no class or stored-procedure names.
> 2. **Implementation Notes** — implementation-specific details: UI panel names, stored procedures, database tables, validation constraints. If not yet defined, marked as TODO.

---

### §5.1 UC-03 — Attendance and Exceptional Events Reporting

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-03 |
| **Name** | Attendance and Exceptional Events Reporting |
| **Source Diagram** | `UC Diagram 2- Employees and Customers (1).vpp` |
| **Primary Actor** | Instructor |
| **Status** | 🔮 Future |

#### Behavioral Specification

**Description:** The instructor records attendance and documents exceptional events for a specific activity.

**Preconditions:**
- The instructor is authenticated in the system.
- The activity exists in the system.
- Students are assigned to the selected activity.

**Postconditions:**
- Attendance statuses for all selected students are saved in the system.
- Exceptional event comments are documented and linked to the activity.

**Main Success Scenario:**
1. The instructor selects a specific activity.
2. The system displays the list of students assigned to the selected activity.
3. The instructor selects an attendance status for each student from a predefined list: "Present" / "Absent — Updated in Advance" / "Absent — Not Updated in Advance."
4. The instructor adds free-text comments if needed.
5. The instructor submits the attendance report.
6. The system verifies that the report is submitted during the activity or up to one day after it.
7. The system saves the attendance statuses and comments.
8. The system documents the attendance report and any exceptional events related to the activity.

**Extensions:**
- 1a. Activity not found or unauthorized: the system displays an error message and restricts access to the attendance list.
- 6a. Reporting window has expired (more than 24 hours post-activity): the system locks the editing fields and notifies the instructor to contact the coordinator for manual updates.
- 7a. Missing data: the system highlights students who have not been assigned a status and prevents submission until completion.

---

#### Implementation Notes

> **TODO:** Implementation details (UI panel, stored procedure, table names) not yet defined for this UC.

---

### §5.2 UC-04 — Assign Boats to Activities

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-04 |
| **Name** | Assign Boats to Activities |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator |
| **Status** | 🔮 Future |
| **Goal** | Allow the coordinator to assign available and operational boats to students participating in an activity. |

#### Behavioral Specification

**Preconditions:**
- An activity exists in the system.
- Students are assigned to the activity.
- Boats exist in the system.
- The coordinator is authenticated.

**Postconditions:**
- Boats are assigned to the activity participants.
- The assigned boats are marked as unavailable during the activity time.
- The updated assignment is saved in the system.

**Main Success Scenario:**
1. The coordinator enters the "Assign Boats" screen.
2. The system displays the selected activity and the list of participating students.
3. The system displays all available and operational boats.
4. The coordinator selects a boat for each student or group.
5. The system checks the availability and status of the selected boats.
6. The coordinator confirms the assignment.
7. The system saves the boat assignments.
8. The system updates the activity schedule and boat availability status.
9. The system displays a confirmation message.

**Extensions:**
- 3a. No available boats: the system displays a warning message. The coordinator may activate UC-0501 — Outsource Boats Assignment.
- 5a. Selected boat is out of service: the system displays a message indicating the boat is unavailable; the coordinator selects another boat.
- 5b. Scheduling conflict detected: the system identifies that the selected boat is already assigned to another activity, displays conflict details, and the coordinator selects another boat.
- 7a. System saving failure: the system displays an error message; the assignment is not saved until the issue is resolved.

---

#### Implementation Notes

> **TODO:** Implementation details (UI panel, stored procedure, table names) not yet defined for this UC.

---

### §5.3 UC-05 — Assign Instructors and Students

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-05 |
| **Name** | Assign Instructors and Students |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator |
| **Status** | 🔮 Future |
| **Goal** | Allow the coordinator to assign instructors and students to a specific activity according to availability, certification, and group characteristics. |

#### Behavioral Specification

**Preconditions:**
- An activity exists in the system.
- Instructors and students exist in the system.
- The coordinator is authenticated.
- Relevant instructors are marked as active and certified.

**Postconditions:**
- The selected instructor is assigned to the activity.
- The selected students are assigned to the activity.
- The updated assignment is saved in the system.
- The activity schedule is updated.

**Main Success Scenario:**
1. The coordinator enters the "Assign Instructors and Students" screen.
2. The system displays the selected activity details.
3. The system displays a list of available and certified instructors.
4. The coordinator selects an instructor for the activity.
5. The system displays a list of students relevant to the activity based on age group and activity type.
6. The coordinator selects students for the activity.
7. The system validates instructor and student availability.
8. The coordinator confirms the assignment.
9. The system saves the instructor and student assignments.
10. The system updates the activity schedule.
11. The system displays a confirmation message.

**Extensions:**
- 3a. No available instructor: the system displays a warning; the coordinator may select another activity time.
- 5a. No available students: the system displays a message indicating no students match the activity requirements; the coordinator may modify the activity criteria.
- 7a. Scheduling conflict detected: the system identifies a conflict with the selected instructor or students, displays conflict details, and the coordinator selects different participants.
- 9a. System saving failure: the system displays an error message; the assignment is not saved until the issue is resolved.

---

#### Implementation Notes

> **TODO:** Implementation details (UI panel, stored procedure, table names) not yet defined for this UC.

---

### §5.4 UC-10 — Lesson Cancellation Update

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-10 |
| **Name** | Lesson Cancellation Update |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator, Instructors |
| **Status** | 🔮 Future |
| **Goal** | Allow the coordinator or instructors to notify participants about a lesson cancellation due to weather conditions or other unexpected events. |

#### Behavioral Specification

**Preconditions:**
- The coordinator is authenticated.
- An activity exists in the schedule.
- Participants are assigned to the activity.
- Contact information for participants exists in the system.

**Postconditions:**
- The activity status is updated to "Canceled."
- Participants receive a cancellation notification.
- The activity schedule is updated in the system.

**Main Success Scenario:**
1. The coordinator enters the "Lesson Cancellation Update" screen.
2. The system displays the list of scheduled activities.
3. The coordinator selects the activity to cancel.
4. The coordinator enters the cancellation reason.
5. The coordinator confirms the cancellation.
6. The system updates the activity status to "Canceled."
7. The system sends a cancellation notification to all registered participants.
8. The system updates the activity schedule.
9. The system displays a confirmation message.

**Extensions:**
- 3a. Activity does not exist: the system displays an error message; the coordinator selects another activity.
- 7a. Notification delivery failure: the system displays a warning that the notification could not be sent to some participants; the system logs the failed notifications for follow-up.
- 8a. Schedule update failure: the system displays an error message; the cancellation process is not completed until the issue is resolved.

---

#### Implementation Notes

> **Notification:** System-triggered participant alerts (in-app message or SMS) containing the cancellation reason.
>
> _Further implementation details (UI panel, stored procedure) not yet defined._

---

### §5.5 UC-11 — Cross-Reference Payroll

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-11 |
| **Name** | Cross-Reference Payroll |
| **Source Diagram** | `UC Diagram 2- Employees and Customers (1).vpp` |
| **Primary Actor** | Accounting Manager / Center Manager (System Time trigger) |
| **Status** | 🔮 Future |

#### Behavioral Specification

**Description:** Automates the comparison between employee reported hours and actual activity hours to identify discrepancies requiring management review.

**Preconditions:**
- Employees have already submitted their attendance hours (check-in/check-out).
- The system has the actual activity data recorded.
- A management employee is authenticated.

**Postconditions:**
- The shift report is updated to "Approved."
- Any manual changes made to hours are saved.
- The written note explaining the exception is saved.

**Main Success Scenario:**
1. The system reaches the scheduled time and starts the automatic comparison.
2. The system checks each employee's reported hours against the actual activity hours logged.
3. The system finds no differences greater than two hours.
4. The system automatically marks the hours as "Approved."
5. The system displays a clean dashboard report with zero alerts.

**Extensions:**
- 2a. Employee has actual activity logs but completely forgot to clock in (Reported Hours = 0): the system flags the record as "Missing Attendance Report" and alerts the management employee to manually create a new attendance log.
- 2b. Difference between reported hours and actual hours is greater than two hours:
  - The system creates a visual alert (highlights the row in red).
  - The system stops automatic approval for this record and waits for the management employee to choose: fix the hours or approve the exception.
  - Fix hours: the system opens the hours for editing; the management employee types corrected hours and saves; the system recalculates and re-evaluates.
  - Approve exception: the management employee clicks "Approve Exception"; the system opens a mandatory text box; the management employee types a reason of at least 10 characters; the system saves the note and removes the red alert.
  - 2b.undo: if approved by mistake, the management employee clicks "Undo Approval"; the system restores the red alert status and allows re-editing or re-evaluating.

---

#### Implementation Notes

> **Logic:** Automated comparison between `ReportedHours` and `ActualActivityHours`.
> **Output:** `ExceptionsReportView` dashboard.
>
> _Further implementation details (stored procedure name, table names) not yet defined._

---

### §5.6 UC-02 — Customer Management (Digital Registration)

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-02 |
| **Name** | Customer Management |
| **Source Diagram** | `UC Diagram 2- Employees and Customers (1).vpp` |
| **Primary Actor** | Customer (registration), Management Employee (profile management) |
| **Status** | 🔮 Future |

#### Behavioral Specification

**Description:** Covers the full customer lifecycle: digital self-registration, discount request handling, profile editing, and archiving.

**Preconditions:**
- The system is online and connected to the database.
- The customer has access to the digital registration link.
- The manager/bookkeeper is authenticated with appropriate permissions.

**Postconditions:**
- A new customer profile is stored with all legal/medical documents attached.
- The customer's financial balance is automatically synchronized based on the approved discount.
- All lifecycle actions are recorded and visible in the database.

**Main Success Scenario:**
1. The customer opens the digital registration form.
2. The customer enters personal details (Full Name, ID, Phone, Email, City, Date of Birth).
3. The customer uploads a signed Health Declaration and adds optional comments.
4. The customer submits the form.
5. The system verifies that all mandatory fields are filled and that the National ID is unique.
6. The system creates an active customer profile.
7. The accounting manager searches for the profile, edits necessary fields, and saves.
8. The accounting manager may change the status of an inactive customer to "Archive."

**Extensions:**
- 4a. Optional discount request: the customer selects a discount category (e.g., Soldier, Student) and uploads an eligibility document.
  - The system sets the request status to "In Progress" and alerts the Accounting Manager.
  - The Accounting Manager reviews the eligibility document.
  - If the document is unreadable or invalid: the Accounting Manager sets the status to "Missing Documents"; the system notifies the customer to re-upload.
  - The Accounting Manager approves the discount and enters the percentage (0–100%).
  - If the percentage is invalid: the system prevents saving and requests a valid number.
  - The system recalculates the balance and updates the status to "Completed."
- 5a. Mandatory fields missing or National ID already exists: the system blocks submission and displays a specific error message.
- 7a. Manager closes edit screen without saving: the system displays a warning: "Unsaved changes will be lost."
- 8a. Customer has an outstanding debt: the system alerts the Accounting Manager and requires override confirmation before archiving.

---

#### Implementation Notes

> **UI:** `RegistrationFormPanel`
> **Logic:** `SP_create_customer`
>
> _Further implementation details (table names, validation constraints) not yet defined._

---

### §5.7 UC-21 — Activity Resource Assignment

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-21 |
| **Name** | Activity Resource Assignment |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator |
| **Status** | 🔮 Future |

#### Behavioral Specification

**Description:** The coordinator assigns the required resources (instructors, boats, students) to a planned activity to ensure safe and organized execution. This UC includes UC-04 (Assign Boats) and UC-05 (Assign Instructors and Students) as mandatory sub-behaviors.

**Preconditions:**
- The coordinator is authenticated.
- Activities, instructors, students, and boats exist in the system.
- Relevant resources are marked as active and available.

**Postconditions:**
- The activity is updated with assigned boats, instructors, and students.
- The activity schedule is updated in the system.

**Main Success Scenario:**
1. The coordinator enters the "Activity Resource Assignment" screen.
2. The system displays the activity schedule.
3. The coordinator selects an existing activity or creates a new one.
4. The coordinator enters the activity details.
5. The system activates UC-04 — Assign Boats.
6. The system activates UC-05 — Assign Instructors and Students.
7. The system validates resource availability and scheduling conflicts.
8. The system saves the activity assignment.
9. The system updates the activity schedule.
10. The system displays a confirmation message.

**Extensions:**
- 5a. No available boats: the system displays a warning; the coordinator may activate UC-0501 — Outsource Boats Assignment.
- 6a. No available instructor: the system displays a warning; the coordinator selects another instructor or changes the activity time.
- 7a. Scheduling conflict detected: the system displays the conflict details; the coordinator updates the selected resources.

---

#### Implementation Notes

> **UI:** `ResourceAssignmentPanel`
> **Logic:** `SP_assign_resource`
> **Validation:** Check for time conflicts before saving assignments.
>
> _Further implementation details (table names) not yet defined._

---

### §5.8 UC-13 — Update Resources (Replace Boat/Instructor)

| Field | Value |
| :--- | :--- |
| **UC ID** | UC-13 |
| **Name** | Update Resources (Replace Boat/Instructor) |
| **Source Diagram** | `UC Diagram 1- Activities and Logistics.vpp` |
| **Primary Actor** | Coordinator |
| **Status** | 🔮 Future |
| **Goal** | Allow the coordinator to replace assigned resources during an activity in case of an unexpected issue or equipment failure. |

#### Behavioral Specification

**Preconditions:**
- An activity already exists in the system with assigned resources.
- The coordinator is authenticated.
- A problem or unexpected issue has been identified during the activity.

**Postconditions:**
- The selected boat or instructor is replaced in the activity.
- The updated assignment is saved in the system.
- The activity schedule reflects the updated resources.

**Main Success Scenario:**
1. The coordinator enters the "Replace Boat/Instructor" screen.
2. The system displays the current activity details, including assigned instructors, students, and boats.
3. The coordinator selects the resource that requires replacement.
4. The system displays available replacement boats and instructors.
5. The coordinator selects a replacement resource.
6. The system validates the availability of the selected replacement.
7. The system updates the activity assignment.
8. The system updates the activity schedule.
9. The system displays a confirmation message.

**Extensions:**
- 4a. No available replacement boat: the system displays a warning; the coordinator may activate UC-0501 — Outsource Boats Assignment.
- 4b. No available replacement instructor: the system displays a warning; the coordinator may postpone or cancel the activity.
- 6a. Scheduling conflict detected: the system displays conflict details; the coordinator selects another replacement resource.
- System update failure: the system displays an error message; the replacement process is canceled until the issue is resolved.

---

#### Implementation Notes

> **UI:** `ReplaceResourcePanel`
> **Logic:** `SP_update_resource_assignment`
>
> _Further implementation details (table names, validation constraints) not yet defined._

---

## 6. AI Agent Usage Notes

The following fields in each UC spec are directly actionable by a coding agent:

| UC Field | AI Generation Logic |
| :--- | :--- |
| **Primary Actor + Preconditions** | Defines the authentication/role-based security middleware. |
| **Behavioral Specification Flow** | Maps directly to the sequence of method calls, API requests, and UI state transitions within the event handler. |
| **Extensions** | Defines input validation, error handling, and guard clauses. |
| **Postconditions** | Defines the success criteria for state mutation and required data persistence confirmation. |
| **Implementation Notes** | Provides the specific Class/Panel names, Stored Procedure (SP) mappings, and existing system components to reuse. |

### Generation Strategy
For optimal code generation, process fields in this order:
1. **Architecture:** Review `Implementation Notes` to identify the relevant Panel and SP.
2. **Security:** Validate `Primary Actor` permissions.
3. **Validation:** Implement `Extensions` constraints first.
4. **Logic:** Map `Behavioral Specification Flow` to the method body.

> **Note:** The `Description` is for high-level context only; the functional logic is derived from the structured fields above.
