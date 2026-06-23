using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MyDaniel
{
    public class Customer
    {
        // =====================================================================
        // שדות
        // =====================================================================
        private string   customer_id;
        private string   full_name;
        private string   phone;
        private string   email;
        private string   address;
        private DateTime birth_date;
        private DateTime start_date;
        private string   emergency_contact;
        private DateTime payment_date;
        private string   customer_status;
        private string   payment_status;
        private string   password;

        private List<DiscountRequest>          discountRequests;
        private List<StudentsAttendanceReport> attendanceReports;

        // =====================================================================
        // בנאי
        // =====================================================================
        public Customer(string customer_id, string full_name, string phone, string email,
                        string address, DateTime birth_date, DateTime start_date,
                        string emergency_contact, DateTime payment_date,
                        string customer_status, string payment_status,
                        string password, bool is_new)
        {
            this.customer_id       = customer_id;
            this.full_name         = full_name;
            this.phone             = phone;
            this.email             = email;
            this.address           = address;
            this.birth_date        = birth_date;
            this.start_date        = start_date;
            this.emergency_contact = emergency_contact;
            this.payment_date      = payment_date;
            this.customer_status   = customer_status;
            this.payment_status    = payment_status;
            this.password          = password;

            if (is_new)
            {
                this.createCustomer();
                Program.Customers.Add(this);
            }
        }

        // =====================================================================
        // Getters & Setters
        // =====================================================================
        public string   getCustomerId()       { return this.customer_id; }
        public string   getFullName()         { return this.full_name; }
        public string   getPhone()            { return this.phone; }
        public string   getEmail()            { return this.email; }
        public string   getAddress()          { return this.address; }
        public DateTime getBirthDate()        { return this.birth_date; }
        public DateTime getStartDate()        { return this.start_date; }
        public string   getEmergencyContact() { return this.emergency_contact; }
        public DateTime getPaymentDate()      { return this.payment_date; }
        public string   getCustomerStatus()   { return this.customer_status; }
        public string   getPaymentStatus()    { return this.payment_status; }
        public string   getPassword()         { return this.password; }

        public void setFullName(string v)                 { this.full_name = v; }
        public void setPhone(string v)                    { this.phone = v; }
        public void setEmail(string v)                    { this.email = v; }
        public void setAddress(string v)                  { this.address = v; }
        public void setBirthDate(DateTime v)              { this.birth_date = v; }
        public void setStartDate(DateTime v)              { this.start_date = v; }
        public void setEmergencyContact(string v)         { this.emergency_contact = v; }
        public void setPaymentDate(DateTime v)            { this.payment_date = v; }
        public void setCustomerStatus(string v)           { this.customer_status = v; }
        public void setPaymentStatus(string v)            { this.payment_status = v; }
        public void setPassword(string v)                 { this.password = v; }

        // =====================================================================
        // ניהול בקשות הנחה (קשר One-to-Many)
        // =====================================================================
        public List<DiscountRequest> getDiscountRequests()
        {
            if (discountRequests == null) discountRequests = new List<DiscountRequest>();
            return discountRequests;
        }

        public void addDiscountRequest(DiscountRequest request)
        {
            if (request == null) return;
            if (discountRequests == null) discountRequests = new List<DiscountRequest>();
            if (!discountRequests.Contains(request))
            {
                discountRequests.Add(request);
                request.setCustomer(this);
            }
        }

        public void removeDiscountRequest(DiscountRequest request)
        {
            if (request == null) return;
            if (discountRequests != null && discountRequests.Contains(request))
                discountRequests.Remove(request);
        }

        // =====================================================================
        // ניהול דוחות נוכחות (קשר One-to-Many)
        // =====================================================================
        public List<StudentsAttendanceReport> getAttendanceReports()
        {
            if (attendanceReports == null) attendanceReports = new List<StudentsAttendanceReport>();
            return attendanceReports;
        }

        public void addAttendanceReport(StudentsAttendanceReport report)
        {
            if (report == null) return;
            if (attendanceReports == null) attendanceReports = new List<StudentsAttendanceReport>();
            if (!attendanceReports.Contains(report))
            {
                attendanceReports.Add(report);
                report.setCustomer(this);
            }
        }

        public void removeAttendanceReport(StudentsAttendanceReport report)
        {
            if (report == null) return;
            if (attendanceReports != null && attendanceReports.Contains(report))
                attendanceReports.Remove(report);
        }

        // =====================================================================
        // פעולות מול בסיס הנתונים (CRUD)
        // =====================================================================
        public void createCustomer()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_create @customer_id, @full_name, @phone, @email, @address, @birth_date, @start_date, @emergency_contact, @payment_date, @customer_status, @payment_status";
            cmd.Parameters.AddWithValue("@customer_id",       this.customer_id);
            cmd.Parameters.AddWithValue("@full_name",         this.full_name);
            cmd.Parameters.AddWithValue("@phone",             this.phone);
            cmd.Parameters.AddWithValue("@email",             this.email);
            cmd.Parameters.AddWithValue("@address",           this.address);
            cmd.Parameters.AddWithValue("@birth_date",        this.birth_date);
            cmd.Parameters.AddWithValue("@start_date",        this.start_date);
            cmd.Parameters.AddWithValue("@emergency_contact", this.emergency_contact);
            cmd.Parameters.AddWithValue("@payment_date",      this.payment_date);
            cmd.Parameters.AddWithValue("@customer_status",   this.customer_status);
            cmd.Parameters.AddWithValue("@payment_status",    this.payment_status);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void updateCustomer()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_update @customer_id, @full_name, @phone, @email, @address, @birth_date, @start_date, @emergency_contact, @payment_date, @customer_status, @payment_status";
            cmd.Parameters.AddWithValue("@customer_id",       this.customer_id);
            cmd.Parameters.AddWithValue("@full_name",         this.full_name);
            cmd.Parameters.AddWithValue("@phone",             this.phone);
            cmd.Parameters.AddWithValue("@email",             this.email);
            cmd.Parameters.AddWithValue("@address",           this.address);
            cmd.Parameters.AddWithValue("@birth_date",        this.birth_date);
            cmd.Parameters.AddWithValue("@start_date",        this.start_date);
            cmd.Parameters.AddWithValue("@emergency_contact", this.emergency_contact);
            cmd.Parameters.AddWithValue("@payment_date",      this.payment_date);
            cmd.Parameters.AddWithValue("@customer_status",   this.customer_status);
            cmd.Parameters.AddWithValue("@payment_status",    this.payment_status);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        public void deleteCustomer()
        {
            Program.Customers.Remove(this);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_delete @customer_id";
            cmd.Parameters.AddWithValue("@customer_id", this.customer_id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(cmd);
        }

        // =====================================================================
        // מתודות סטטיות — טעינה וחיפוש
        // get_all returns: 0=customer_id 1=full_name 2=phone 3=email 4=address
        //                  5=birth_date  6=start_date 7=emergency_contact
        //                  8=payment_date 9=customer_status 10=payment_status 11=password
        // =====================================================================
        public static void initCustomers()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_get_all";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(cmd);

            Program.Customers = new List<Customer>();

            while (rdr.Read())
            {
                string   customer_id       = rdr.GetValue(0).ToString();
                string   full_name         = rdr.GetValue(1).ToString();
                string   phone             = rdr.GetValue(2).ToString();
                string   email             = rdr.GetValue(3).ToString();
                string   address           = rdr.GetValue(4).ToString();
                DateTime birth_date        = DateTime.Parse(rdr.GetValue(5).ToString());
                DateTime start_date        = DateTime.Parse(rdr.GetValue(6).ToString());
                string   emergency_contact = rdr.GetValue(7).ToString();
                DateTime payment_date      = DateTime.Parse(rdr.GetValue(8).ToString());
                string   customer_status   = rdr.GetValue(9).ToString();
                string   payment_status    = rdr.GetValue(10).ToString();
                // Column 11 = password. Falls back to generated value if DB not yet migrated.
                string   password          = rdr.FieldCount > 11 ? rdr.GetValue(11).ToString()
                                                                  : Program.generatePassword(email, customer_id);

                Customer c = new Customer(customer_id, full_name, phone, email, address,
                                          birth_date, start_date, emergency_contact,
                                          payment_date, customer_status, payment_status,
                                          password, false);
                Program.Customers.Add(c);
            }
        }

        public static Customer seekCustomer(string id)
        {
            foreach (Customer c in Program.Customers)
                if (c.getCustomerId() == id) return c;
            return null;
        }

        public static Customer seekByEmail(string email)
        {
            foreach (Customer c in Program.Customers)
                if (c.getEmail().Equals(email, StringComparison.OrdinalIgnoreCase)) return c;
            return null;
        }

        // =====================================================================
        // מעברי מצב — State Machine Transitions
        //
        // States (customer_status):
        //   "בהרשמה"        — Under Registration
        //   "ממתין לתשלום"  — Pending Payment
        //   "לא שילם"       — Unpaid Customer
        //   "פעיל"          — Active Customer
        //   "בארכיון"       — Archived Customer
        // =====================================================================

        // בהרשמה → ממתין לתשלום
        public void completeRegistration()
        {
            if (this.customer_status != "בהרשמה")
                throw new InvalidOperationException("הלקוח אינו במצב 'בהרשמה' — לא ניתן לסיים הרשמה");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_completeRegistration @customer_id";
            cmd.Parameters.AddWithValue("@customer_id", this.customer_id);
            new SQL_CON().execute_non_query(cmd);

            this.customer_status = "ממתין לתשלום";
        }

        // ממתין לתשלום → לא שילם
        public void requestPayment()
        {
            if (this.customer_status != "ממתין לתשלום")
                throw new InvalidOperationException("הלקוח אינו במצב 'ממתין לתשלום' — לא ניתן לדרוש תשלום");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_requestPayment @customer_id";
            cmd.Parameters.AddWithValue("@customer_id", this.customer_id);
            new SQL_CON().execute_non_query(cmd);

            this.customer_status = "לא שילם";
        }

        // לא שילם → פעיל
        public void completePayment(DateTime paymentDate)
        {
            if (this.customer_status != "לא שילם")
                throw new InvalidOperationException("הלקוח אינו במצב 'לא שילם' — לא ניתן לרשום תשלום");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_completePayment @customer_id, @payment_date";
            cmd.Parameters.AddWithValue("@customer_id",  this.customer_id);
            cmd.Parameters.AddWithValue("@payment_date", paymentDate.Date);
            new SQL_CON().execute_non_query(cmd);

            this.customer_status = "פעיל";
            this.payment_status  = "שולם";
            this.payment_date    = paymentDate.Date;
        }

        // לא שילם → בארכיון (פג תוקף)
        public void expireRegistration()
        {
            if (this.customer_status != "לא שילם")
                throw new InvalidOperationException("הלקוח אינו במצב 'לא שילם' — לא ניתן לבטל בגין פג תוקף");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_expireRegistration @customer_id";
            cmd.Parameters.AddWithValue("@customer_id", this.customer_id);
            new SQL_CON().execute_non_query(cmd);

            this.customer_status = "בארכיון";
        }

        // פעיל → בארכיון (ביטול חברות)
        public void cancelMembership()
        {
            if (this.customer_status != "פעיל")
                throw new InvalidOperationException("הלקוח אינו פעיל — לא ניתן לבטל חברות");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_cancelMembership @customer_id";
            cmd.Parameters.AddWithValue("@customer_id", this.customer_id);
            new SQL_CON().execute_non_query(cmd);

            this.customer_status = "בארכיון";
        }

        // בארכיון → ממתין לתשלום (הפעלה מחדש)
        public void reactivate()
        {
            if (this.customer_status != "בארכיון")
                throw new InvalidOperationException("הלקוח אינו בארכיון — לא ניתן להפעיל מחדש");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE sp_customers_reactivate @customer_id";
            cmd.Parameters.AddWithValue("@customer_id", this.customer_id);
            new SQL_CON().execute_non_query(cmd);

            this.customer_status = "ממתין לתשלום";
        }
    }
}
