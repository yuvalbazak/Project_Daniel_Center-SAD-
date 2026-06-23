# Class Diagram — My Daniel Management System

**Phase:** Design
**Source:** `docs/ClassDiagram/ClassDiagramמתוקן.pdf`
**Version:** 1.0 | **Date:** June 2026

> The class diagram image is the source of truth. Do not treat the text below as authoritative over the diagram. Export the diagram from the modeling tool and save it as `class-diagram.png`.

![class diagram](class-diagram.png)

---

## Entities, Attributes, and Methods

### Employee

| Attribute | Type |
| :--- | :--- |
| `-id` | String |
| `-fullName` | String |
| `-role` | WorkerType |
| `-startDate` | Date |
| `-phone` | String |
| `-email` | String |

| Method | |
| :--- | :--- |
| `+viewEmployeesDetails()` | |
| `+updateEmployeeDetails()` | |
| `+addToArchive()` | |
| `+accessRestriction()` | |

---

### Customer

| Attribute | Type |
| :--- | :--- |
| `-id` | String |
| `-fullName` | String |
| `-phone` | String |
| `-email` | String |
| `-address` | String |
| `-birthDate` | Date |
| `-startDate` | Date |
| `-emergencyContact` | String |
| `-paymentDate` | Date |
| `-customerStatus` | CustomerStatus |
| `-paymentStatus` | PaymentStatus |

| Method | |
| :--- | :--- |
| `+registrationReoprt()` | |
| `+editCustomerDetails()` | |
| `+viewUnregisteredCustomers()` | |
| `+viewCustomersDetails()` | |
| `+addToArchive()` | |

---

### Activity

| Attribute | Type |
| :--- | :--- |
| `-activityNum` | int |
| `-activityType` | ActivityType |
| `-dateTime` | DateTime |
| `-location` | String |
| `-ageGroup` | AgeGroup |

| Method | |
| :--- | :--- |
| `+createActivity()` | |
| `+viewActivityScheduele()` | |
| `+resourceAssignment()` | |
| `+reschedueleActivity()` | |
| `+cancelActivity()` | |
| `+replaceBoat()` | |
| `+replaceInstructor()` | |
| `+viewActivityDetails()` | |

---

### Boat

| Attribute | Type |
| :--- | :--- |
| `-boatNum` | int |
| `-boatType` | BoatType |
| `-waterCraftName` | String |
| `-boatStatus` | BoatStatus |
| `-purchaseDate` | Date |
| `-lisenceDate` | Date |
| `-annualMaintenanceDate` | Date |
| `-sourceType` | SourceType |

| Method | |
| :--- | :--- |
| `+viewBoatsStatus()` | |
| `+editStatus()` | |

---

### Discount Request

| Attribute | Type |
| :--- | :--- |
| `-requestNum` | int |
| `-discountType` | String |
| `-file` | String |
| `-discountStatus` | DiscountStatus |
| `-discountPercent` | float |
| `-submittedAt` | Date |
| `-resolvedAt` | Date |

| Method | |
| :--- | :--- |
| `+approveDiscount()` | |
| `+rejectDiscount()` | |
| `+updateDIscountStatus()` | |
| `+uploadDiscountFile()` | |

---

### Maintenance

| Attribute | Type |
| :--- | :--- |
| `-meintenanceID` | String |
| `-reportedAt` | Date |
| `-description` | String |
| `-status` | BoatStatus |
| `-resolevedAt` | Date |
| `-cost` | float |
| `-technicianName` | String |

| Method | |
| :--- | :--- |
| `+editStatus()` | |
| `+reportMaintenance()` | |
| `+viewMaintenanceReport()` | |

---

### External Center

| Attribute | Type |
| :--- | :--- |
| `-centerID` | String |
| `-centerName` | String |
| `-contactName` | String |
| `-phone` | String |

| Method | |
| :--- | :--- |
| `+outSourceBoatAssignment()` | |
| `+viewContactDetails()` | |

---

### Students Attendance Report

| Attribute | Type |
| :--- | :--- |
| `-recordID` | String |
| `-notes` | String |
| `-attendanceStatus` | AttendanceStatus |

| Method | |
| :--- | :--- |
| `+updateStatus()` | |
| `+addNote()` | |
| `+markAttendance()` | |

---

### Work Hours Report

| Attribute | Type |
| :--- | :--- |
| `-reportNum` | int |
| `-checkIn` | Date |
| `-checkOut` | Date |
| `-reportedHours` | float |
| `-actualHours` | float |
| `-exception` | Boolean |
| `-isApproved` | Boolean |
| `-approvalNote` | String |

| Method | |
| :--- | :--- |
| `+syncActualAndReportedHours()` | |
| `+approveHoursException()` | |
| `+editWorkHours()` | |
| `+addExplanationNote()` | |
| `+uploadServiceDutyFile()` | |
| `+createExceptionHoursEmployeesReport()` | |

---

## Enumerations

| Enumeration | Values |
| :--- | :--- |
| **WorkerType** | Center Manager, Administration Staff, Accounting Manager, Coordinator, Instructor |
| **CustomerStatus** | Active, Unpaid, Archive |
| **PaymentStatus** | Paid, Payment In Process, Unpaid |
| **ActivityType** | Kayaking, Sailing, Academic Rowing |
| **AgeGroup** | Junior, Youth, Senior, Elite |
| **BoatType** | Kayak, Sailing Boat, AcademicKayak |
| **BoatStatus** | Active, Under Maintenance, Out Of Service |
| **DiscountStatus** | Pending Document Upload, In Progress, Approved, Declined |
| **AttendanceStatus** | present, absent with notice, absent without notice |
| **SourceType** | External, Internal |

---

## Relationships

> **Note:** The relationship lines are visual in the diagram and cannot be extracted from the PDF text. The multiplicities visible in the source are: `0...* — 1`, `1 — 0...*`, `1 — 0...1`, `* — 0...1`, and `1`. The table below reflects best-effort interpretation; verify against the diagram image.

| From | Multiplicity | To | Multiplicity | Relationship Type | Notes |
| :--- | :---: | :--- | :---: | :--- | :--- |
| Customer | 1 | Discount Request | 0...* | Association | A customer may submit zero or more discount requests |
| Boat | 1 | Maintenance | 0...* | Association | A boat may have zero or more maintenance records |
| Employee | 1 | Work Hours Report | 0...* | Association | An employee has zero or more work-hour reports |
| Activity | 0...* | Students Attendance Report | TODO | Association | TODO: verify multiplicity from diagram |
| Activity | TODO | Boat | TODO | TODO | TODO: verify — direct association or via assignment class? |
| Activity | TODO | Employee | TODO | TODO | TODO: verify — how instructors are linked to activities |
| Activity | TODO | Customer | TODO | TODO | TODO: verify — how students are linked to activities |
| Boat | TODO | External Center | TODO | TODO | TODO: verify — is `sourceType` attribute sufficient, or is there a direct link? |

---

## Association Classes

> **TODO:** Confirm from the diagram image whether any association classes exist (e.g., for Activity–Boat or Activity–Employee assignments). None were identifiable from the text extraction.

---

## External System References

The diagram references two external systems that integrate with the class model:

| System | Role |
| :--- | :--- |
| **PayrollSystem** | External system receiving payroll data from Work Hours Report |
| **Report Hours System** | External system (Synel) that employees use to clock in/out |

---

## Design Assumptions

> **TODO:** Fill in after reviewing the diagram image.

Known from source:
- `Employee.role` uses the `WorkerType` enumeration — all staff roles are modelled as a single `Employee` class with a role attribute, not as separate subclasses.
- `Boat.sourceType` (External / Internal) indicates whether a boat is owned by the center or borrowed from an External Center.
- `Maintenance.status` reuses the `BoatStatus` type, meaning a maintenance record reflects the boat's status at the time of the report.
