namespace DBDiff.Front
{
    partial class ProjectManageForm
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
            this.panelParent = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelCenterTop = new System.Windows.Forms.Panel();
            this.txtObject = new ScintillaNET.Scintilla();
            this.panelCenterBottom = new System.Windows.Forms.Panel();
            this.scintillaLog = new ScintillaNET.Scintilla();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeViewFile = new System.Windows.Forms.TreeView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Exec = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxSelect = new System.Windows.Forms.TextBox();
            this.labelSelect = new System.Windows.Forms.Label();
            this.panelParent.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panelCenterTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObject)).BeginInit();
            this.panelCenterBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintillaLog)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelParent
            // 
            this.panelParent.Controls.Add(this.panelCenter);
            this.panelParent.Controls.Add(this.panelLeft);
            this.panelParent.Controls.Add(this.panelTop);
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParent.Location = new System.Drawing.Point(0, 0);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1284, 761);
            this.panelParent.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.panelCenterTop);
            this.panelCenter.Controls.Add(this.panelCenterBottom);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(300, 60);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(984, 701);
            this.panelCenter.TabIndex = 2;
            // 
            // panelCenterTop
            // 
            this.panelCenterTop.Controls.Add(this.txtObject);
            this.panelCenterTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterTop.Location = new System.Drawing.Point(0, 0);
            this.panelCenterTop.Name = "panelCenterTop";
            this.panelCenterTop.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelCenterTop.Size = new System.Drawing.Size(984, 541);
            this.panelCenterTop.TabIndex = 2;
            // 
            // txtObject
            // 
            this.txtObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObject.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObject.Location = new System.Drawing.Point(5, 0);
            this.txtObject.Name = "txtObject";
            this.txtObject.Size = new System.Drawing.Size(974, 536);
            this.txtObject.Styles.BraceBad.Size = 9F;
            this.txtObject.Styles.BraceLight.Size = 9F;
            this.txtObject.Styles.ControlChar.Size = 9F;
            this.txtObject.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.txtObject.Styles.Default.Size = 9F;
            this.txtObject.Styles.IndentGuide.Size = 9F;
            this.txtObject.Styles.LastPredefined.Size = 9F;
            this.txtObject.Styles.LineNumber.Size = 9F;
            this.txtObject.Styles.Max.Size = 9F;
            this.txtObject.TabIndex = 2;
            // 
            // panelCenterBottom
            // 
            this.panelCenterBottom.Controls.Add(this.scintillaLog);
            this.panelCenterBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCenterBottom.Location = new System.Drawing.Point(0, 541);
            this.panelCenterBottom.Name = "panelCenterBottom";
            this.panelCenterBottom.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelCenterBottom.Size = new System.Drawing.Size(984, 160);
            this.panelCenterBottom.TabIndex = 1;
            // 
            // scintillaLog
            // 
            this.scintillaLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scintillaLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintillaLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scintillaLog.Location = new System.Drawing.Point(5, 0);
            this.scintillaLog.Name = "scintillaLog";
            this.scintillaLog.Size = new System.Drawing.Size(974, 155);
            this.scintillaLog.Styles.BraceBad.Size = 9F;
            this.scintillaLog.Styles.BraceLight.Size = 9F;
            this.scintillaLog.Styles.ControlChar.Size = 9F;
            this.scintillaLog.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintillaLog.Styles.Default.Size = 9F;
            this.scintillaLog.Styles.IndentGuide.Size = 9F;
            this.scintillaLog.Styles.LastPredefined.Size = 9F;
            this.scintillaLog.Styles.LineNumber.Size = 9F;
            this.scintillaLog.Styles.Max.Size = 9F;
            this.scintillaLog.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.panel2);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 60);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelLeft.Size = new System.Drawing.Size(300, 701);
            this.panelLeft.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.treeViewFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 696);
            this.panel2.TabIndex = 0;
            // 
            // treeViewFile
            // 
            this.treeViewFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFile.Location = new System.Drawing.Point(0, 0);
            this.treeViewFile.Name = "treeViewFile";
            this.treeViewFile.Size = new System.Drawing.Size(288, 694);
            this.treeViewFile.TabIndex = 0;
            this.treeViewFile.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeViewFile_DrawNode);
            this.treeViewFile.DoubleClick += new System.EventHandler(this.treeViewFile_DoubleClick);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(5);
            this.panelTop.Size = new System.Drawing.Size(1284, 60);
            this.panelTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_Exec);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.textBoxSelect);
            this.panel1.Controls.Add(this.labelSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 50);
            this.panel1.TabIndex = 0;
            // 
            // btn_Exec
            // 
            this.btn_Exec.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exec.Image = global::DBDiff.Properties.Resources.database_yellow;
            this.btn_Exec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exec.Location = new System.Drawing.Point(1163, 8);
            this.btn_Exec.Name = "btn_Exec";
            this.btn_Exec.Size = new System.Drawing.Size(103, 30);
            this.btn_Exec.TabIndex = 0;
            this.btn_Exec.Text = "   执行脚本";
            this.btn_Exec.UseVisualStyleBackColor = false;
            this.btn_Exec.Click += new System.EventHandler(this.btn_Exec_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelect.Image = global::DBDiff.Properties.Resources.folder;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(693, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(104, 30);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "   选择文件夹";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxSelect
            // 
            this.textBoxSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxSelect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSelect.Location = new System.Drawing.Point(121, 11);
            this.textBoxSelect.Name = "textBoxSelect";
            this.textBoxSelect.ReadOnly = true;
            this.textBoxSelect.Size = new System.Drawing.Size(566, 26);
            this.textBoxSelect.TabIndex = 1;
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.Location = new System.Drawing.Point(18, 17);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(101, 12);
            this.labelSelect.TabIndex = 0;
            this.labelSelect.Text = "请选择项目路径：";
            // 
            // FormProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.panelParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProject";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理";
            this.panelParent.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panelCenterTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtObject)).EndInit();
            this.panelCenterBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintillaLog)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelCenterBottom;
        private System.Windows.Forms.Panel panelCenterTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.TextBox textBoxSelect;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TreeView treeViewFile;
        private System.Windows.Forms.Button btn_Exec;
        private ScintillaNET.Scintilla txtObject;
        private ScintillaNET.Scintilla scintillaLog;
    }
}