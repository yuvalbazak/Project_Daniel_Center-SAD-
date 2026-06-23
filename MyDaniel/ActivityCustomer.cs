using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class ActivityCustomer
    {
        private int      activity_customer_id;
        private int      activityNum_id;
        private string   customer_id;
        private DateTime registration_date;
        private string   notes;
        private int?     boat_id;

        private Activity activity;
        private Customer customer;

        public ActivityCustomer(int activity_customer_id, int activityNum_id, string customer_id,
                                DateTime registration_date, string notes, bool is_new,
                                int? boat_id = null)
        {
            this.activity_customer_id = activity_customer_id;
            this.activityNum_id       = activityNum_id;
            this.customer_id          = customer_id;
            this.registration_date    = registration_date;
            this.notes                = notes;
            this.boat_id              = boat_id;

            if (is_new)
            {
                createActivityCustomer();
                Program.ActivityCustomers.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int      getActivityCustomerId() { return activity_customer_id; }
        public int      getActivityNumId()      { return activityNum_id; }
        public string   getCustomerId()         { return customer_id; }
        public DateTime getRegistrationDate()   { return registration_date; }
        public string   getNotes()              { return notes; }
        public int?     getBoatId()             { return boat_id; }
        public Activity getActivity()           { return activity; }
        public Customer getCustomer()           { return customer; }

        public void setNotes(string v)      { notes   = v; }
        public void setBoatId(int? v)       { boat_id = v; }
        public void setActivity(Activity a) { activity = a; }
        public void setCustomer(Customer c) { customer = c; }

        // =====================================================================
        // CRUD
        // =====================================================================
        public void createActivityCustomer()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activity_customers_create @activity_customer_id, @activityNum_id, @customer_id, @registration_date, @notes";
            cmd.Parameters.AddWithValue("@activity_customer_id", activity_customer_id);
            cmd.Parameters.AddWithValue("@activityNum_id",       activityNum_id);
            cmd.Parameters.AddWithValue("@customer_id",          customer_id);
            cmd.Parameters.AddWithValue("@registration_date",    registration_date);
            cmd.Parameters.AddWithValue("@notes",                (object)notes ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateActivityCustomerBoat()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activity_customers_update_boat @activity_customer_id, @boat_id";
            cmd.Parameters.AddWithValue("@activity_customer_id", activity_customer_id);
            cmd.Parameters.AddWithValue("@boat_id",              (object)boat_id ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteActivityCustomer()
        {
            Program.ActivityCustomers.Remove(this);
            if (activity != null) activity.removeFromRoster(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activity_customers_delete @activity_customer_id";
            cmd.Parameters.AddWithValue("@activity_customer_id", activity_customer_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // init + seek
        // =====================================================================
        public static void initActivityCustomers()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_activity_customers_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query_silent(cmd);

            Program.ActivityCustomers = new List<ActivityCustomer>();

            if (rdr == null) return;

            while (rdr.Read())
            {
                int      activity_customer_id = int.Parse(rdr.GetValue(0).ToString());
                int      activityNum_id       = int.Parse(rdr.GetValue(1).ToString());
                string   customer_id          = rdr.GetValue(2).ToString();
                DateTime registration_date    = DateTime.Parse(rdr.GetValue(3).ToString());
                string   notes    = rdr.FieldCount > 4 && !rdr.IsDBNull(4) ? rdr.GetValue(4).ToString() : null;
                int?     boat_id  = rdr.FieldCount > 5 && !rdr.IsDBNull(5)
                                    ? (int?)int.Parse(rdr.GetValue(5).ToString()) : null;

                ActivityCustomer ac = new ActivityCustomer(activity_customer_id, activityNum_id, customer_id,
                                                           registration_date, notes, false, boat_id);
                Program.ActivityCustomers.Add(ac);

                Activity a = Activity.seekActivity(activityNum_id);
                if (a != null) a.addToRoster(ac);

                foreach (Customer c in Program.Customers)
                {
                    if (c.getCustomerId() == customer_id) { ac.setCustomer(c); break; }
                }
            }
        }

        public static ActivityCustomer seekActivityCustomer(int id)
        {
            foreach (ActivityCustomer ac in Program.ActivityCustomers)
                if (ac.getActivityCustomerId() == id) return ac;
            return null;
        }

        public static ActivityCustomer seekByActivityAndCustomer(int activityId, string customerId)
        {
            foreach (ActivityCustomer ac in Program.ActivityCustomers)
                if (ac.getActivityNumId() == activityId && ac.getCustomerId() == customerId) return ac;
            return null;
        }
    }
}
