using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class Maintenance
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int maintenance_id;
        private int boatNumber_id;
        private DateTime reported_at;
        private string description;
        private string status;
        private DateTime? resolved_at;  // nullable
        private decimal? cost;          // nullable
        private string technician_name;

        private Boat boat;

        // =====================================================================
        // בנאי
        // =====================================================================
        public Maintenance(int maintenance_id, int boatNumber_id, DateTime reported_at, string description,
                           string status, DateTime? resolved_at, decimal? cost, string technician_name, bool is_new)
        {
            this.maintenance_id  = maintenance_id;
            this.boatNumber_id   = boatNumber_id;
            this.reported_at     = reported_at;
            this.description     = description;
            this.status          = status;
            this.resolved_at     = resolved_at;
            this.cost            = cost;
            this.technician_name = technician_name;

            if (is_new)
            {
                this.createMaintenance();
                Program.Maintenances.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int getMaintenanceId()      { return this.maintenance_id; }
        public int getBoatNumberId()       { return this.boatNumber_id; }
        public DateTime getReportedAt()    { return this.reported_at; }
        public string getDescription()     { return this.description; }
        public string getStatus()          { return this.status; }
        public DateTime? getResolvedAt()   { return this.resolved_at; }
        public decimal? getCost()          { return this.cost; }
        public string getTechnicianName()  { return this.technician_name; }
        public Boat getBoat()              { return this.boat; }

        public void setReportedAt(DateTime reported_at)       { this.reported_at = reported_at; }
        public void setDescription(string description)        { this.description = description; }
        public void setStatus(string status)                  { this.status = status; }
        public void setResolvedAt(DateTime? resolved_at)      { this.resolved_at = resolved_at; }
        public void setCost(decimal? cost)                    { this.cost = cost; }
        public void setTechnicianName(string technician_name) { this.technician_name = technician_name; }
        public void setBoat(Boat boat)                        { this.boat = boat; }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createMaintenance()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_maintenances_create @maintenance_id, @boatNumber_id, @reported_at, @description, @status, @resolved_at, @cost, @technician_name";
            cmd.Parameters.AddWithValue("@maintenance_id",  this.maintenance_id);
            cmd.Parameters.AddWithValue("@boatNumber_id",   this.boatNumber_id);
            cmd.Parameters.AddWithValue("@reported_at",     this.reported_at);
            cmd.Parameters.AddWithValue("@description",     this.description);
            cmd.Parameters.AddWithValue("@status",          this.status);
            cmd.Parameters.AddWithValue("@resolved_at",     (object)this.resolved_at ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@cost",            (object)this.cost ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@technician_name", this.technician_name);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateMaintenance()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_maintenances_update @maintenance_id, @boatNumber_id, @reported_at, @description, @status, @resolved_at, @cost, @technician_name";
            cmd.Parameters.AddWithValue("@maintenance_id",  this.maintenance_id);
            cmd.Parameters.AddWithValue("@boatNumber_id",   this.boatNumber_id);
            cmd.Parameters.AddWithValue("@reported_at",     this.reported_at);
            cmd.Parameters.AddWithValue("@description",     this.description);
            cmd.Parameters.AddWithValue("@status",          this.status);
            cmd.Parameters.AddWithValue("@resolved_at",     (object)this.resolved_at ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@cost",            (object)this.cost ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@technician_name", this.technician_name);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteMaintenance()
        {
            Program.Maintenances.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_maintenances_delete @maintenance_id";
            cmd.Parameters.AddWithValue("@maintenance_id", this.maintenance_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // =====================================================================
        public static void initMaintenances()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_maintenances_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.Maintenances = new List<Maintenance>();

            while (rdr.Read())
            {
                int       maintenance_id  = int.Parse(rdr.GetValue(0).ToString());
                int       boatNumber_id   = int.Parse(rdr.GetValue(1).ToString());
                DateTime  reported_at     = DateTime.Parse(rdr.GetValue(2).ToString());
                string    description     = rdr.GetValue(3).ToString();
                string    status          = rdr.GetValue(4).ToString();
                DateTime? resolved_at     = rdr.IsDBNull(5) ? (DateTime?)null : DateTime.Parse(rdr.GetValue(5).ToString());
                decimal?  cost            = rdr.IsDBNull(6) ? (decimal?)null : decimal.Parse(rdr.GetValue(6).ToString());
                string    technician_name = rdr.GetValue(7).ToString();

                Maintenance m = new Maintenance(maintenance_id, boatNumber_id, reported_at, description,
                                                status, resolved_at, cost, technician_name, false);
                Program.Maintenances.Add(m);

                Boat b = Boat.seekBoat(boatNumber_id);
                if (b != null) b.addMaintenance(m);
            }
        }

        public static Maintenance seekMaintenance(int id)
        {
            foreach (Maintenance m in Program.Maintenances)
            {
                if (m.getMaintenanceId() == id)
                    return m;
            }
            return null;
        }
    }
}
