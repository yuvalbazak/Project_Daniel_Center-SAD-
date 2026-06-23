using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class WorkHoursReport
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int work_hours_report_num_id;
        private string employee_id;
        private DateTime check_in;
        private DateTime check_out;
        private decimal reported_hours;
        private decimal actual_hours;
        private bool exception;
        private bool is_approved;
        private string approval_note;   // nullable

        private Employee employee;

        // =====================================================================
        // בנאי
        // =====================================================================
        public WorkHoursReport(int work_hours_report_num_id, string employee_id,
                               DateTime check_in, DateTime check_out,
                               decimal reported_hours, decimal actual_hours,
                               bool exception, bool is_approved, string approval_note, bool is_new)
        {
            this.work_hours_report_num_id = work_hours_report_num_id;
            this.employee_id              = employee_id;
            this.check_in                 = check_in;
            this.check_out                = check_out;
            this.reported_hours           = reported_hours;
            this.actual_hours             = actual_hours;
            this.exception                = exception;
            this.is_approved              = is_approved;
            this.approval_note            = approval_note;

            if (is_new)
            {
                this.createWorkHoursReport();
                Program.WorkHoursReports.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int getWorkHoursReportNumId() { return this.work_hours_report_num_id; }
        public string getEmployeeId()        { return this.employee_id; }
        public DateTime getCheckIn()         { return this.check_in; }
        public DateTime getCheckOut()        { return this.check_out; }
        public decimal getReportedHours()    { return this.reported_hours; }
        public decimal getActualHours()      { return this.actual_hours; }
        public bool getException()           { return this.exception; }
        public bool getIsApproved()          { return this.is_approved; }
        public string getApprovalNote()      { return this.approval_note; }
        public Employee getEmployee()        { return this.employee; }

        public void setCheckIn(DateTime check_in)            { this.check_in = check_in; }
        public void setCheckOut(DateTime check_out)          { this.check_out = check_out; }
        public void setReportedHours(decimal reported_hours) { this.reported_hours = reported_hours; }
        public void setActualHours(decimal actual_hours)     { this.actual_hours = actual_hours; }
        public void setException(bool exception)             { this.exception = exception; }
        public void setIsApproved(bool is_approved)          { this.is_approved = is_approved; }
        public void setApprovalNote(string approval_note)    { this.approval_note = approval_note; }
        public void setEmployee(Employee employee)           { this.employee = employee; }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createWorkHoursReport()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_work_hours_reports_create @work_hours_report_num_id, @employee_id, @check_in, @check_out, @reported_hours, @actual_hours, @exception, @is_approved, @approval_note";
            cmd.Parameters.AddWithValue("@work_hours_report_num_id", this.work_hours_report_num_id);
            cmd.Parameters.AddWithValue("@employee_id",              this.employee_id);
            cmd.Parameters.AddWithValue("@check_in",                 this.check_in);
            cmd.Parameters.AddWithValue("@check_out",                this.check_out);
            cmd.Parameters.AddWithValue("@reported_hours",           this.reported_hours);
            cmd.Parameters.AddWithValue("@actual_hours",             this.actual_hours);
            cmd.Parameters.AddWithValue("@exception",                this.exception);
            cmd.Parameters.AddWithValue("@is_approved",              this.is_approved);
            cmd.Parameters.AddWithValue("@approval_note",            (object)this.approval_note ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateWorkHoursReport()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_work_hours_reports_update @work_hours_report_num_id, @employee_id, @check_in, @check_out, @reported_hours, @actual_hours, @exception, @is_approved, @approval_note";
            cmd.Parameters.AddWithValue("@work_hours_report_num_id", this.work_hours_report_num_id);
            cmd.Parameters.AddWithValue("@employee_id",              this.employee_id);
            cmd.Parameters.AddWithValue("@check_in",                 this.check_in);
            cmd.Parameters.AddWithValue("@check_out",                this.check_out);
            cmd.Parameters.AddWithValue("@reported_hours",           this.reported_hours);
            cmd.Parameters.AddWithValue("@actual_hours",             this.actual_hours);
            cmd.Parameters.AddWithValue("@exception",                this.exception);
            cmd.Parameters.AddWithValue("@is_approved",              this.is_approved);
            cmd.Parameters.AddWithValue("@approval_note",            (object)this.approval_note ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteWorkHoursReport()
        {
            Program.WorkHoursReports.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_work_hours_reports_delete @work_hours_report_num_id";
            cmd.Parameters.AddWithValue("@work_hours_report_num_id", this.work_hours_report_num_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // =====================================================================
        public static void initWorkHoursReports()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_work_hours_reports_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.WorkHoursReports = new List<WorkHoursReport>();

            while (rdr.Read())
            {
                int      work_hours_report_num_id = int.Parse(rdr.GetValue(0).ToString());
                string   employee_id              = rdr.GetValue(1).ToString();
                DateTime check_in                 = DateTime.Parse(rdr.GetValue(2).ToString());
                DateTime check_out                = DateTime.Parse(rdr.GetValue(3).ToString());
                decimal  reported_hours           = decimal.Parse(rdr.GetValue(4).ToString());
                decimal  actual_hours             = decimal.Parse(rdr.GetValue(5).ToString());
                bool     exception                = Convert.ToBoolean(rdr.GetValue(6));
                bool     is_approved              = Convert.ToBoolean(rdr.GetValue(7));
                string   approval_note            = rdr.IsDBNull(8) ? null : rdr.GetValue(8).ToString();

                WorkHoursReport r = new WorkHoursReport(work_hours_report_num_id, employee_id,
                                                         check_in, check_out, reported_hours, actual_hours,
                                                         exception, is_approved, approval_note, false);
                Program.WorkHoursReports.Add(r);

                Employee e = Employee.seekEmployee(employee_id);
                if (e != null) e.addWorkHoursReport(r);
            }
        }

        public static WorkHoursReport seekWorkHoursReport(int id)
        {
            foreach (WorkHoursReport r in Program.WorkHoursReports)
            {
                if (r.getWorkHoursReportNumId() == id)
                    return r;
            }
            return null;
        }
    }
}
