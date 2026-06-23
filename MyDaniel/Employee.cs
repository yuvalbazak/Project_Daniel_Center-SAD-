using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class Employee
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private string   employee_id;
        private string   full_name;
        private string   role;
        private DateTime start_date;
        private string   phone;
        private string   email;
        private string   password;

        private List<WorkHoursReport> workHoursReports;

        // =====================================================================
        // בנאי
        // is_new = true  → מופע חדש שנוצר ע"י המשתמש → שמור ב-DB
        // is_new = false → מופע שנטען מה-DB → לא שומרים שוב
        // =====================================================================
        public Employee(string employee_id, string full_name, string role,
                        DateTime start_date, string phone, string email,
                        string password, bool is_new)
        {
            this.employee_id = employee_id;
            this.full_name   = full_name;
            this.role        = role;
            this.start_date  = start_date;
            this.phone       = phone;
            this.email       = email;
            this.password    = password;

            if (is_new)
            {
                this.createEmployee();
                Program.Employees.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public string   getEmployeeId()  { return this.employee_id; }
        public string   getFullName()    { return this.full_name; }
        public string   getRole()        { return this.role; }
        public DateTime getStartDate()   { return this.start_date; }
        public string   getPhone()       { return this.phone; }
        public string   getEmail()       { return this.email; }
        public string   getPassword()    { return this.password; }

        public void setFullName(string v)    { this.full_name = v; }
        public void setRole(string v)        { this.role = v; }
        public void setStartDate(DateTime v) { this.start_date = v; }
        public void setPhone(string v)       { this.phone = v; }
        public void setEmail(string v)       { this.email = v; }
        public void setPassword(string v)    { this.password = v; }

        // =====================================================================
        // ניהול דוחות שעות עבודה (קשר One-to-Many)
        // =====================================================================
        public List<WorkHoursReport> getWorkHoursReports()
        {
            if (workHoursReports == null) workHoursReports = new List<WorkHoursReport>();
            return workHoursReports;
        }

        public void addWorkHoursReport(WorkHoursReport report)
        {
            if (report == null) return;
            if (workHoursReports == null) workHoursReports = new List<WorkHoursReport>();
            if (!workHoursReports.Contains(report))
            {
                workHoursReports.Add(report);
                report.setEmployee(this);
            }
        }

        public void removeWorkHoursReport(WorkHoursReport report)
        {
            if (report == null) return;
            if (workHoursReports != null && workHoursReports.Contains(report))
                workHoursReports.Remove(report);
        }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createEmployee()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_employees_create @employee_id, @full_name, @role, @start_date, @phone, @email";
            cmd.Parameters.AddWithValue("@employee_id", this.employee_id);
            cmd.Parameters.AddWithValue("@full_name",   this.full_name);
            cmd.Parameters.AddWithValue("@role",        this.role);
            cmd.Parameters.AddWithValue("@start_date",  this.start_date);
            cmd.Parameters.AddWithValue("@phone",       this.phone);
            cmd.Parameters.AddWithValue("@email",       this.email);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateEmployee()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_employees_update @employee_id, @full_name, @role, @start_date, @phone, @email";
            cmd.Parameters.AddWithValue("@employee_id", this.employee_id);
            cmd.Parameters.AddWithValue("@full_name",   this.full_name);
            cmd.Parameters.AddWithValue("@role",        this.role);
            cmd.Parameters.AddWithValue("@start_date",  this.start_date);
            cmd.Parameters.AddWithValue("@phone",       this.phone);
            cmd.Parameters.AddWithValue("@email",       this.email);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteEmployee()
        {
            Program.Employees.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_employees_delete @employee_id";
            cmd.Parameters.AddWithValue("@employee_id", this.employee_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // get_all returns: 0=employee_id 1=full_name 2=role 3=start_date 4=phone 5=email 6=password
        // =====================================================================
        public static void initEmployees()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_employees_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.Employees = new List<Employee>();

            while (rdr.Read())
            {
                string   id         = rdr.GetValue(0).ToString();
                string   name       = rdr.GetValue(1).ToString();
                string   role       = rdr.GetValue(2).ToString();
                DateTime start_date = DateTime.Parse(rdr.GetValue(3).ToString());
                string   phone      = rdr.GetValue(4).ToString();
                string   email      = rdr.GetValue(5).ToString();
                // Column 6 = password. Falls back to generated value if DB not yet migrated.
                string   password   = rdr.FieldCount > 6 ? rdr.GetValue(6).ToString()
                                                          : Program.generatePassword(email, id);

                Employee e = new Employee(id, name, role, start_date, phone, email, password, false);
                Program.Employees.Add(e);
            }
        }

        public static Employee seekEmployee(string id)
        {
            foreach (Employee e in Program.Employees)
                if (e.getEmployeeId() == id) return e;
            return null;
        }

        public static Employee seekByEmail(string email)
        {
            foreach (Employee e in Program.Employees)
                if (e.getEmail().Equals(email, StringComparison.OrdinalIgnoreCase)) return e;
            return null;
        }
    }
}
