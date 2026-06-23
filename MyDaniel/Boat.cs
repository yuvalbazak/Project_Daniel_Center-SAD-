using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class Boat
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int boatNumber_id;
        private string boat_type;
        private string water_craft_name;
        private string boat_status;
        private DateTime purchase_date;
        private DateTime license_date;
        private DateTime annual_maintenance_date;
        private string source_type;

        private List<Maintenance> maintenances;

        // =====================================================================
        // בנאי
        // =====================================================================
        public Boat(int boatNumber_id, string boat_type, string water_craft_name, string boat_status,
                    DateTime purchase_date, DateTime license_date, DateTime annual_maintenance_date,
                    string source_type, bool is_new)
        {
            this.boatNumber_id           = boatNumber_id;
            this.boat_type               = boat_type;
            this.water_craft_name        = water_craft_name;
            this.boat_status             = boat_status;
            this.purchase_date           = purchase_date;
            this.license_date            = license_date;
            this.annual_maintenance_date = annual_maintenance_date;
            this.source_type             = source_type;

            if (is_new)
            {
                this.createBoat();
                Program.Boats.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int getBoatNumberId()               { return this.boatNumber_id; }
        public string getBoatType()                { return this.boat_type; }
        public string getWaterCraftName()          { return this.water_craft_name; }
        public string getBoatStatus()              { return this.boat_status; }
        public DateTime getPurchaseDate()          { return this.purchase_date; }
        public DateTime getLicenseDate()           { return this.license_date; }
        public DateTime getAnnualMaintenanceDate() { return this.annual_maintenance_date; }
        public string getSourceType()              { return this.source_type; }

        public void setBoatType(string boat_type)                              { this.boat_type = boat_type; }
        public void setWaterCraftName(string water_craft_name)                 { this.water_craft_name = water_craft_name; }
        public void setBoatStatus(string boat_status)                          { this.boat_status = boat_status; }
        public void setPurchaseDate(DateTime purchase_date)                    { this.purchase_date = purchase_date; }
        public void setLicenseDate(DateTime license_date)                      { this.license_date = license_date; }
        public void setAnnualMaintenanceDate(DateTime annual_maintenance_date) { this.annual_maintenance_date = annual_maintenance_date; }
        public void setSourceType(string source_type)                          { this.source_type = source_type; }

        // =====================================================================
        // ניהול תחזוקות הסירה (קשר One-to-Many)
        // =====================================================================
        public List<Maintenance> getMaintenances()
        {
            if (maintenances == null)
                maintenances = new List<Maintenance>();
            return maintenances;
        }

        public void addMaintenance(Maintenance maintenance)
        {
            if (maintenance == null) return;
            if (maintenances == null) maintenances = new List<Maintenance>();
            if (!maintenances.Contains(maintenance))
            {
                maintenances.Add(maintenance);
                maintenance.setBoat(this);
            }
        }

        public void removeMaintenance(Maintenance maintenance)
        {
            if (maintenance == null) return;
            if (maintenances != null && maintenances.Contains(maintenance))
                maintenances.Remove(maintenance);
        }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createBoat()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_create @boatNumber_id, @boat_type, @water_craft_name, @boat_status, @purchase_date, @license_date, @annual_maintenance_date, @source_type";
            cmd.Parameters.AddWithValue("@boatNumber_id",           this.boatNumber_id);
            cmd.Parameters.AddWithValue("@boat_type",               this.boat_type);
            cmd.Parameters.AddWithValue("@water_craft_name",        this.water_craft_name);
            cmd.Parameters.AddWithValue("@boat_status",             this.boat_status);
            cmd.Parameters.AddWithValue("@purchase_date",           this.purchase_date);
            cmd.Parameters.AddWithValue("@license_date",            this.license_date);
            cmd.Parameters.AddWithValue("@annual_maintenance_date", this.annual_maintenance_date);
            cmd.Parameters.AddWithValue("@source_type",             this.source_type);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateBoat()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_update @boatNumber_id, @boat_type, @water_craft_name, @boat_status, @purchase_date, @license_date, @annual_maintenance_date, @source_type";
            cmd.Parameters.AddWithValue("@boatNumber_id",           this.boatNumber_id);
            cmd.Parameters.AddWithValue("@boat_type",               this.boat_type);
            cmd.Parameters.AddWithValue("@water_craft_name",        this.water_craft_name);
            cmd.Parameters.AddWithValue("@boat_status",             this.boat_status);
            cmd.Parameters.AddWithValue("@purchase_date",           this.purchase_date);
            cmd.Parameters.AddWithValue("@license_date",            this.license_date);
            cmd.Parameters.AddWithValue("@annual_maintenance_date", this.annual_maintenance_date);
            cmd.Parameters.AddWithValue("@source_type",             this.source_type);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteBoat()
        {
            Program.Boats.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_delete @boatNumber_id";
            cmd.Parameters.AddWithValue("@boatNumber_id", this.boatNumber_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // =====================================================================
        public static void initBoats()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.Boats = new List<Boat>();

            while (rdr.Read())
            {
                int      boatNumber_id           = int.Parse(rdr.GetValue(0).ToString());
                string   boat_type               = rdr.GetValue(1).ToString();
                string   water_craft_name        = rdr.GetValue(2).ToString();
                string   boat_status             = rdr.GetValue(3).ToString();
                DateTime purchase_date           = DateTime.Parse(rdr.GetValue(4).ToString());
                DateTime license_date            = DateTime.Parse(rdr.GetValue(5).ToString());
                DateTime annual_maintenance_date = DateTime.Parse(rdr.GetValue(6).ToString());
                string   source_type             = rdr.GetValue(7).ToString();

                Boat b = new Boat(boatNumber_id, boat_type, water_craft_name, boat_status,
                                  purchase_date, license_date, annual_maintenance_date, source_type, false);
                Program.Boats.Add(b);
            }
        }

        public static Boat seekBoat(int id)
        {
            foreach (Boat b in Program.Boats)
            {
                if (b.getBoatNumberId() == id)
                    return b;
            }
            return null;
        }

        // =====================================================================
        // State Machine Transitions
        //
        // States (boat_status):
        //   "Active"            — Boat available for use
        //   "Under Maintenance" — Boat under maintenance
        //   "Out of Service"    — Boat permanently out of service
        // =====================================================================

        // Active → Active (no status change; validates boat is available before assignment)
        public void assignToActivity()
        {
            if (this.boat_status != "Active")
                throw new InvalidOperationException("הסירה אינה זמינה להשמה — הסטטוס הנוכחי: " + this.boat_status);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_assignToActivity @boatNumber_id";
            cmd.Parameters.AddWithValue("@boatNumber_id", this.boatNumber_id);
            new SQL_CON().execute_non_query(cmd);
        }

        // Active → Active (return from activity; boat remains Active)
        public void returnFromActivity()
        {
            if (this.boat_status != "Active")
                throw new InvalidOperationException("הסירה אינה פעילה — לא ניתן להחזיר אותה");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_returnFromActivity @boatNumber_id";
            cmd.Parameters.AddWithValue("@boatNumber_id", this.boatNumber_id);
            new SQL_CON().execute_non_query(cmd);
        }

        // Active → Under Maintenance  (opens a new maintenance record)
        public Maintenance reportFault(string description, string technicianName)
        {
            if (this.boat_status != "Active")
                throw new InvalidOperationException("לא ניתן לדווח על תקלה — הסטטוס הנוכחי: " + this.boat_status);

            int newId = 1;
            foreach (Maintenance m in Program.Maintenances)
                if (m.getMaintenanceId() >= newId)
                    newId = m.getMaintenanceId() + 1;

            DateTime reportedAt = DateTime.Today;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_reportFault @boatNumber_id, @maintenance_id, @description, @technician_name, @reported_at";
            cmd.Parameters.AddWithValue("@boatNumber_id",   this.boatNumber_id);
            cmd.Parameters.AddWithValue("@maintenance_id",  newId);
            cmd.Parameters.AddWithValue("@description",     description);
            cmd.Parameters.AddWithValue("@technician_name", technicianName);
            cmd.Parameters.AddWithValue("@reported_at",     reportedAt);
            new SQL_CON().execute_non_query(cmd);

            this.boat_status = "Under Maintenance";

            Maintenance newMaintenance = new Maintenance(
                newId, this.boatNumber_id, reportedAt, description,
                "פתוח", null, null, technicianName, false);
            Program.Maintenances.Add(newMaintenance);
            this.addMaintenance(newMaintenance);

            return newMaintenance;
        }

        // Under Maintenance → Active  (closes open maintenance records)
        public void completeMaintenance(DateTime resolvedAt, decimal? cost)
        {
            if (this.boat_status != "Under Maintenance")
                throw new InvalidOperationException("הסירה אינה בתחזוקה — לא ניתן לסגור את הטיפול");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_completeMaintenance @boatNumber_id, @resolved_at, @cost";
            cmd.Parameters.AddWithValue("@boatNumber_id", this.boatNumber_id);
            cmd.Parameters.AddWithValue("@resolved_at",   resolvedAt.Date);
            cmd.Parameters.AddWithValue("@cost",          (object)cost ?? DBNull.Value);
            new SQL_CON().execute_non_query(cmd);

            this.boat_status = "Active";

            foreach (Maintenance m in Program.Maintenances)
            {
                if (m.getBoatNumberId() == this.boatNumber_id &&
                    (m.getStatus() == "פתוח" || m.getStatus() == "בטיפול"))
                {
                    m.setStatus("סגור");
                    m.setResolvedAt(resolvedAt.Date);
                    m.setCost(cost);
                }
            }
        }

        // Under Maintenance → Out of Service  (repair failed — closes open maintenance records)
        public void failRepair()
        {
            if (this.boat_status != "Under Maintenance")
                throw new InvalidOperationException("הסירה אינה בתחזוקה — לא ניתן לסמן כשל תיקון");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_failRepair @boatNumber_id";
            cmd.Parameters.AddWithValue("@boatNumber_id", this.boatNumber_id);
            new SQL_CON().execute_non_query(cmd);

            this.boat_status = "Out of Service";

            DateTime today = DateTime.Today;
            foreach (Maintenance m in Program.Maintenances)
            {
                if (m.getBoatNumberId() == this.boatNumber_id &&
                    (m.getStatus() == "פתוח" || m.getStatus() == "בטיפול"))
                {
                    m.setStatus("סגור");
                    m.setResolvedAt(today);
                }
            }
        }

        // Out of Service → Out of Service (terminal disposal)
        public void dispose()
        {
            if (this.boat_status != "Out of Service")
                throw new InvalidOperationException("הסירה אינה מושבתת — לא ניתן להעבירה להשבתה סופית");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_boats_dispose @boatNumber_id";
            cmd.Parameters.AddWithValue("@boatNumber_id", this.boatNumber_id);
            new SQL_CON().execute_non_query(cmd);
        }
    }
}
