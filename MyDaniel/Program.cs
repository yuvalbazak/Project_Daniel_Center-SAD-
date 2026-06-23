using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyDaniel
{
    internal static class Program
    {
        // =====================================================================
        // רשימות סטטיות — הזיכרון הפנימי של האפליקציה
        // =====================================================================
        public static List<Employee>                 Employees                 = new List<Employee>();
        public static List<Customer>                 Customers                 = new List<Customer>();
        public static List<Boat>                     Boats                     = new List<Boat>();
        public static List<ExternalCenter>           ExternalCenters           = new List<ExternalCenter>();
        public static List<Activity>                 Activities                = new List<Activity>();
        public static List<DiscountRequest>          DiscountRequests          = new List<DiscountRequest>();
        public static List<Maintenance>              Maintenances              = new List<Maintenance>();
        public static List<WorkHoursReport>          WorkHoursReports          = new List<WorkHoursReport>();
        public static List<StudentsAttendanceReport> StudentsAttendanceReports = new List<StudentsAttendanceReport>();
        public static List<ExceptionalEvent>          ExceptionalEvents          = new List<ExceptionalEvent>();
        public static List<ActivityCustomer>          ActivityCustomers          = new List<ActivityCustomer>();

        // =====================================================================
        // מידע על המשתמש המחובר
        // =====================================================================
        public static string currentUserEmail = "";
        public static string currentUserType  = "";   // "Employee" | "Customer"
        public static string currentUserRole  = "";   // role name or "Customer"

        // =====================================================================
        // יצירת סיסמה מתוך האימייל ומספר הזהות / העובד
        // =====================================================================
        public static string generatePassword(string email, string id)
        {
            string localPart = email.Contains("@") ? email.Split('@')[0] : email;
            return localPart + id;
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            initLists();
            Application.Run(new MainForm());
        }

        // =====================================================================
        // טעינת כל הנתונים מה-DB לזיכרון בסדר תלות ה-FK הנכון
        // =====================================================================
        static void initLists()
        {
            Employee.initEmployees();                               // 1. אין FK
            Customer.initCustomers();                              // 2. אין FK
            Boat.initBoats();                                      // 3. אין FK
            ExternalCenter.initExternalCenters();                  // 4. אין FK
            Activity.initActivities();                             // 5. אין FK
            try { DiscountRequest.initDiscountRequests(); } catch { }  // 6. FK → Customers
            Maintenance.initMaintenances();                        // 7. FK → Boats
            WorkHoursReport.initWorkHoursReports();               // 8. FK → Employees
            StudentsAttendanceReport.initStudentsAttendanceReports(); // 9. FK → Activities, Customers
            try { ExceptionalEvent.initExceptionalEvents(); }  catch { }  // 10. SP may not exist yet
            try { ActivityCustomer.initActivityCustomers(); }  catch { }  // 11. SP may not exist yet
        }
    }
}
