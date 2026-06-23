using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class ExternalCenter
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int external_center_id;
        private string center_name;
        private string contact_name;
        private string phone;

        // =====================================================================
        // בנאי
        // =====================================================================
        public ExternalCenter(int external_center_id, string center_name,
                              string contact_name, string phone, bool is_new)
        {
            this.external_center_id = external_center_id;
            this.center_name        = center_name;
            this.contact_name       = contact_name;
            this.phone              = phone;

            if (is_new)
            {
                this.createExternalCenter();
                Program.ExternalCenters.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int getExternalCenterId()     { return this.external_center_id; }
        public string getCenterName()        { return this.center_name; }
        public string getContactName()       { return this.contact_name; }
        public string getPhone()             { return this.phone; }

        public void setCenterName(string center_name)   { this.center_name = center_name; }
        public void setContactName(string contact_name) { this.contact_name = contact_name; }
        public void setPhone(string phone)               { this.phone = phone; }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createExternalCenter()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_external_centers_create @external_center_id, @center_name, @contact_name, @phone";
            cmd.Parameters.AddWithValue("@external_center_id", this.external_center_id);
            cmd.Parameters.AddWithValue("@center_name",        this.center_name);
            cmd.Parameters.AddWithValue("@contact_name",       this.contact_name);
            cmd.Parameters.AddWithValue("@phone",              this.phone);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateExternalCenter()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_external_centers_update @external_center_id, @center_name, @contact_name, @phone";
            cmd.Parameters.AddWithValue("@external_center_id", this.external_center_id);
            cmd.Parameters.AddWithValue("@center_name",        this.center_name);
            cmd.Parameters.AddWithValue("@contact_name",       this.contact_name);
            cmd.Parameters.AddWithValue("@phone",              this.phone);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteExternalCenter()
        {
            Program.ExternalCenters.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_external_centers_delete @external_center_id";
            cmd.Parameters.AddWithValue("@external_center_id", this.external_center_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // =====================================================================
        public static void initExternalCenters()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_external_centers_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.ExternalCenters = new List<ExternalCenter>();

            while (rdr.Read())
            {
                int    external_center_id = int.Parse(rdr.GetValue(0).ToString());
                string center_name        = rdr.GetValue(1).ToString();
                string contact_name       = rdr.GetValue(2).ToString();
                string phone              = rdr.GetValue(3).ToString();

                ExternalCenter ec = new ExternalCenter(external_center_id, center_name, contact_name, phone, false);
                Program.ExternalCenters.Add(ec);
            }
        }

        public static ExternalCenter seekExternalCenter(int id)
        {
            foreach (ExternalCenter ec in Program.ExternalCenters)
            {
                if (ec.getExternalCenterId() == id)
                    return ec;
            }
            return null;
        }
    }
}
