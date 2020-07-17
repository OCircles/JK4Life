namespace JK4Life
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tap_settings = new System.Windows.Forms.TabPage();
            this.grp_settings_motsMods = new System.Windows.Forms.GroupBox();
            this.btn_settings_motsModsBrowse = new System.Windows.Forms.Button();
            this.txt_settings_motsMods = new System.Windows.Forms.TextBox();
            this.grp_settings_jkMods = new System.Windows.Forms.GroupBox();
            this.btn_settings_jkModsBrowse = new System.Windows.Forms.Button();
            this.txt_settings_jkMods = new System.Windows.Forms.TextBox();
            this.grp_settings_motsPath = new System.Windows.Forms.GroupBox();
            this.btn_settings_motsPathBrowse = new System.Windows.Forms.Button();
            this.txt_settings_motsPath = new System.Windows.Forms.TextBox();
            this.grp_settings_jkPath = new System.Windows.Forms.GroupBox();
            this.btn_settings_jkPathBrowse = new System.Windows.Forms.Button();
            this.txt_settings_jkPath = new System.Windows.Forms.TextBox();
            this.tap_launch = new System.Windows.Forms.TabPage();
            this.tab_main = new System.Windows.Forms.TabControl();
            this.trv_gameList = new System.Windows.Forms.TreeView();
            this.tap_settings.SuspendLayout();
            this.grp_settings_motsMods.SuspendLayout();
            this.grp_settings_jkMods.SuspendLayout();
            this.grp_settings_motsPath.SuspendLayout();
            this.grp_settings_jkPath.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tap_settings
            // 
            this.tap_settings.BackColor = System.Drawing.SystemColors.Control;
            this.tap_settings.Controls.Add(this.grp_settings_motsMods);
            this.tap_settings.Controls.Add(this.grp_settings_jkMods);
            this.tap_settings.Controls.Add(this.grp_settings_motsPath);
            this.tap_settings.Controls.Add(this.grp_settings_jkPath);
            this.tap_settings.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tap_settings.Location = new System.Drawing.Point(4, 22);
            this.tap_settings.Name = "tap_settings";
            this.tap_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tap_settings.Size = new System.Drawing.Size(500, 385);
            this.tap_settings.TabIndex = 2;
            this.tap_settings.Text = "Settings";
            // 
            // grp_settings_motsMods
            // 
            this.grp_settings_motsMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_settings_motsMods.Controls.Add(this.btn_settings_motsModsBrowse);
            this.grp_settings_motsMods.Controls.Add(this.txt_settings_motsMods);
            this.grp_settings_motsMods.Location = new System.Drawing.Point(9, 190);
            this.grp_settings_motsMods.Name = "grp_settings_motsMods";
            this.grp_settings_motsMods.Size = new System.Drawing.Size(482, 55);
            this.grp_settings_motsMods.TabIndex = 4;
            this.grp_settings_motsMods.TabStop = false;
            this.grp_settings_motsMods.Text = "MotS Mod Folder";
            // 
            // btn_settings_motsModsBrowse
            // 
            this.btn_settings_motsModsBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_settings_motsModsBrowse.Location = new System.Drawing.Point(401, 17);
            this.btn_settings_motsModsBrowse.Name = "btn_settings_motsModsBrowse";
            this.btn_settings_motsModsBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_settings_motsModsBrowse.TabIndex = 1;
            this.btn_settings_motsModsBrowse.Text = "Browse";
            this.btn_settings_motsModsBrowse.UseVisualStyleBackColor = true;
            this.btn_settings_motsModsBrowse.Click += new System.EventHandler(this.btn_settings_motsModsBrowse_Click);
            // 
            // txt_settings_motsMods
            // 
            this.txt_settings_motsMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_settings_motsMods.Location = new System.Drawing.Point(7, 20);
            this.txt_settings_motsMods.Name = "txt_settings_motsMods";
            this.txt_settings_motsMods.ReadOnly = true;
            this.txt_settings_motsMods.Size = new System.Drawing.Size(388, 22);
            this.txt_settings_motsMods.TabIndex = 0;
            // 
            // grp_settings_jkMods
            // 
            this.grp_settings_jkMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_settings_jkMods.Controls.Add(this.btn_settings_jkModsBrowse);
            this.grp_settings_jkMods.Controls.Add(this.txt_settings_jkMods);
            this.grp_settings_jkMods.Location = new System.Drawing.Point(9, 129);
            this.grp_settings_jkMods.Name = "grp_settings_jkMods";
            this.grp_settings_jkMods.Size = new System.Drawing.Size(482, 55);
            this.grp_settings_jkMods.TabIndex = 3;
            this.grp_settings_jkMods.TabStop = false;
            this.grp_settings_jkMods.Text = "JK Mod Folder";
            // 
            // btn_settings_jkModsBrowse
            // 
            this.btn_settings_jkModsBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_settings_jkModsBrowse.Location = new System.Drawing.Point(401, 20);
            this.btn_settings_jkModsBrowse.Name = "btn_settings_jkModsBrowse";
            this.btn_settings_jkModsBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_settings_jkModsBrowse.TabIndex = 1;
            this.btn_settings_jkModsBrowse.Text = "Browse";
            this.btn_settings_jkModsBrowse.UseVisualStyleBackColor = true;
            this.btn_settings_jkModsBrowse.Click += new System.EventHandler(this.btn_settings_jkModsBrowse_Click);
            // 
            // txt_settings_jkMods
            // 
            this.txt_settings_jkMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_settings_jkMods.Location = new System.Drawing.Point(7, 20);
            this.txt_settings_jkMods.Name = "txt_settings_jkMods";
            this.txt_settings_jkMods.ReadOnly = true;
            this.txt_settings_jkMods.Size = new System.Drawing.Size(388, 22);
            this.txt_settings_jkMods.TabIndex = 0;
            // 
            // grp_settings_motsPath
            // 
            this.grp_settings_motsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_settings_motsPath.Controls.Add(this.btn_settings_motsPathBrowse);
            this.grp_settings_motsPath.Controls.Add(this.txt_settings_motsPath);
            this.grp_settings_motsPath.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_settings_motsPath.Location = new System.Drawing.Point(9, 68);
            this.grp_settings_motsPath.Name = "grp_settings_motsPath";
            this.grp_settings_motsPath.Size = new System.Drawing.Size(482, 55);
            this.grp_settings_motsPath.TabIndex = 2;
            this.grp_settings_motsPath.TabStop = false;
            this.grp_settings_motsPath.Text = "Mysteries of the Sith Path";
            // 
            // btn_settings_motsPathBrowse
            // 
            this.btn_settings_motsPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_settings_motsPathBrowse.Location = new System.Drawing.Point(401, 20);
            this.btn_settings_motsPathBrowse.Name = "btn_settings_motsPathBrowse";
            this.btn_settings_motsPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_settings_motsPathBrowse.TabIndex = 1;
            this.btn_settings_motsPathBrowse.Text = "Browse";
            this.btn_settings_motsPathBrowse.UseVisualStyleBackColor = true;
            this.btn_settings_motsPathBrowse.Click += new System.EventHandler(this.btn_settings_motsPathBrowse_Click);
            // 
            // txt_settings_motsPath
            // 
            this.txt_settings_motsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_settings_motsPath.Location = new System.Drawing.Point(7, 20);
            this.txt_settings_motsPath.Name = "txt_settings_motsPath";
            this.txt_settings_motsPath.ReadOnly = true;
            this.txt_settings_motsPath.Size = new System.Drawing.Size(388, 22);
            this.txt_settings_motsPath.TabIndex = 0;
            // 
            // grp_settings_jkPath
            // 
            this.grp_settings_jkPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_settings_jkPath.Controls.Add(this.btn_settings_jkPathBrowse);
            this.grp_settings_jkPath.Controls.Add(this.txt_settings_jkPath);
            this.grp_settings_jkPath.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_settings_jkPath.Location = new System.Drawing.Point(9, 7);
            this.grp_settings_jkPath.Name = "grp_settings_jkPath";
            this.grp_settings_jkPath.Size = new System.Drawing.Size(482, 55);
            this.grp_settings_jkPath.TabIndex = 0;
            this.grp_settings_jkPath.TabStop = false;
            this.grp_settings_jkPath.Text = "Jedi Knight Path";
            // 
            // btn_settings_jkPathBrowse
            // 
            this.btn_settings_jkPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_settings_jkPathBrowse.Location = new System.Drawing.Point(401, 20);
            this.btn_settings_jkPathBrowse.Name = "btn_settings_jkPathBrowse";
            this.btn_settings_jkPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_settings_jkPathBrowse.TabIndex = 1;
            this.btn_settings_jkPathBrowse.Text = "Browse";
            this.btn_settings_jkPathBrowse.UseVisualStyleBackColor = true;
            this.btn_settings_jkPathBrowse.Click += new System.EventHandler(this.btn_settings_jkPathBrowse_Click);
            // 
            // txt_settings_jkPath
            // 
            this.txt_settings_jkPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_settings_jkPath.Location = new System.Drawing.Point(7, 20);
            this.txt_settings_jkPath.Name = "txt_settings_jkPath";
            this.txt_settings_jkPath.ReadOnly = true;
            this.txt_settings_jkPath.Size = new System.Drawing.Size(388, 22);
            this.txt_settings_jkPath.TabIndex = 0;
            // 
            // tap_launch
            // 
            this.tap_launch.BackColor = System.Drawing.SystemColors.Control;
            this.tap_launch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tap_launch.Location = new System.Drawing.Point(4, 24);
            this.tap_launch.Name = "tap_launch";
            this.tap_launch.Padding = new System.Windows.Forms.Padding(3);
            this.tap_launch.Size = new System.Drawing.Size(500, 383);
            this.tap_launch.TabIndex = 0;
            this.tap_launch.Text = "Launch";
            // 
            // tab_main
            // 
            this.tab_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_main.Controls.Add(this.tap_launch);
            this.tab_main.Controls.Add(this.tap_settings);
            this.tab_main.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_main.Location = new System.Drawing.Point(177, 0);
            this.tab_main.Multiline = true;
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(508, 411);
            this.tab_main.TabIndex = 8;
            // 
            // trv_gameList
            // 
            this.trv_gameList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trv_gameList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.trv_gameList.Location = new System.Drawing.Point(-1, 0);
            this.trv_gameList.Name = "trv_gameList";
            this.trv_gameList.Size = new System.Drawing.Size(183, 411);
            this.trv_gameList.TabIndex = 9;
            this.trv_gameList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_gameList_AfterSelect);
            this.trv_gameList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trv_gameList_MouseDown);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.trv_gameList);
            this.Controls.Add(this.tab_main);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form_Main";
            this.ShowIcon = false;
            this.Text = "JK4Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tap_settings.ResumeLayout(false);
            this.grp_settings_motsMods.ResumeLayout(false);
            this.grp_settings_motsMods.PerformLayout();
            this.grp_settings_jkMods.ResumeLayout(false);
            this.grp_settings_jkMods.PerformLayout();
            this.grp_settings_motsPath.ResumeLayout(false);
            this.grp_settings_motsPath.PerformLayout();
            this.grp_settings_jkPath.ResumeLayout(false);
            this.grp_settings_jkPath.PerformLayout();
            this.tab_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tap_settings;
        private System.Windows.Forms.GroupBox grp_settings_jkMods;
        private System.Windows.Forms.Button btn_settings_jkModsBrowse;
        private System.Windows.Forms.TextBox txt_settings_jkMods;
        private System.Windows.Forms.GroupBox grp_settings_motsPath;
        private System.Windows.Forms.Button btn_settings_motsPathBrowse;
        private System.Windows.Forms.TextBox txt_settings_motsPath;
        private System.Windows.Forms.GroupBox grp_settings_jkPath;
        private System.Windows.Forms.Button btn_settings_jkPathBrowse;
        private System.Windows.Forms.TextBox txt_settings_jkPath;
        private System.Windows.Forms.TabPage tap_launch;
        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.GroupBox grp_settings_motsMods;
        private System.Windows.Forms.Button btn_settings_motsModsBrowse;
        private System.Windows.Forms.TextBox txt_settings_motsMods;
        private System.Windows.Forms.TreeView trv_gameList;
    }
}

