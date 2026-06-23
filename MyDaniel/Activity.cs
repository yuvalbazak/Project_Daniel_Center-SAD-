using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class Activity
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int      activityNum_id;
        private string   activity_type;
        private DateTime date_time;
        private string   location;
        private string   age_group;
        private string   instructor_id;        // null = לא שויך
        private int?     boat_number_id;       // null = ללא סירה
        private string   activity_status;      // מתוכנן / פעיל / בוטל / הושלם
        private int      max_participants;
        private string   cancellation_reason;  // null אם לא בוטל

        private List<StudentsAttendanceReport> attendanceReports;
        private List<ActivityCustomer>         roster;

        // =====================================================================
        // בנאי
        // =====================================================================
        public Activity(int activityNum_id, string activity_type, DateTime date_time,
                        string location, string age_group,
                        string instructor_id, int? boat_number_id,
                        string activity_status, int max_participants,
                        string cancellation_reason, bool is_new)
        {
            this.activityNum_id      = activityNum_id;
            this.activity_type       = activity_type;
            this.date_time           = date_time;
            this.location            = location;
            this.age_group           = age_group;
            this.instructor_id       = instructor_id;
            this.boat_number_id      = boat_number_id;
            this.activity_status     = string.IsNullOrEmpty(activity_status) ? "מתוכנן" : activity_status;
            this.max_participants    = max_participants > 0 ? max_participants : 10;
            this.cancellation_reason = cancellation_reason;

            if (is_new)
            {
                createActivity();
                Program.Activities.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int      getActivityNumId()       { return activityNum_id; }
        public string   getActivityType()        { return activity_type; }
        public DateTime getDateTime()            { return date_time; }
        public string   getLocation()            { return location; }
        public string   getAgeGroup()            { return age_group; }
        public string   getInstructorId()        { return instructor_id; }
        public int?     getBoatNumberId()        { return boat_number_id; }
        public string   getActivityStatus()      { return activity_status; }
        public int      getMaxParticipants()     { return max_participants; }
        public string   getCancellationReason()  { return cancellation_reason; }

        public void setActivityType(string v)       { activity_type = v; }
        public void setDateTime(DateTime v)         { date_time = v; }
        public void setLocation(string v)           { location = v; }
        public void setAgeGroup(string v)           { age_group = v; }
        public void setInstructorId(string v)       { instructor_id = v; }
        public void setBoatNumberId(int? v)         { boat_number_id = v; }
        public void setActivityStatus(string v)     { activity_status = v; }
        public void setMaxParticipants(int v)       { max_participants = v; }
        public void setCancellationReason(string v) { cancellation_reason = v; }

        public Employee getInstructor()
        {
            if (string.IsNullOrEmpty(instructor_id)) return null;
            foreach (Employee e in Program.Employees)
                if (e.getEmployeeId() == instructor_id) return e;
            return null;
        }

        public Boat getBoat()
        {
            if (boat_number_id == null) return null;
            foreach (Boat b in Program.Boats)
                if (b.getBoatNumberId() == boat_number_id.Value) return b;
            return null;
        }

        // =====================================================================
        // ניהול דוחות נוכחות
        // =====================================================================
        public List<StudentsAttendanceReport> getAttendanceReports()
        {
            if (attendanceReports == null)
                attendanceReports = new List<StudentsAttendanceReport>();
            return attendanceReports;
        }

        public void addAttendanceReport(StudentsAttendanceReport report)
        {
            if (report == null) return;
            if (attendanceReports == null) attendanceReports = new List<StudentsAttendanceReport>();
            if (!attendanceReports.Contains(report))
            {
                attendanceReports.Add(report);
                report.setActivity(this);
            }
        }

        public void removeAttendanceReport(StudentsAttendanceReport report)
        {
            if (report == null) return;
            if (attendanceReports != null && attendanceReports.Contains(report))
                attendanceReports.Remove(report);
        }

        // =====================================================================
        // ניהול רשימת משתתפים
        // =====================================================================
        public List<ActivityCustomer> getRoster()
        {
            if (roster == null) roster = new List<ActivityCustomer>();
            return roster;
        }

        public void addToRoster(ActivityCustomer ac)
        {
            if (ac == null) return;
            if (roster == null) roster = new List<ActivityCustomer>();
            if (!roster.Contains(ac))
            {
                roster.Add(ac);
                ac.setActivity(this);
            }
        }

        public void removeFromRoster(ActivityCustomer ac)
        {
            if (ac == null) return;
            if (roster != null && roster.Contains(ac))
                roster.Remove(ac);
        }

        // =====================================================================
        // CRUD
        // =====================================================================
        public void createActivity()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activities_create @activityNum_id, @activity_type, @date_time, @location, @age_group, @instructor_id, @boat_number_id, @activity_status, @max_participants, @cancellation_reason";
            cmd.Parameters.AddWithValue("@activityNum_id",      activityNum_id);
            cmd.Parameters.AddWithValue("@activity_type",        activity_type);
            cmd.Parameters.AddWithValue("@date_time",            date_time);
            cmd.Parameters.AddWithValue("@location",             location);
            cmd.Parameters.AddWithValue("@age_group",            age_group);
            cmd.Parameters.AddWithValue("@instructor_id",        (object)instructor_id       ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@boat_number_id",       (object)boat_number_id      ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@activity_status",      activity_status);
            cmd.Parameters.AddWithValue("@max_participants",     max_participants);
            cmd.Parameters.AddWithValue("@cancellation_reason",  (object)cancellation_reason ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateActivity()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activities_update @activityNum_id, @activity_type, @date_time, @location, @age_group, @instructor_id, @boat_number_id, @activity_status, @max_participants, @cancellation_reason";
            cmd.Parameters.AddWithValue("@activityNum_id",      activityNum_id);
            cmd.Parameters.AddWithValue("@activity_type",        activity_type);
            cmd.Parameters.AddWithValue("@date_time",            date_time);
            cmd.Parameters.AddWithValue("@location",             location);
            cmd.Parameters.AddWithValue("@age_group",            age_group);
            cmd.Parameters.AddWithValue("@instructor_id",        (object)instructor_id       ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@boat_number_id",       (object)boat_number_id      ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@activity_status",      activity_status);
            cmd.Parameters.AddWithValue("@max_participants",     max_participants);
            cmd.Parameters.AddWithValue("@cancellation_reason",  (object)cancellation_reason ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteActivity()
        {
            Program.Activities.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activities_delete @activityNum_id";
            cmd.Parameters.AddWithValue("@activityNum_id", activityNum_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // init + seek
        // =====================================================================
        public static void initActivities()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activities_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.Activities = new List<Activity>();

            while (rdr.Read())
            {
                int      activityNum_id = int.Parse(rdr.GetValue(0).ToString());
                string   activity_type  = rdr.GetValue(1).ToString();
                DateTime date_time      = DateTime.Parse(rdr.GetValue(2).ToString());
                string   location       = rdr.GetValue(3).ToString();
                string   age_group      = rdr.GetValue(4).ToString();
                // Graceful fallback for new columns not yet in DB schema:
                string   instructor_id       = rdr.FieldCount > 5 && !rdr.IsDBNull(5) ? rdr.GetValue(5).ToString() : null;
                int?     boat_number_id      = rdr.FieldCount > 6 && !rdr.IsDBNull(6) ? (int?)int.Parse(rdr.GetValue(6).ToString()) : null;
                string   activity_status     = rdr.FieldCount > 7 && !rdr.IsDBNull(7) ? rdr.GetValue(7).ToString() : "מתוכנן";
                int      max_participants    = rdr.FieldCount > 8 && !rdr.IsDBNull(8) ? int.Parse(rdr.GetValue(8).ToString()) : 10;
                string   cancellation_reason = rdr.FieldCount > 9 && !rdr.IsDBNull(9) ? rdr.GetValue(9).ToString() : null;

                Activity a = new Activity(activityNum_id, activity_type, date_time, location, age_group,
                                          instructor_id, boat_number_id, activity_status, max_participants,
                                          cancellation_reason, false);
                Program.Activities.Add(a);
            }
        }

        public static Activity seekActivity(int id)
        {
            foreach (Activity a in Program.Activities)
                if (a.getActivityNumId() == id) return a;
            return null;
        }
    }
}
