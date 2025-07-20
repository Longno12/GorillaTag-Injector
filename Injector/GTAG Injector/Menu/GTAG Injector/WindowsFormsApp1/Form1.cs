using SharpMonoInjector;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace REPO_Injector
{
    public partial class MainForm : Form
    {
        #region Custom Window Dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        // Injection details for Gorilla Tag mods
        private const string DefaultNamespace = "ProjectEncryptic";
        private const string DefaultClass = "Loader";
        private const string DefaultMethod = "Init";

        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
            SetupEventHandlers();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string arch = Environment.Is64BitProcess ? "x64" : "x86";
            lblTitle.Text = $"GORILLA TAG INJECTOR ({arch})";
            LogMessage("Welcome! Initializing injector...");
            if (!CheckAdminRights())
            {
                LogError("Admin rights required. Please restart as Administrator.");
                SetStatus("Restart as Admin", StatusType.Error);
            }
            else
            {
                LogMessage("Running with administrative privileges.");
                SetupAutoDetection();
            }
        }

        #region UI Setup and Theming

        private void ApplyTheme()
        {
            this.BackColor = Dracula.Background;
            pnlTitleBar.BackColor = Dracula.Selection;
            pnlRoot.BackColor = Dracula.Background;
            pnlRoot.borderColor = Dracula.Comment;
            lblTitle.ForeColor = Dracula.Foreground;
            ApplyButtonTheme(btnClose, Dracula.Red);
            ApplyButtonTheme(btnMinimize, Dracula.Orange);
            ApplyButtonTheme(btnSelectProcess, Dracula.Comment, Dracula.Selection);
            ApplyButtonTheme(btnBrowse, Dracula.Comment, Dracula.Selection);
            ApplyButtonTheme(btnInject, Dracula.Pink, Dracula.Comment);
            lblProcess.ForeColor = Dracula.Purple;
            lblDllPath.ForeColor = Dracula.Purple;
            ApplyTextBoxTheme(txtProcess);
            ApplyTextBoxTheme(txtProcessId);
            ApplyTextBoxTheme(txtDllPath);
            txtLog.BackColor = Dracula.Selection;
            txtLog.ForeColor = Dracula.Foreground;
            txtLog.BorderStyle = BorderStyle.None;
            statusPanel.BackColor = Dracula.Background;
            lblStatus.ForeColor = Dracula.Foreground;
        }

        private void ApplyButtonTheme(Button btn, Color baseColor, Color? hoverColor = null)
        {
            btn.BackColor = baseColor;
            btn.ForeColor = Dracula.Foreground;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            Color onHover = hoverColor ?? ControlPaint.Light(baseColor, 0.2f);
            Color onLeave = baseColor;
            btn.MouseEnter += (s, e) => btn.BackColor = onHover;
            btn.MouseLeave += (s, e) => btn.BackColor = onLeave;
        }

        private void ApplyTextBoxTheme(TextBox txt)
        {
            txt.BackColor = Dracula.Selection;
            txt.ForeColor = Dracula.Foreground;
            txt.BorderStyle = BorderStyle.None;
        }

        private void SetupEventHandlers()
        {
            pnlTitleBar.MouseDown += TitleBar_MouseDown;
            lblTitle.MouseDown += TitleBar_MouseDown;
            picIcon.MouseDown += TitleBar_MouseDown;
            btnClose.Click += (s, e) => Application.Exit();
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnSelectProcess.Click += btnSelectProcess_Click;
            btnBrowse.Click += btnBrowse_Click;
            btnInject.Click += btnInject_Click;

            // Drag and Drop for DLL
            this.AllowDrop = true;
            this.DragEnter += Form_DragEnter;
            this.DragDrop += Form_DragDrop;
        }
        #endregion

        #region Core Functionality

        private void SetupAutoDetection()
        {
            var gorillaProcess = Process.GetProcessesByName("Gorilla Tag").FirstOrDefault();
            if (gorillaProcess != null)
            {
                txtProcess.Text = gorillaProcess.ProcessName;
                txtProcessId.Text = gorillaProcess.Id.ToString();
                LogMessage($"Auto-detected Gorilla Tag (PID: {gorillaProcess.Id})");
                SetStatus($"Gorilla Tag Found", StatusType.Success);
            }
            else
            {
                LogMessage("Gorilla Tag process not found. Please start the game or select it manually.");
                SetStatus("Waiting for Process...", StatusType.Warning);
            }
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            LogMessage("------------------------------");
            SetStatus("Validating inputs...", StatusType.Working);

            if (!ValidateInputs()) return;

            try
            {
                Process process = Process.GetProcessById(int.Parse(txtProcessId.Text));
                LogMessage($"Target process found: {process.ProcessName} (PID: {process.Id})");

                if (!CheckProcessArchitecture(process)) return;

                Inject(process);
            }
            catch (Exception ex)
            {
                LogError($"Injection failed: {ex.Message}");
                if (ex.InnerException != null) LogError($"  Details: {ex.InnerException.Message}");
                SetStatus("Injection FAILED", StatusType.Error);
            }
        }

        private void Inject(Process process)
        {
            byte[] dllBytes = File.ReadAllBytes(txtDllPath.Text);
            LogMessage($"DLL size: {dllBytes.Length / 1024} KB");

            using (var injector = new Injector(process.Id))
            {
                LogMessage("Injecting assembly...");
                SetStatus("Injecting...", StatusType.Working);

                injector.Inject(dllBytes, DefaultNamespace, DefaultClass, DefaultMethod);

                LogMessage("Injection successful!");
                SetStatus("Injection Successful!", StatusType.Success);
            }
        }
        #endregion

        #region Input Validation and Checks

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtDllPath.Text) || !File.Exists(txtDllPath.Text))
            {
                LogError("DLL path is invalid or file does not exist.");
                SetStatus("Invalid DLL Path", StatusType.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtProcessId.Text) || !int.TryParse(txtProcessId.Text, out _))
            {
                LogError("Process ID is not valid.");
                SetStatus("Invalid Process ID", StatusType.Error);
                return false;
            }

            return true;
        }

        private bool CheckProcessArchitecture(Process process)
        {
            IsWow64Process(process.Handle, out bool isTargetWow64);
            bool isTarget64Bit = Environment.Is64BitOperatingSystem && !isTargetWow64;
            bool isInjector64Bit = Environment.Is64BitProcess;

            LogMessage($"Process Architecture: {(isTarget64Bit ? "64-bit" : "32-bit")}");
            LogMessage($"Injector Architecture: {(isInjector64Bit ? "64-bit" : "32-bit")}");

            if (isTarget64Bit != isInjector64Bit)
            {
                LogError("Architecture mismatch! Use a matching 32/64-bit injector.");
                SetStatus("Architecture Mismatch", StatusType.Error);
                return false;
            }
            return true;
        }

        private bool CheckAdminRights()
        {
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
        #endregion

        #region Event Handlers
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdDll.ShowDialog() == DialogResult.OK)
            {
                txtDllPath.Text = ofdDll.FileName;
                LogMessage($"DLL selected: {Path.GetFileName(txtDllPath.Text)}");
            }
        }
        private void btnSelectProcess_Click(object sender, EventArgs e)
        {
            using (var psd = new ProcessSelectDialog())
            {
                if (psd.ShowDialog() == DialogResult.OK)
                {
                    txtProcess.Text = psd.SelectedProcessName;
                    txtProcessId.Text = psd.SelectedProcessId.ToString();
                    LogMessage($"Process selected: {psd.SelectedProcessName} (PID: {psd.SelectedProcessId})");
                    SetStatus("Process Selected", StatusType.Ready);
                }
            }
        }
        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && Path.GetExtension(files[0]).Equals(".dll", StringComparison.OrdinalIgnoreCase))
            {
                txtDllPath.Text = files[0];
                LogMessage($"DLL loaded via drag-and-drop: {Path.GetFileName(files[0])}");
            }
        }
        #endregion

        #region Logging and Status Updates
        private enum StatusType { Ready, Working, Success, Error, Warning }
        private void LogMessage(string message)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] [INFO] {message}{Environment.NewLine}");
        }

        private void LogError(string message)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] [ERROR] {message}{Environment.NewLine}");
        }
        private void SetStatus(string text, StatusType type)
        {
            lblStatus.Text = text;
            switch (type)
            {
                case StatusType.Ready:
                    picStatus.Image = WindowsFormsApp1.Properties.Resources.status_ready;
                    lblStatus.ForeColor = Dracula.Cyan;
                    break;
                case StatusType.Working:
                    picStatus.Image = WindowsFormsApp1.Properties.Resources.status_working;
                    lblStatus.ForeColor = Dracula.Yellow;
                    break;
                case StatusType.Success:
                    picStatus.Image = WindowsFormsApp1.Properties.Resources.status_success;
                    lblStatus.ForeColor = Dracula.Green;
                    break;
                case StatusType.Error:
                    picStatus.Image = WindowsFormsApp1.Properties.Resources.status_error;
                    lblStatus.ForeColor = Dracula.Red;
                    break;
                case StatusType.Warning:
                    picStatus.Image = WindowsFormsApp1.Properties.Resources.status_warning;
                    lblStatus.ForeColor = Dracula.Orange;
                    break;
            }
        }
        #endregion
    }

    #region Theming Helpers
    public static class Dracula
    {
        public static readonly Color Background = Color.FromArgb(40, 42, 54);
        public static readonly Color Selection = Color.FromArgb(68, 71, 90);
        public static readonly Color Foreground = Color.FromArgb(248, 248, 242);
        public static readonly Color Comment = Color.FromArgb(98, 114, 164);
        public static readonly Color Cyan = Color.FromArgb(139, 233, 253);
        public static readonly Color Green = Color.FromArgb(80, 250, 123);
        public static readonly Color Orange = Color.FromArgb(255, 184, 108);
        public static readonly Color Pink = Color.FromArgb(255, 121, 198);
        public static readonly Color Purple = Color.FromArgb(189, 147, 249);
        public static readonly Color Red = Color.FromArgb(255, 85, 85);
        public static readonly Color Yellow = Color.FromArgb(241, 250, 140);
    }
    public class BorderedPanel : Panel
    {
        public Color borderColor { get; set; } = Color.White;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(borderColor, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }
    }
    #endregion
}