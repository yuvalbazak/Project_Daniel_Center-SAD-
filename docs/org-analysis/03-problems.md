# ניתוח בעיות עסקיות — מרכז דניאל לחתירה / Business Problems Analysis — Daniel Rowing Center

**מסמך:** ניתוח מצב קיים — ניתוח בעיות עסקיות / Current State Analysis — Business Problems Analysis
**מקור / Source:** ראיונות בעלי עניין ותצפיות שטח / Stakeholder Interviews and Field Observations (March–April 2026)
**הוכן על ידי / Prepared by:** צוות הפרויקט / Project Team

---

## עברית / Hebrew

### טבלת בעיות מרכזיות

| מספר | גורם לבעיה | בעיה עסקית | הועלה ע"י | פתרון רצוי |
|------|------------|------------|-----------|------------|
| 1 | ניהול תחזוקה ותקלות בטבלאות אקסל והעברת המידע בווצאפ | חוסר מעקב מסודר אחר תקלות, זמינות ציוד וסירות והיסטורית טיפולים | מנהל המרכז ורכז השיט | מעבר למערכת מידע לניהול ציוד עם רישום אוטומטי ובקרה בזמן אמת |
| 2 | פיזור מידע בין מערכות שונות וקבצי אקסל | חוסר נגישות למידע מלא בזמן אמת, קושי בקבלת החלטות וצורך בהצלבות ידניות | מנהל המרכז | הטמעת מערכת מידע מרכזית המאחדת את כלל הנתונים ומאפשרת גישה מהירה ועדכנית למידע |
| 3 | מחסור בילדים ומדריכים בענף הקיאקים | ניצול נמוך של משאבים והפסד כלכלי | מנהל המרכז | שיפור תהליכי שיווק וגיוס לקוחות |
| 4 | איסוף פרטי הלקוחות מתבצע ידנית באמצעות שיחת טלפון | סיכון לטעויות בהזנת נתונים, חוסר אחידות במידע, ותלות בעובד שמבצע את הרישום | מנהלת החשבונות | פיתוח טופס הרשמה דיגיטלי |
| 5 | דיווח שעות עבודה מתבצע באופן לא עקבי על ידי העובדים, לצד צורך בביצוע סנכרון ותיקון ידני | עומס על הרכז ומנהלת החשבונות, סיכון לטעויות בחישוב השכר | מנהל המרכז, רכז השיט ומנהלת החשבונות | מערכת משולבת המחברת בין נתוני הפעילות בפועל לבין דיווחי השעות, ומבצעת השוואה אוטומטית, זיהוי חריגות ומאפשרת השלמת דיווחים |
| 6 | הסתמכות על דיווחים ידניים של רכזים ושימוש באקסל לצורך ניתוח נתונים | קושי בהפקת תובנות וקבלת החלטות מבוססות נתונים, תלות בעיבוד ידני באקסל | מנהל המרכז ומנהלת החשבונות | הטמעת מערכת BI מרכזית המחוברת לכל מערכות הארגון, המאפשרת איסוף, עיבוד והצגת נתונים בזמן אמת באמצעות דוחות ודשבורדים אוטומטיים |
| 7 | תהליך מתן ההנחות מתבצע באופן ידני | מתן הנחות ללקוחות שאינם זכאים, פגיעה בהכנסות הארגון | מנהלת החשבונות | הטמעת מערכת לניהול הנחות, הכוללת אימות זכאות אוטומטי, העלאת מסמכים בצורה מובנית ובקרה בזמן אמת |
| 8 | היעדר בסיס נתונים מסודר ותיעוד ארגוני של מידע מקצועי ותפעולי | תלות בידע אישי של עובדים, קושי בשימור מידע ואובדן ידע ארגוני | רכז השיט | הקמת מאגר מידע ארגוני מרכזי לתיעוד מידע על חניכים, מדריכים ואירועים חריגים |
| 9 | התקשורת עם ההורים מתבצעת בעיקר דרך טלפונים, שיחות אישיות וקבוצות וואטסאפ | תלות ברכז לצורך העברת מידע, סיכון לכך שהורים לא יקבלו עדכונים חשובים וחוסר אחידות בתקשורת | רכז השיט | הטמעת מערכת תקשורת מרכזית מול הורים הכוללת שליחת עדכונים והתראות באופן אוטומטי ומתועד |
| 10 | מעקב נוכחות מתבצע ידנית באמצעות Google Sheets | קושי במעקב רציף אחר היעדרויות תלמידים, סיכון לטעויות ועדכון לא עקבי בין המדריכים | רכז השיט | הטמעת מערכת נוכחות דיגיטלית עם עדכון בזמן אמת, התראות על היעדרויות חריגות ותיעוד מרכזי |

---

### תיאור המצב הקיים וההשפעה העסקית

מרכז דניאל לחתירה מסתמך כיום על מספר מערכות מידע מנותקות, ביניהן Priority, Synel, Fizikal, Kehila, Coing, גיליונות אקסל, Google Sheets, קבוצות וואטסאפ ושיחות טלפון. תהליכים עסקיים רבים עדיין מחייבים התערבות ידנית, כולל רישום לקוחות, מעקב נוכחות, אימות שכר, ניהול תחזוקה, אישור הנחות ותקשורת עם הורים.

כתוצאה מכך:

- המידע מפוזר בין מערכות שונות.
- עומס אדמיניסטרטיבי גבוה.
- אימות שכר מחייב בדיקה ידנית חודשית.
- קשה לעקוב אחר היסטוריית תחזוקת ציוד.
- תהליך רישום לקוחות איטי ועלול לכלול שגיאות.
- הידע הארגוני תלוי מאוד בעובדים מסוימים.
- ההנהלה חסרה נראות בזמן אמת לפעילות התפעולית.

---

### הפתרון המוצע

הטמעת מערכת **My Daniel**, פלטפורמת מידע מרכזית המשלבת:

- ניהול לקוחות
- ניהול עובדים
- תזמון פעילויות
- מעקב נוכחות
- אימות שכר
- ניהול סירות וציוד
- מעקב תחזוקה
- תקשורת עם הורים
- ניהול הנחות
- דוחות BI

---

## English

# Organizational Problem Statement

## 1. Desired State

Daniel Rowing Center should operate through a centralized information system that manages customers, employees, activities, boats, equipment, maintenance operations, attendance reporting, payroll validation, and communication with parents.

Coordinators should be able to schedule activities, assign instructors and boats, monitor equipment availability, and track attendance in real time. Customers should be able to register digitally, submit required documents online, and receive automatic notifications regarding activities and membership status.

Management should have access to real-time operational and financial information through centralized dashboards and reports, without the need to manually collect data from multiple systems.

---

## 2. Current Situation and Business Impact

Daniel Rowing Center currently relies on several disconnected information systems, including Priority, Synel, Fizikal, Kehila, Coing, Excel spreadsheets, Google Sheets, WhatsApp groups, and phone calls.

Many core business processes still require manual intervention, including customer registration, attendance tracking, payroll validation, maintenance management, discount approvals, and communication with parents.

As a result:

- Information is fragmented across multiple systems.
- Administrative workload is high.
- Payroll validation requires monthly manual review.
- Equipment maintenance history is difficult to track.
- Customer registration is slow and error-prone.
- Organizational knowledge depends heavily on specific employees.
- Management lacks real-time visibility into operational activities.

---

## 3. Operational Symptoms

- Equipment failures are reported through WhatsApp groups.
- Boat maintenance is tracked using Excel spreadsheets.
- Attendance is managed manually through Google Sheets.
- Customer registration is performed through phone calls.
- Discount eligibility is verified manually.
- Payroll reports require monthly manual validation.
- Parent communication depends on coordinators.
- Organizational knowledge is stored in personal files and conversations.

---

## 4. Proposed Solution

Implementation of **My Daniel**, a centralized information system that integrates:

- Customer Management
- Employee Management
- Activity Scheduling
- Attendance Tracking
- Payroll Validation
- Boat and Equipment Management
- Maintenance Tracking
- Parent Communication
- Discount Management
- Business Intelligence (BI) Reporting

The system will provide a single source of truth for all operational and managerial activities within the organization.

---

## 5. Expected Benefits

### Operational Benefits

- Reduced administrative workload
- Faster process execution
- Improved information accuracy
- Better resource utilization
- Standardized workflows

### Managerial Benefits

- Real-time access to organizational data
- Improved decision-making capabilities
- Better visibility into activities and resources
- Centralized reporting and analytics

### Customer Benefits

- Faster registration process
- Improved communication
- Greater transparency
- Better customer experience

---

## 6. Problems Table

| ID | Root Cause | Business Problem | Reported By | Proposed Solution |
|------|------|------|------|------|
| P-01 | Equipment maintenance is managed through Excel files and WhatsApp communication | Lack of structured tracking of equipment failures, boat availability, and maintenance history | Center Manager, Sailing Coordinator | Centralized maintenance and equipment management system |
| P-02 | Information is distributed across multiple systems and spreadsheets | Limited access to complete and up-to-date information, requiring manual cross-checking | Center Manager | Centralized information system |
| P-03 | Low participation and instructor availability in the kayaking program | Underutilization of resources and financial loss | Center Manager | Improved marketing and customer acquisition processes |
| P-04 | Customer information is collected manually through phone calls | Risk of data-entry errors, inconsistent information, and dependency on administrative staff | Accounting Manager | Digital registration platform |
| P-05 | Employee attendance reporting is inconsistent and requires manual corrections | High administrative workload and payroll calculation errors | Center Manager, Sailing Coordinator, Accounting Manager | Automatic attendance and payroll synchronization |
| P-06 | Data analysis relies on Excel spreadsheets and manual reporting | Difficulty generating insights and making data-driven decisions | Center Manager, Accounting Manager | Business Intelligence (BI) platform |
| P-07 | Discount approvals are performed manually | Unauthorized discounts and revenue loss | Accounting Manager | Automated discount validation process |
| P-08 | Lack of structured organizational documentation | Dependency on employee knowledge and risk of knowledge loss | Sailing Coordinator | Centralized organizational knowledge base |
| P-09 | Communication with parents relies on phone calls and WhatsApp groups | Communication inconsistencies and missed updates | Sailing Coordinator | Centralized communication platform |
| P-10 | Attendance tracking is performed manually through Google Sheets | Inconsistent attendance monitoring and reporting errors | Sailing Coordinator | Real-time attendance management system |

---

## 7. Problem Categorization

### Information Management Problems

- P-02: Fragmented Information Systems
- P-08: Lack of Organizational Knowledge Management

**Impact:** Duplicate work, inconsistent data, delayed decision-making, knowledge loss.

---

### Operational Process Problems

- P-04: Manual Customer Registration
- P-05: Payroll Validation Process
- P-10: Manual Attendance Tracking

**Impact:** High administrative workload, increased human errors, slow process execution.

---

### Equipment and Maintenance Problems

- P-01: Equipment Maintenance Tracking

**Impact:** Lack of maintenance visibility, missing maintenance history, reduced equipment utilization.

---

### Customer and Communication Problems

- P-07: Manual Discount Validation
- P-09: Parent Communication Management

**Impact:** Poor customer experience, revenue leakage, communication inefficiencies.

---

## 8. Business Justification

The analysis indicates that the organization's most significant operational challenges stem from manual processes, fragmented information systems, and lack of integration between departments.

The implementation of the My Daniel information system will address these challenges by providing a centralized platform for managing customers, employees, activities, equipment, maintenance operations, payroll processes, and organizational reporting.

This solution will improve operational efficiency, reduce dependency on manual work, increase information accuracy, and support future organizational growth.
