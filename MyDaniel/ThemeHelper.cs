using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyDaniel
{
    public static class ThemeHelper
    {
        // ── Core backgrounds ──────────────────────────────────────────────────
        public static readonly Color BG_APP     = Hex("#EEF4FF"); // login full-screen bg
        public static readonly Color BG_SIDEBAR = Hex("#1E3A8A"); // deep blue sidebar
        public static readonly Color BG_CONTENT = Hex("#F0F7FF"); // panel surface (very light blue)
        public static readonly Color BG_CARD    = Hex("#FFFFFF"); // card / nested panel
        public static readonly Color BG_INPUT   = Hex("#FFFFFF"); // input controls

        public static readonly Color BORDER       = Hex("#BFDBFE"); // light blue border / separator
        public static readonly Color BORDER_INPUT = Hex("#93C5FD"); // input border

        // ── Sidebar-specific (text on dark blue sidebar) ───────────────────────
        public static readonly Color SIDEBAR_TEXT  = Hex("#E0E7FF"); // bright text on sidebar
        public static readonly Color SIDEBAR_MUTED = Hex("#93C5FD"); // muted text on sidebar
        public static readonly Color SIDEBAR_HOVER = Hex("#2563EB"); // hover bg on sidebar

        // ── Semantic button colors ─────────────────────────────────────────────
        public static readonly Color PRIMARY    = Hex("#2563EB");
        public static readonly Color PRIMARY_HV = Hex("#1D4ED8");
        public static readonly Color SUCCESS    = Hex("#16A34A");
        public static readonly Color SUCCESS_HV = Hex("#0D7A38");
        public static readonly Color WARNING    = Hex("#D97706");
        public static readonly Color WARNING_HV = Hex("#B45309");
        public static readonly Color DANGER     = Hex("#DC2626");
        public static readonly Color DANGER_HV  = Hex("#B91C1C");
        public static readonly Color SECONDARY    = Hex("#E2E8F0"); // light gray — back/other
        public static readonly Color SECONDARY_HV = Hex("#CBD5E1");

        // ── Text colors ───────────────────────────────────────────────────────
        public static readonly Color TEXT_PRIMARY   = Hex("#1E293B"); // near-black on light bg
        public static readonly Color TEXT_SECONDARY = Hex("#475569"); // medium slate
        public static readonly Color TEXT_MUTED     = Hex("#94A3B8"); // muted gray

        // ── DataGridView ──────────────────────────────────────────────────────
        public static readonly Color GRID_HEADER  = Hex("#2563EB");
        public static readonly Color GRID_ROW_ALT = Hex("#F1F5F9");
        public static readonly Color GRID_SEL     = Hex("#DBEAFE");
        public static readonly Color GRID_SEL_FG  = Hex("#1E3A8A");
        public static readonly Color GRID_LINE    = Hex("#E2E8F0");

        // ── Fonts ─────────────────────────────────────────────────────────────
        public static readonly Font F_TITLE   = new Font("Segoe UI", 18f, FontStyle.Bold);
        public static readonly Font F_SECTION = new Font("Segoe UI", 12f, FontStyle.Bold);
        public static readonly Font F_LABEL   = new Font("Segoe UI", 10f);
        public static readonly Font F_BODY    = new Font("Segoe UI", 10f);
        public static readonly Font F_SMALL   = new Font("Segoe UI", 9f);
        public static readonly Font F_BUTTON  = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font F_GRID_H  = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font F_GRID    = new Font("Segoe UI", 9f);

        // ── Apply theme to an entire UserControl panel ────────────────────────
        public static void ApplyTheme(Control container)
        {
            // Only replace WinForms system-default colors; preserve explicitly-set ones
            if (IsSystemDefault(container.BackColor))
                container.BackColor = BG_CONTENT;

            // Hebrew RTL text alignment in all child controls
            container.RightToLeft = RightToLeft.Yes;

            foreach (Control c in container.Controls)
                ApplyControl(c);
        }

        private static void ApplyControl(Control c)
        {
            switch (c)
            {
                case DataGridView dgv:
                    StyleGrid(dgv);
                    return;

                case Button btn:
                    StyleButton(btn);
                    return;

                case TextBox txt:
                    txt.BackColor   = BG_INPUT;
                    txt.ForeColor   = txt.ReadOnly ? TEXT_SECONDARY : TEXT_PRIMARY;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font        = F_BODY;
                    return;

                case ComboBox cmb:
                    cmb.BackColor = BG_INPUT;
                    cmb.ForeColor = TEXT_PRIMARY;
                    cmb.Font      = F_BODY;
                    return;

                case DateTimePicker dtp:
                    dtp.ForeColor              = TEXT_PRIMARY;
                    dtp.Font                   = F_BODY;
                    dtp.CalendarMonthBackground = BG_CARD;
                    dtp.CalendarTitleBackColor  = GRID_HEADER;
                    dtp.CalendarTitleForeColor  = Color.White;
                    dtp.CalendarForeColor       = TEXT_PRIMARY;
                    return;

                case Label lbl:
                    StyleLabel(lbl);
                    return;

                case Panel pnl:
                    if (IsSystemDefault(pnl.BackColor))
                        pnl.BackColor = BG_CARD;
                    foreach (Control child in pnl.Controls)
                        ApplyControl(child);
                    return;

                case GroupBox gb:
                    gb.ForeColor = TEXT_SECONDARY;
                    gb.Font      = F_LABEL;
                    if (IsSystemDefault(gb.BackColor))
                        gb.BackColor = BG_CARD;
                    foreach (Control child in gb.Controls)
                        ApplyControl(child);
                    return;
            }
        }

        private static void StyleLabel(Label lbl)
        {
            lbl.BackColor = Color.Transparent;
            string n = lbl.Name.ToLower();

            if (n == "label_title")
            {
                lbl.Font      = F_TITLE;
                lbl.ForeColor = TEXT_PRIMARY;
            }
            else if (n.Contains("error"))
            {
                lbl.Font      = F_SMALL;
                lbl.ForeColor = DANGER;
            }
            else if (n.Contains("form_header") || n.Contains("form_title") || n.Contains("_header"))
            {
                lbl.Font      = F_SECTION;
                lbl.ForeColor = TEXT_SECONDARY;
            }
            else
            {
                lbl.Font      = F_LABEL;
                lbl.ForeColor = TEXT_SECONDARY;
            }
        }

        public static void StyleButton(Button btn)
        {
            // Skip nav-card buttons — they keep their own card styling
            if (btn.Tag?.ToString() == "nav_card") return;

            Color bg = GetButtonBg(btn);
            Color hv = Darken(bg, 0.12f);

            btn.BackColor                 = bg;
            btn.ForeColor                 = IsBright(bg) ? TEXT_PRIMARY : Color.White;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = F_BUTTON;
            btn.Cursor                    = Cursors.Hand;
            btn.UseVisualStyleBackColor   = false;
            if (btn.Height < 36) btn.Height = 36;

            btn.MouseEnter += (s, e) => { if (btn.Enabled) btn.BackColor = hv; };
            btn.MouseLeave += (s, e) => btn.BackColor = bg;
        }

        private static Color GetButtonBg(Button btn)
        {
            string n = btn.Name.ToLower();

            if (n.Contains("save") || n.Contains("login") || n == "btn_add"
                || (n.Contains("assign_boat") && !n.Contains("external")))
                return PRIMARY;

            if (n.Contains("update") || n.Contains("complete"))
                return SUCCESS;

            if (n.Contains("delete") || n.Contains("remove"))
                return DANGER;

            if (n.Contains("cancel_activity") || n.Contains("report_fault") || n.Contains("fail_repair"))
                return WARNING;

            if (n.Contains("logout"))
                return DANGER;

            // exit is secondary (not danger) — distinct from logout
            return SECONDARY;
        }

        // ── DataGridView styling ──────────────────────────────────────────────
        public static void StyleGrid(DataGridView g)
        {
            g.EnableHeadersVisualStyles   = false;
            g.BackgroundColor             = BG_CONTENT;
            g.GridColor                   = GRID_LINE;
            g.BorderStyle                 = BorderStyle.None;
            g.RowHeadersVisible           = false;
            g.AllowUserToResizeRows       = false;
            g.ColumnHeadersHeight         = 36;
            g.RowTemplate.Height          = 32;
            g.AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill;
            g.CellBorderStyle             = DataGridViewCellBorderStyle.SingleHorizontal;
            g.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect                 = false;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            g.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = GRID_HEADER,
                ForeColor          = Color.White,
                Font               = F_GRID_H,
                Alignment          = DataGridViewContentAlignment.MiddleRight,
                Padding            = new Padding(4, 0, 4, 0),
                SelectionBackColor = GRID_HEADER,
                SelectionForeColor = Color.White
            };

            g.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = BG_CARD,
                ForeColor          = TEXT_PRIMARY,
                Font               = F_GRID,
                SelectionBackColor = GRID_SEL,
                SelectionForeColor = GRID_SEL_FG,
                Alignment          = DataGridViewContentAlignment.MiddleRight,
                Padding            = new Padding(4, 0, 4, 0)
            };

            g.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = GRID_ROW_ALT,
                ForeColor          = TEXT_PRIMARY,
                SelectionBackColor = GRID_SEL,
                SelectionForeColor = GRID_SEL_FG
            };
        }

        // ── Utilities ─────────────────────────────────────────────────────────

        // True for WinForms system defaults (safe to override)
        private static bool IsSystemDefault(Color c)
            => c == SystemColors.ButtonHighlight
            || c == SystemColors.Control
            || c == SystemColors.Window
            || c == SystemColors.ButtonFace
            || c == Color.WhiteSmoke;

        // True if color is light-enough to need dark text
        private static bool IsBright(Color c)
            => !c.IsEmpty && c.A > 200 && c.R > 200 && c.G > 200 && c.B > 200;

        private static Color Darken(Color c, float f)
            => Color.FromArgb(c.A,
                (int)Math.Max(0, c.R * (1 - f)),
                (int)Math.Max(0, c.G * (1 - f)),
                (int)Math.Max(0, c.B * (1 - f)));

        public static Color Hex(string h)
        {
            h = h.TrimStart('#');
            return Color.FromArgb(
                Convert.ToInt32(h.Substring(0, 2), 16),
                Convert.ToInt32(h.Substring(2, 2), 16),
                Convert.ToInt32(h.Substring(4, 2), 16));
        }
    }
}
