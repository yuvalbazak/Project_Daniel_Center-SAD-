using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class StudentsAttendanceReport
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int attendance_report_id;
        private int activityNum_id;
        private string customer_id;
        private string attendance_status;
        private string notes;   // nullable

        private Activity activity;
        private Customer customer;

        // =====================================================================
        // בנאי
        // =====================================================================
        public StudentsAttendanceReport(int attendance_report_id, int activityNum_id, string customer_id,
                                        string attendance_status, string notes, bool is_new)
        {
            this.attendance_report_id = attendance_report_id;
            this.activityNum_id       = activityNum_id;
            this.customer_id          = customer_id;
            this.attendance_status    = attendance_status;
            this.notes                = notes;

            if (is_new)
            {
                this.createStudentsAttendanceReport();
                Program.StudentsAttendanceReports.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int getAttendanceReportId()   { return this.attendance_report_id; }
        public int getActivityNumId()        { return this.activityNum_id; }
        public string getCustomerId()        { return this.customer_id; }
        public string getAttendanceStatus()  { return this.attendance_status; }
        public string getNotes()             { return this.notes; }
        public Activity getActivity()        { return this.activity; }
        public Customer getCustomer()        { return this.customer; }

        public void setAttendanceStatus(string attendance_status) { this.attendance_status = attendance_status; }
        public void setNotes(string notes)                        { this.notes = notes; }
        public void setActivity(Activity activity)                { this.activity = activity; }
        public void setCustomer(Customer customer)                { this.customer = customer; }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createStudentsAttendanceReport()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_students_attendance_reports_create @attendance_report_id, @activityNum_id, @customer_id, @attendance_status, @notes";
            cmd.Parameters.AddWithValue("@attendance_report_id", this.attendance_report_id);
            cmd.Parameters.AddWithValue("@activityNum_id",       this.activityNum_id);
            cmd.Parameters.AddWithValue("@customer_id",          this.customer_id);
            cmd.Parameters.AddWithValue("@attendance_status",    this.attendance_status);
            cmd.Parameters.AddWithValue("@notes",                (object)this.notes ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateStudentsAttendanceReport()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_students_attendance_reports_update @attendance_report_id, @activityNum_id, @customer_id, @attendance_status, @notes";
            cmd.Parameters.AddWithValue("@attendance_report_id", this.attendance_report_id);
            cmd.Parameters.AddWithValue("@activityNum_id",       this.activityNum_id);
            cmd.Parameters.AddWithValue("@customer_id",          this.customer_id);
            cmd.Parameters.AddWithValue("@attendance_status",    this.attendance_status);
            cmd.Parameters.AddWithValue("@notes",                (object)this.notes ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteStudentsAttendanceReport()
        {
            Program.StudentsAttendanceReports.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_students_attendance_reports_delete @attendance_report_id";
            cmd.Parameters.AddWithValue("@attendance_report_id", this.attendance_report_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // =====================================================================
        public static void initStudentsAttendanceReports()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_students_attendance_reports_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.StudentsAttendanceReports = new List<StudentsAttendanceReport>();

            while (rdr.Read())
            {
                int    attendance_report_id = int.Parse(rdr.GetValue(0).ToString());
                int    activityNum_id       = int.Parse(rdr.GetValue(1).ToString());
                string customer_id          = rdr.GetValue(2).ToString();
                string attendance_status    = rdr.GetValue(3).ToString();
                string notes                = rdr.IsDBNull(4) ? null : rdr.GetValue(4).ToString();

                StudentsAttendanceReport sar = new StudentsAttendanceReport(
                    attendance_report_id, activityNum_id, customer_id, attendance_status, notes, false);
                Program.StudentsAttendanceReports.Add(sar);

                Activity a = Activity.seekActivity(activityNum_id);
                if (a != null) a.addAttendanceReport(sar);

                Customer c = Customer.seekCustomer(customer_id);
                if (c != null) c.addAttendanceReport(sar);
            }
        }

        public static StudentsAttendanceReport seekStudentsAttendanceReport(int id)
        {
            foreach (StudentsAttendanceReport sar in Program.StudentsAttendanceReports)
            {
                if (sar.getAttendanceReportId() == id)
                    return sar;
            }
            return null;
        }

        public static StudentsAttendanceReport seekByActivityAndCustomer(int activityId, string customerId)
        {
            foreach (StudentsAttendanceReport sar in Program.StudentsAttendanceReports)
            {
                if (sar.getActivityNumId() == activityId &&
                    sar.getCustomerId() == customerId)
                    return sar;
            }
            return null;
        }
    }
}
