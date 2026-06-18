# Business Processes — Daniel Rowing Center

**Document:** Business Process Description and BPMN Analysis  
**Source:** Stakeholder Interviews, Observations and BPMN Models  
**Prepared by:** Project Team

---

## Business Process Overview

| ID | Process Name | Participants | Complexity | BPMN |
|---|---|---|---|---|
| BP-01 | Instructor Scheduling, Attendance Reporting and Payroll Synchronization | Coordinator, Instructor, Accounting Manager | High | ✅ |
| BP-02 | Customer Registration and Membership Management | Customer, Accounting Manager, Coordinator | High | ✅ |
| BP-03 | Boat and Equipment Maintenance Management | Instructor, Coordinator, Maintenance Staff | Medium | ✅ |

---

# BP-01 — Instructor Scheduling, Attendance Reporting and Payroll Synchronization

## Process Objective

To manage sailing and rowing activities, assign instructors to activities, track attendance, and ensure accurate payroll calculations.

---

## Participants

- Sailing Coordinator
- Instructor
- Accounting Manager
- Center Manager

---

## Process Description

The process begins when the coordinator creates the weekly activity schedule and assigns instructors to training sessions.

Each instructor conducts the assigned activity and reports attendance through the Synel system.

At the end of each month, attendance reports are compared against the actual activity schedule. The Accounting Manager and Coordinator manually review discrepancies and update payroll records when necessary.

Special cases such as reserve-duty service require additional verification and supporting documentation.

---

## Link to Identified Problems

| Problem | How the Process Addresses It |
|---|---|
| P-05 — Inconsistent attendance reporting | Attendance reports are compared with actual activities |
| P-06 — Manual data analysis | Payroll data is consolidated for reporting |
| P-08 — Organizational knowledge dependency | Activity records are documented centrally |
| P-10 — Manual attendance tracking | Attendance data is collected for each activity |

---

## Main Flow (Happy Path)

1. Coordinator creates activity schedule.
2. Coordinator assigns instructors.
3. Instructor conducts activity.
4. Instructor reports attendance in Synel.
5. Monthly attendance reports are generated.
6. Accounting Manager reviews reports.
7. Payroll is calculated.
8. Salary is approved and processed.

---

## Exceptions

### Instructor Forgets to Report Attendance

- Attendance discrepancy is detected during payroll review.
- Coordinator verifies activity records.
- Attendance report is corrected manually.

### Reserve Duty Service

- Instructor submits reserve-duty documentation.
- Accounting Manager verifies documentation.
- Payroll records are updated accordingly.

---

# BP-02 — Customer Registration and Membership Management

## Process Objective

To register new customers, manage memberships, process payments, and maintain customer records.

---

## Participants

- Customer
- Accounting Manager
- Sailing Coordinator
- Customer Service Staff

---

## Process Description

The process begins when a potential customer contacts the center.

The customer receives information regarding available activities and suitable programs. Personal information is collected and entered into the Fizikal system.

The customer first registers for a trial lesson. Following the trial session, the customer decides whether to continue with a membership or course.

If the customer is eligible for a discount, supporting documents are submitted and reviewed manually.

---

## Link to Identified Problems

| Problem | How the Process Addresses It |
|---|---|
| P-04 — Manual customer registration | Customer information is collected and managed |
| P-07 — Manual discount approval | Discount requests are processed |
| P-02 — Fragmented information | Customer data is maintained across systems |

---

## Main Flow (Happy Path)

1. Customer contacts the center.
2. Activity options are presented.
3. Customer information is collected.
4. Trial lesson is scheduled.
5. Customer completes trial lesson.
6. Customer decides to enroll.
7. Membership is created.
8. Payment is processed.
9. Customer becomes an active participant.

---

## Exceptions

### Customer Cancels After Trial Lesson

- Registration process is closed.
- No membership is created.

### Discount Request Submitted

- Customer uploads supporting documents.
- Accounting Manager reviews eligibility.
- Discount is approved or rejected.

---

# BP-03 — Boat and Equipment Maintenance Management

## Process Objective

To ensure the availability, safety, and operational condition of boats and sailing equipment.

---

## Participants

- Instructor
- Sailing Coordinator
- Maintenance Staff
- External Technician

---

## Process Description

The process begins when an instructor identifies a fault in a boat or equipment item.

The issue is reported to the coordinator, typically through WhatsApp communication.

The coordinator evaluates the issue and determines whether an alternative boat is available.

Minor issues are repaired internally. More complex issues require external maintenance services.

Equipment status and maintenance activities are manually recorded in Excel spreadsheets.

---

## Link to Identified Problems

| Problem | How the Process Addresses It |
|---|---|
| P-01 — Lack of maintenance tracking | Maintenance activities are documented |
| P-02 — Fragmented information | Equipment information is centralized |
| P-08 — Knowledge dependency | Maintenance history is preserved |

---

## Main Flow (Happy Path)

1. Instructor identifies a fault.
2. Fault is reported to the coordinator.
3. Coordinator evaluates equipment availability.
4. Alternative equipment is assigned if available.
5. Maintenance action is performed.
6. Equipment status is updated.
7. Boat returns to operational use.

---

## Exceptions

### Alternative Boat Available

- Activity continues using replacement equipment.
- Faulty boat is sent for maintenance.

### No Alternative Boat Available

- Coordinator contacts other municipal centers.
- External equipment is borrowed if available.

### Major Equipment Failure

- External technician is contacted.
- Equipment remains unavailable until repairs are completed.

---

# BPMN Diagrams

The BPMN diagrams were created for the three primary business processes identified during the current-state analysis.

| Process | BPMN File |
|---|---|
| BP-01 — Instructor Scheduling, Attendance Reporting and Payroll Synchronization | `bpmn-payroll-synchronization.html` |
| BP-02 — Customer Registration and Membership Management | `bpmn-customer-registration.html` |
| BP-03 — Boat and Equipment Maintenance Management | `bpmn-boat-maintenance.html` |

---

## Summary

The three business processes analyzed represent the core operational activities of Daniel Rowing Center. All three processes currently depend on manual procedures, disconnected systems, and personal communication channels.

The proposed My Daniel information system will integrate these processes into a centralized platform, improving operational efficiency, information visibility, reporting capabilities, and overall service quality.
