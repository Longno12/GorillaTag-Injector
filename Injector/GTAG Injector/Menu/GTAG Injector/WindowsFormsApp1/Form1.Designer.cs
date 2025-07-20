namespace REPO_Injector
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.txtProcessId = new System.Windows.Forms.TextBox();
            this.btnSelectProcess = new System.Windows.Forms.Button();
            this.lblDllPath = new System.Windows.Forms.Label();
            this.txtDllPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnInject = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.ofdDll = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusPanel = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.pnlRoot = new REPO_Injector.BorderedPanel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.pnlTitleBar.SuspendLayout();
            this.statusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.pnlRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlTitleBar.Controls.Add(this.picIcon);
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Controls.Add(this.btnMinimize);
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(550, 35);
            this.pnlTitleBar.TabIndex = 0;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 17);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "GORILLA TAG INJECTOR";
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Marlett", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(480, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "0";
            this.toolTip.SetToolTip(this.btnMinimize, "Minimize");
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Marlett", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(515, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "r";
            this.toolTip.SetToolTip(this.btnClose, "Close");
            this.btnClose.UseVisualStyleBackColor = true;
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Location = new System.Drawing.Point(30, 60);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(102, 17);
            this.lblProcess.TabIndex = 1;
            this.lblProcess.Text = "Target Process";
            this.txtProcess.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProcess.Location = new System.Drawing.Point(33, 83);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.ReadOnly = true;
            this.txtProcess.Size = new System.Drawing.Size(180, 25);
            this.txtProcess.TabIndex = 2;
            this.toolTip.SetToolTip(this.txtProcess, "Name of the target process");
            this.txtProcessId.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtProcessId.Location = new System.Drawing.Point(219, 83);
            this.txtProcessId.Name = "txtProcessId";
            this.txtProcessId.ReadOnly = true;
            this.txtProcessId.Size = new System.Drawing.Size(100, 25);
            this.txtProcessId.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtProcessId, "Process ID of the target process");
            this.btnSelectProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectProcess.Location = new System.Drawing.Point(325, 83);
            this.btnSelectProcess.Name = "btnSelectProcess";
            this.btnSelectProcess.Size = new System.Drawing.Size(192, 25);
            this.btnSelectProcess.TabIndex = 4;
            this.btnSelectProcess.Text = "SELECT PROCESS";
            this.toolTip.SetToolTip(this.btnSelectProcess, "Select a running process from a list");
            this.btnSelectProcess.UseVisualStyleBackColor = true;
            this.lblDllPath.AutoSize = true;
            this.lblDllPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDllPath.Location = new System.Drawing.Point(30, 130);
            this.lblDllPath.Name = "lblDllPath";
            this.lblDllPath.Size = new System.Drawing.Size(111, 17);
            this.lblDllPath.TabIndex = 5;
            this.lblDllPath.Text = "DLL To Inject";
            this.txtDllPath.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDllPath.Location = new System.Drawing.Point(33, 153);
            this.txtDllPath.Name = "txtDllPath";
            this.txtDllPath.Size = new System.Drawing.Size(428, 25);
            this.txtDllPath.TabIndex = 6;
            this.toolTip.SetToolTip(this.txtDllPath, "Path to the DLL file. You can also drag and drop a DLL file onto this window.");
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.Location = new System.Drawing.Point(467, 153);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(50, 25);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.toolTip.SetToolTip(this.btnBrowse, "Browse for a DLL file");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnInject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInject.Location = new System.Drawing.Point(33, 200);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(484, 50);
            this.btnInject.TabIndex = 8;
            this.btnInject.Text = "INJECT";
            this.toolTip.SetToolTip(this.btnInject, "Begin the injection process");
            this.btnInject.UseVisualStyleBackColor = true;
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(33, 270);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(484, 274);
            this.txtLog.TabIndex = 9;
            this.ofdDll.Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*";
            this.ofdDll.Title = "Select DLL to inject";
            this.statusPanel.Controls.Add(this.lblStatus);
            this.statusPanel.Controls.Add(this.picStatus);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Location = new System.Drawing.Point(0, 580);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(550, 30);
            this.statusPanel.TabIndex = 1;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(40, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Ready";
            this.picStatus.Location = new System.Drawing.Point(12, 5);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(20, 20);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatus.TabIndex = 0;
            this.picStatus.TabStop = false;
            this.pnlRoot.borderColor = System.Drawing.Color.White;
            this.pnlRoot.Controls.Add(this.pnlTitleBar);
            this.pnlRoot.Controls.Add(this.txtLog);
            this.pnlRoot.Controls.Add(this.btnInject);
            this.pnlRoot.Controls.Add(this.lblProcess);
            this.pnlRoot.Controls.Add(this.btnBrowse);
            this.pnlRoot.Controls.Add(this.txtProcess);
            this.pnlRoot.Controls.Add(this.txtDllPath);
            this.pnlRoot.Controls.Add(this.txtProcessId);
            this.pnlRoot.Controls.Add(this.lblDllPath);
            this.pnlRoot.Controls.Add(this.btnSelectProcess);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(550, 580);
            this.pnlRoot.TabIndex = 2;
            this.picIcon.Image = global::WindowsFormsApp1.Properties.Resources.app_icon;
            this.picIcon.Location = new System.Drawing.Point(10, 5);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(25, 25);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 3;
            this.picIcon.TabStop = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 610);
            this.Controls.Add(this.pnlRoot);
            this.Controls.Add(this.statusPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gorilla Tag Injector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.pnlRoot.ResumeLayout(false);
            this.pnlRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.TextBox txtProcessId;
        private System.Windows.Forms.Button btnSelectProcess;
        private System.Windows.Forms.Label lblDllPath;
        private System.Windows.Forms.TextBox txtDllPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.OpenFileDialog ofdDll;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Label lblStatus;
        private BorderedPanel pnlRoot;
        private System.Windows.Forms.PictureBox picIcon;
    }
}