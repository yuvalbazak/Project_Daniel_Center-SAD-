using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class DiscountRequest
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private int discount_request_Num_id;
        private string customer_id;
        private string discount_type;
        private string file_path;          // nullable
        private string discount_status;
        private decimal? discount_percent; // nullable
        private DateTime submitted_at;
        private DateTime? resolved_at;    // nullable

        private Customer customer;

        // =====================================================================
        // בנאי
        // =====================================================================
        public DiscountRequest(int discount_request_Num_id, string customer_id, string discount_type,
                               string file_path, string discount_status, decimal? discount_percent,
                               DateTime submitted_at, DateTime? resolved_at, bool is_new)
        {
            this.discount_request_Num_id = discount_request_Num_id;
            this.customer_id             = customer_id;
            this.discount_type           = discount_type;
            this.file_path               = file_path;
            this.discount_status         = discount_status;
            this.discount_percent        = discount_percent;
            this.submitted_at            = submitted_at;
            this.resolved_at             = resolved_at;

            if (is_new)
            {
                this.createDiscountRequest();
                Program.DiscountRequests.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public int getDiscountRequestNumId()    { return this.discount_request_Num_id; }
        public string getCustomerId()           { return this.customer_id; }
        public string getDiscountType()         { return this.discount_type; }
        public string getFilePath()             { return this.file_path; }
        public string getDiscountStatus()       { return this.discount_status; }
        public decimal? getDiscountPercent()    { return this.discount_percent; }
        public DateTime getSubmittedAt()        { return this.submitted_at; }
        public DateTime? getResolvedAt()        { return this.resolved_at; }
        public Customer getCustomer()           { return this.customer; }

        public void setDiscountType(string discount_type)        { this.discount_type = discount_type; }
        public void setFilePath(string file_path)                { this.file_path = file_path; }
        public void setDiscountStatus(string discount_status)    { this.discount_status = discount_status; }
        public void setDiscountPercent(decimal? discount_percent){ this.discount_percent = discount_percent; }
        public void setSubmittedAt(DateTime submitted_at)        { this.submitted_at = submitted_at; }
        public void setResolvedAt(DateTime? resolved_at)         { this.resolved_at = resolved_at; }
        public void setCustomer(Customer customer)               { this.customer = customer; }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createDiscountRequest()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_discount_requests_create @discount_request_Num_id, @customer_id, @discount_type, @file_path, @discount_status, @discount_percent, @submitted_at, @resolved_at";
            cmd.Parameters.AddWithValue("@discount_request_Num_id", this.discount_request_Num_id);
            cmd.Parameters.AddWithValue("@customer_id",             this.customer_id);
            cmd.Parameters.AddWithValue("@discount_type",           this.discount_type);
            cmd.Parameters.AddWithValue("@file_path",               (object)this.file_path ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@discount_status",         this.discount_status);
            cmd.Parameters.AddWithValue("@discount_percent",        (object)this.discount_percent ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@submitted_at",            this.submitted_at);
            cmd.Parameters.AddWithValue("@resolved_at",             (object)this.resolved_at ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateDiscountRequest()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_discount_requests_update @discount_request_Num_id, @customer_id, @discount_type, @file_path, @discount_status, @discount_percent, @submitted_at, @resolved_at";
            cmd.Parameters.AddWithValue("@discount_request_Num_id", this.discount_request_Num_id);
            cmd.Parameters.AddWithValue("@customer_id",             this.customer_id);
            cmd.Parameters.AddWithValue("@discount_type",           this.discount_type);
            cmd.Parameters.AddWithValue("@file_path",               (object)this.file_path ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@discount_status",         this.discount_status);
            cmd.Parameters.AddWithValue("@discount_percent",        (object)this.discount_percent ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@submitted_at",            this.submitted_at);
            cmd.Parameters.AddWithValue("@resolved_at",             (object)this.resolved_at ?? DBNull.Value);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteDiscountRequest()
        {
            Program.DiscountRequests.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_discount_requests_delete @discount_request_Num_id";
            cmd.Parameters.AddWithValue("@discount_request_Num_id", this.discount_request_Num_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // =====================================================================
        public static void initDiscountRequests()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_discount_requests_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.DiscountRequests = new List<DiscountRequest>();

            while (rdr.Read())
            {
                int       discount_request_Num_id = int.Parse(rdr.GetValue(0).ToString());
                string    customer_id             = rdr.GetValue(1).ToString();
                string    discount_type           = rdr.GetValue(2).ToString();
                string    file_path               = rdr.IsDBNull(3) ? null : rdr.GetValue(3).ToString();
                string    discount_status         = rdr.GetValue(4).ToString();
                decimal?  discount_percent        = rdr.IsDBNull(5) ? (decimal?)null : decimal.Parse(rdr.GetValue(5).ToString());
                DateTime  submitted_at            = DateTime.Parse(rdr.GetValue(6).ToString());
                DateTime? resolved_at             = rdr.IsDBNull(7) ? (DateTime?)null : DateTime.Parse(rdr.GetValue(7).ToString());

                DiscountRequest dr = new DiscountRequest(discount_request_Num_id, customer_id, discount_type,
                                                         file_path, discount_status, discount_percent,
                                                         submitted_at, resolved_at, false);
                Program.DiscountRequests.Add(dr);

                Customer c = Customer.seekCustomer(customer_id);
                if (c != null) c.addDiscountRequest(dr);
            }
        }

        public static DiscountRequest seekDiscountRequest(int id)
        {
            foreach (DiscountRequest dr in Program.DiscountRequests)
            {
                if (dr.getDiscountRequestNumId() == id)
                    return dr;
            }
            return null;
        }
    }
}
