using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace REPO_Injector
{
    public class ProcessSelectDialog : Form
    {
        public string SelectedProcessName { get; private set; }
        public int SelectedProcessId { get; private set; }

        private ListBox lstProcesses;
        private Button btnSelect;
        private Button btnCancel;
        private TextBox txtFilter;

        public ProcessSelectDialog()
        {
            InitializeComponent();
            ApplyTheme();
            LoadProcesses();
        }

        private void InitializeComponent()
        {
            this.Text = "Select Process";
            this.Size = new Size(400, 500);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            var pnlTitle = new Panel { Dock = DockStyle.Top, Height = 30, BackColor = Dracula.Selection };
            var lblTitle = new Label { Text = "SELECT A PROCESS", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9.75f, FontStyle.Bold), ForeColor = Dracula.Foreground };
            pnlTitle.Controls.Add(lblTitle);
            txtFilter = new TextBox { Dock = DockStyle.Top, Font = new Font("Segoe UI", 11f), Margin = new Padding(10), Height = 28 };
            txtFilter.TextChanged += (s, e) => FilterProcesses();
            lstProcesses = new ListBox { Dock = DockStyle.Fill, Font = new Font("Consolas", 10f), IntegralHeight = false, ItemHeight = 22, DrawMode = DrawMode.OwnerDrawFixed };
            lstProcesses.DrawItem += LstProcesses_DrawItem;
            lstProcesses.DoubleClick += (s, e) => SelectProcess();
            var pnlButtons = new Panel { Dock = DockStyle.Bottom, Height = 60, Padding = new Padding(10) };
            btnSelect = new Button { Text = "SELECT", DialogResult = DialogResult.OK, Anchor = AnchorStyles.Right, Size = new Size(120, 40) };
            btnCancel = new Button { Text = "CANCEL", DialogResult = DialogResult.Cancel, Anchor = AnchorStyles.Right, Size = new Size(120, 40) };
            pnlButtons.Controls.Add(btnSelect);
            pnlButtons.Controls.Add(btnCancel);
            btnSelect.Left = pnlButtons.Width - btnSelect.Width - 10;
            btnCancel.Left = btnSelect.Left - btnCancel.Width - 10;
            this.Controls.Add(lstProcesses);
            this.Controls.Add(txtFilter);
            this.Controls.Add(pnlButtons);
            this.Controls.Add(pnlTitle);
            this.AcceptButton = btnSelect;
            this.CancelButton = btnCancel;
        }

        private void ApplyTheme()
        {
            this.BackColor = Dracula.Background;
            this.ForeColor = Dracula.Foreground;
            lstProcesses.BackColor = Dracula.Selection;
            lstProcesses.ForeColor = Dracula.Foreground;
            lstProcesses.BorderStyle = BorderStyle.None;
            txtFilter.BackColor = Dracula.Selection;
            txtFilter.ForeColor = Dracula.Foreground;
            txtFilter.BorderStyle = BorderStyle.FixedSingle;

            foreach (Button btn in new[] { btnSelect, btnCancel })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                btn.ForeColor = Dracula.Background;
            }
            btnSelect.BackColor = Dracula.Green;
            btnCancel.BackColor = Dracula.Comment;
        }

        private void LstProcesses_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            e.Graphics.FillRectangle(new SolidBrush(isSelected ? Dracula.Purple : Dracula.Selection), e.Bounds);
            string text = lstProcesses.Items[e.Index].ToString();
            TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, Dracula.Foreground, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
            e.DrawFocusRectangle();
        }

        private void LoadProcesses()
        {
            lstProcesses.BeginUpdate();
            lstProcesses.Items.Clear();
            txtFilter.Clear();

            try
            {
                var processes = Process.GetProcesses()
                    .Where(p => p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(p.ProcessName))
                    .OrderBy(p => p.ProcessName);

                foreach (var p in processes)
                {
                    lstProcesses.Items.Add($"{p.ProcessName} (PID: {p.Id})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading processes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lstProcesses.EndUpdate();
            }
        }

        private void FilterProcesses()
        {
            string filter = txtFilter.Text.ToLower();
            lstProcesses.Items.Clear();
            var processes = Process.GetProcesses().Where(p => p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrEmpty(p.ProcessName)).Where(p => p.ProcessName.ToLower().Contains(filter) || p.Id.ToString().Contains(filter)).OrderBy(p => p.ProcessName);

            foreach (var p in processes)
            {
                lstProcesses.Items.Add($"{p.ProcessName} (PID: {p.Id})");
            }
        }

        private void SelectProcess()
        {
            if (lstProcesses.SelectedItem == null) return;
            var parts = lstProcesses.SelectedItem.ToString().Split(new[] { " (PID: " }, StringSplitOptions.None);
            SelectedProcessName = parts[0];
            SelectedProcessId = int.Parse(parts[1].TrimEnd(')'));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}