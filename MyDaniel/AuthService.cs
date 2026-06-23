namespace MyDaniel
{
    public static class AuthService
    {
        public const string ROLE_CENTER_MANAGER     = "Center Manager";
        public const string ROLE_ACCOUNTING_MANAGER = "Accounting Manager";
        public const string ROLE_ADMIN_STAFF        = "Administration Staff";
        public const string ROLE_COORDINATOR        = "Coordinator";
        public const string ROLE_INSTRUCTOR         = "Instructor";
        public const string ROLE_CUSTOMER           = "Customer";
        public const string ROLE_ADMIN              = "Administrator";

        private static string Role => Program.currentUserRole;

        // ── Identity helpers ──────────────────────────────────────────────────

        public static bool IsAdmin()
            => Role == ROLE_ADMIN;

        public static bool IsManager()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_ACCOUNTING_MANAGER;

        public static bool IsCustomer()
            => Role == ROLE_CUSTOMER;

        public static bool IsEmployee()
            => Program.currentUserType == "Employee";

        public static bool IsInstructor()
            => Role == ROLE_INSTRUCTOR;

        public static bool IsAdminStaff()
            => Role == ROLE_ADMIN_STAFF;

        // Admin staff + managers can write employees/students in admin portal
        public static bool CanAdminPortalWrite()
            => Role == ROLE_ADMIN_STAFF || IsManager() || IsAdmin();

        // ── Employee permissions ──────────────────────────────────────────────

        // Full CRUD on employees
        public static bool CanWriteEmployees()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_ACCOUNTING_MANAGER || IsAdmin();

        // Can open the employees module (view at any level)
        public static bool CanViewEmployees()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_ACCOUNTING_MANAGER
            || Role == ROLE_COORDINATOR    || Role == ROLE_ADMIN_STAFF || IsAdmin();

        // Coordinator sees only Instructor records; Admin sees all
        public static bool ViewInstructorsOnly()
            => Role == ROLE_COORDINATOR && !IsAdmin();

        // ── Customer permissions ──────────────────────────────────────────────

        // Full CRUD on customer records
        public static bool CanWriteCustomers()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_ACCOUNTING_MANAGER || IsAdmin();

        // Can view the full customer list
        public static bool CanViewAllCustomers()
            => Role != ROLE_CUSTOMER;

        // ── Boat permissions ─────────────────────────────────────────────────

        // Create, edit, delete boats
        public static bool CanWriteBoats()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR || IsAdmin();

        // View full maintenance history for a boat
        public static bool CanViewBoatMaintenance()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_ACCOUNTING_MANAGER
            || Role == ROLE_COORDINATOR    || IsAdmin();

        // Open a new fault/issue report for a boat
        public static bool CanReportBoatFault()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR
            || Role == ROLE_INSTRUCTOR     || IsAdmin();

        // ── External Center permissions ───────────────────────────────────────

        // View external centers (all managers + coordinator + admin)
        public static bool CanViewExternalCenters()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_ACCOUNTING_MANAGER
            || Role == ROLE_COORDINATOR    || IsAdmin();

        // Full CRUD on external centers
        public static bool CanWriteExternalCenters()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR || IsAdmin();

        // ── Maintenance module permissions ────────────────────────────────────

        public static bool CanViewMaintenance()
            => Role != ROLE_CUSTOMER;

        public static bool CanCreateMaintenance()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR
            || Role == ROLE_INSTRUCTOR     || IsAdmin();

        public static bool CanEditMaintenance()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR || IsAdmin();

        public static bool CanCloseMaintenance()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR || IsAdmin();

        public static bool CanDeleteMaintenance()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR || IsAdmin();

        // ── Discount Request permissions ──────────────────────────────────────

        // All staff except Instructor can view discount requests
        public static bool CanViewDiscountRequests()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_ACCOUNTING_MANAGER
            || Role == ROLE_COORDINATOR    || Role == ROLE_ADMIN_STAFF || IsAdmin();

        // Accounting Manager and Admin can approve / reject / set discount %
        public static bool CanManageDiscountRequests()
            => Role == ROLE_ACCOUNTING_MANAGER || IsAdmin();

        // ── Activity permissions ──────────────────────────────────────────────

        // Create, update, cancel, delete activities and assign resources
        public static bool CanWriteActivities()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR || IsAdmin();

        // Manage student roster for an activity
        public static bool CanManageRoster()
            => Role == ROLE_CENTER_MANAGER || Role == ROLE_COORDINATOR || IsAdmin();

        // View activities (all staff + admin)
        public static bool CanViewActivities()
            => Program.currentUserType == "Employee";
    }
}
