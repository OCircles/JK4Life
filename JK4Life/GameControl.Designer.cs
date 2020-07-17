namespace JK4Life
{
    partial class GameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_title = new System.Windows.Forms.Label();
            this.gpb_mods = new System.Windows.Forms.GroupBox();
            this.lvw_mods = new System.Windows.Forms.ListView();
            this.btn_play = new System.Windows.Forms.Button();
            this.gpb_assembly = new System.Windows.Forms.GroupBox();
            this.lvw_assembly = new System.Windows.Forms.ListView();
            this.pic_gameIcon = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_arguments = new System.Windows.Forms.TextBox();
            this.lbl_currentMod = new System.Windows.Forms.Label();
            this.gpb_mods.SuspendLayout();
            this.gpb_assembly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_gameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Italic);
            this.lbl_title.Location = new System.Drawing.Point(80, 24);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(113, 25);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Game Title";
            // 
            // gpb_mods
            // 
            this.gpb_mods.Controls.Add(this.lvw_mods);
            this.gpb_mods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb_mods.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpb_mods.Location = new System.Drawing.Point(0, 0);
            this.gpb_mods.Name = "gpb_mods";
            this.gpb_mods.Size = new System.Drawing.Size(593, 190);
            this.gpb_mods.TabIndex = 1;
            this.gpb_mods.TabStop = false;
            this.gpb_mods.Text = "Mods";
            // 
            // lvw_mods
            // 
            this.lvw_mods.AllowDrop = true;
            this.lvw_mods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw_mods.GridLines = true;
            this.lvw_mods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_mods.HideSelection = false;
            this.lvw_mods.Location = new System.Drawing.Point(7, 20);
            this.lvw_mods.Name = "lvw_mods";
            this.lvw_mods.Size = new System.Drawing.Size(580, 164);
            this.lvw_mods.TabIndex = 0;
            this.lvw_mods.UseCompatibleStateImageBehavior = false;
            this.lvw_mods.View = System.Windows.Forms.View.List;
            this.lvw_mods.SelectedIndexChanged += new System.EventHandler(this.lvw_mods_SelectedIndexChanged);
            this.lvw_mods.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvw_mods_DragDrop);
            this.lvw_mods.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvw_mods_DragEnter);
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(3, 74);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(65, 23);
            this.btn_play.TabIndex = 2;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // gpb_assembly
            // 
            this.gpb_assembly.Controls.Add(this.lvw_assembly);
            this.gpb_assembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpb_assembly.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpb_assembly.Location = new System.Drawing.Point(0, 0);
            this.gpb_assembly.Name = "gpb_assembly";
            this.gpb_assembly.Size = new System.Drawing.Size(593, 189);
            this.gpb_assembly.TabIndex = 2;
            this.gpb_assembly.TabStop = false;
            this.gpb_assembly.Text = "Assembly Patches";
            // 
            // lvw_assembly
            // 
            this.lvw_assembly.AllowDrop = true;
            this.lvw_assembly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw_assembly.CheckBoxes = true;
            this.lvw_assembly.GridLines = true;
            this.lvw_assembly.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_assembly.HideSelection = false;
            this.lvw_assembly.Location = new System.Drawing.Point(7, 20);
            this.lvw_assembly.Name = "lvw_assembly";
            this.lvw_assembly.Size = new System.Drawing.Size(580, 163);
            this.lvw_assembly.TabIndex = 0;
            this.lvw_assembly.UseCompatibleStateImageBehavior = false;
            this.lvw_assembly.View = System.Windows.Forms.View.List;
            // 
            // pic_gameIcon
            // 
            this.pic_gameIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_gameIcon.Location = new System.Drawing.Point(4, 4);
            this.pic_gameIcon.Name = "pic_gameIcon";
            this.pic_gameIcon.Size = new System.Drawing.Size(64, 64);
            this.pic_gameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_gameIcon.TabIndex = 3;
            this.pic_gameIcon.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 103);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpb_mods);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpb_assembly);
            this.splitContainer1.Size = new System.Drawing.Size(593, 383);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 4;
            // 
            // txt_arguments
            // 
            this.txt_arguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_arguments.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_arguments.Location = new System.Drawing.Point(74, 75);
            this.txt_arguments.Name = "txt_arguments";
            this.txt_arguments.Size = new System.Drawing.Size(517, 22);
            this.txt_arguments.TabIndex = 5;
            this.txt_arguments.Text = "-windowgui -displayconfig";
            // 
            // lbl_currentMod
            // 
            this.lbl_currentMod.AutoSize = true;
            this.lbl_currentMod.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentMod.Location = new System.Drawing.Point(109, 49);
            this.lbl_currentMod.Name = "lbl_currentMod";
            this.lbl_currentMod.Size = new System.Drawing.Size(83, 17);
            this.lbl_currentMod.TabIndex = 6;
            this.lbl_currentMod.Text = "Current mod";
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_currentMod);
            this.Controls.Add(this.txt_arguments);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pic_gameIcon);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.lbl_title);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(600, 489);
            this.gpb_mods.ResumeLayout(false);
            this.gpb_assembly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_gameIcon)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox gpb_mods;
        private System.Windows.Forms.ListView lvw_mods;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.GroupBox gpb_assembly;
        private System.Windows.Forms.ListView lvw_assembly;
        private System.Windows.Forms.PictureBox pic_gameIcon;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_arguments;
        private System.Windows.Forms.Label lbl_currentMod;
    }
}
