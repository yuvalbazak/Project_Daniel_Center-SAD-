using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class ExceptionalEvent
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int      event_id;
        private int      activityNum_id;
        private DateTime event_date_time;
        private string   customer_id;         // null = not student-related
        private string   event_type;
        private string   description;
        private string   severity;            // null = not specified
        private bool     follow_up_required;

        private Activity activity;
        private Customer customer;

        // =====================================================================
        // בנאי
        // =====================================================================
        public ExceptionalEvent(int event_id, int activityNum_id, DateTime event_date_time,
                                string customer_id, string event_type, string description,
                                string severity, bool follow_up_required, bool is_new)
        {
            this.event_id            = event_id;
            this.activityNum_id      = activityNum_id;
            this.event_date_time     = event_date_time;
            this.customer_id         = customer_id;
            this.event_type          = event_type;
            this.description         = description;
            this.severity            = severity;
            this.follow_up_required  = follow_up_required;

            if (is_new)
            {
                this.createExceptionalEvent();
                Program.ExceptionalEvents.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int      getEventId()           { return this.event_id; }
        public int      getActivityNumId()     { return this.activityNum_id; }
        public DateTime getEventDateTime()     { return this.event_date_time; }
        public string   getCustomerId()        { return this.customer_id; }
        public string   getEventType()         { return this.event_type; }
        public string   getDescription()       { return this.description; }
        public string   getSeverity()          { return this.severity; }
        public bool     getFollowUpRequired()  { return this.follow_up_required; }
        public Activity getActivity()          { return this.activity; }
        public Customer getCustomer()          { return this.customer; }

        public void setEventDateTime(DateTime v)    { this.event_date_time = v; }
        public void setCustomerId(string v)         { this.customer_id = v; }
        public void setEventType(string v)          { this.event_type = v; }
        public void setDescription(string v)        { this.description = v; }
        public void setSeverity(string v)           { this.severity = v; }
        public void setFollowUpRequired(bool v)     { this.follow_up_required = v; }
        public void setActivity(Activity v)         { this.activity = v; }
        public void setCustomer(Customer v)         { this.customer = v; }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createExceptionalEvent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_exceptional_events_create @event_id, @activityNum_id, @event_date_time, @customer_id, @event_type, @description, @severity, @follow_up_required";
            cmd.Parameters.AddWithValue("@event_id",           this.event_id);
            cmd.Parameters.AddWithValue("@activityNum_id",     this.activityNum_id);
            cmd.Parameters.AddWithValue("@event_date_time",    this.event_date_time);
            cmd.Parameters.AddWithValue("@customer_id",        (object)this.customer_id ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@event_type",         this.event_type);
            cmd.Parameters.AddWithValue("@description",        this.description);
            cmd.Parameters.AddWithValue("@severity",           (object)this.severity ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@follow_up_required", this.follow_up_required);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteExceptionalEvent()
        {
            Program.ExceptionalEvents.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_exceptional_events_delete @event_id";
            cmd.Parameters.AddWithValue("@event_id", this.event_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // =====================================================================
        public static void initExceptionalEvents()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_exceptional_events_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query_silent(cmd);

            Program.ExceptionalEvents = new List<ExceptionalEvent>();

            if (rdr == null) return;

            while (rdr.Read())
            {
                int      event_id           = int.Parse(rdr.GetValue(0).ToString());
                int      activityNum_id     = int.Parse(rdr.GetValue(1).ToString());
                DateTime event_date_time    = DateTime.Parse(rdr.GetValue(2).ToString());
                string   customer_id        = rdr.IsDBNull(3) ? null : rdr.GetValue(3).ToString();
                string   event_type         = rdr.GetValue(4).ToString();
                string   description        = rdr.GetValue(5).ToString();
                string   severity           = rdr.IsDBNull(6) ? null : rdr.GetValue(6).ToString();
                bool     follow_up_required = bool.Parse(rdr.GetValue(7).ToString());

                ExceptionalEvent ev = new ExceptionalEvent(
                    event_id, activityNum_id, event_date_time,
                    customer_id, event_type, description, severity, follow_up_required, false);
                Program.ExceptionalEvents.Add(ev);

                Activity a = Activity.seekActivity(activityNum_id);
                if (a != null) ev.setActivity(a);

                if (!string.IsNullOrEmpty(customer_id))
                {
                    Customer c = Customer.seekCustomer(customer_id);
                    if (c != null) ev.setCustomer(c);
                }
            }
        }

        public static ExceptionalEvent seekExceptionalEvent(int id)
        {
            foreach (ExceptionalEvent ev in Program.ExceptionalEvents)
                if (ev.getEventId() == id) return ev;
            return null;
        }
    }
}
