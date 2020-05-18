using System.ComponentModel;
using System.Windows.Forms;
using ScintillaNET;

namespace DBDiff.Front
{
    partial class PrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.lblMessage = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtNewObject = new ScintillaNET.Scintilla();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtOldObject = new ScintillaNET.Scintilla();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtDiff = new ScintillaNET.Scintilla();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.schemaTreeView1 = new DBDiff.Front.SchemaTreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSyncScript = new ScintillaNET.Scintilla();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.scintillaLog = new ScintillaNET.Scintilla();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdateAll = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.PanelGlobal = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonOptimize = new System.Windows.Forms.Button();
            this.btn_ProjectManage = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonInit = new System.Windows.Forms.Button();
            this.PanelDestination = new System.Windows.Forms.Panel();
            this.PanelSource = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnSaveProject = new System.Windows.Forms.Button();
            this.btnCompareTableData = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewObject)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldObject)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiff)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyncScript)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintillaLog)).BeginInit();
            this.PanelGlobal.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(6, 487);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 12);
            this.lblMessage.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(7, 161);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1173, 596);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1165, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "模式";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(350, 46);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(808, 521);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtNewObject);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(800, 495);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "参考对象";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtNewObject
            // 
            this.txtNewObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewObject.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewObject.Location = new System.Drawing.Point(3, 3);
            this.txtNewObject.Name = "txtNewObject";
            this.txtNewObject.Size = new System.Drawing.Size(794, 489);
            this.txtNewObject.Styles.BraceBad.Size = 9F;
            this.txtNewObject.Styles.BraceLight.Size = 9F;
            this.txtNewObject.Styles.ControlChar.Size = 9F;
            this.txtNewObject.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewObject.Styles.Default.Size = 9F;
            this.txtNewObject.Styles.IndentGuide.Size = 9F;
            this.txtNewObject.Styles.LastPredefined.Size = 9F;
            this.txtNewObject.Styles.LineNumber.Size = 9F;
            this.txtNewObject.Styles.Max.Size = 9F;
            this.txtNewObject.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtOldObject);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(800, 495);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "目标对象";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtOldObject
            // 
            this.txtOldObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOldObject.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldObject.Location = new System.Drawing.Point(3, 3);
            this.txtOldObject.Name = "txtOldObject";
            this.txtOldObject.Size = new System.Drawing.Size(794, 489);
            this.txtOldObject.Styles.BraceBad.Size = 9F;
            this.txtOldObject.Styles.BraceLight.Size = 9F;
            this.txtOldObject.Styles.ControlChar.Size = 9F;
            this.txtOldObject.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldObject.Styles.Default.Size = 9F;
            this.txtOldObject.Styles.IndentGuide.Size = 9F;
            this.txtOldObject.Styles.LastPredefined.Size = 9F;
            this.txtOldObject.Styles.LineNumber.Size = 9F;
            this.txtOldObject.Styles.Max.Size = 9F;
            this.txtOldObject.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtDiff);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(800, 495);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "比较差异";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtDiff
            // 
            this.txtDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiff.Location = new System.Drawing.Point(0, 0);
            this.txtDiff.Name = "txtDiff";
            this.txtDiff.Size = new System.Drawing.Size(800, 495);
            this.txtDiff.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(350, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(809, 37);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "已删除的数据";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "已改变的数据";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "新创建的数据";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(305, 11);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(32, 19);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Blue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(160, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 19);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lime;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(10, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 19);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.schemaTreeView1);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 561);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // schemaTreeView1
            // 
            this.schemaTreeView1.DatabaseDestination = null;
            this.schemaTreeView1.DatabaseSource = null;
            this.schemaTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schemaTreeView1.Location = new System.Drawing.Point(3, 17);
            this.schemaTreeView1.Name = "schemaTreeView1";
            this.schemaTreeView1.ShowChangedItems = true;
            this.schemaTreeView1.ShowMissingItems = true;
            this.schemaTreeView1.ShowNewItems = true;
            this.schemaTreeView1.ShowUnchangedItems = false;
            this.schemaTreeView1.Size = new System.Drawing.Size(329, 541);
            this.schemaTreeView1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSyncScript);
            this.tabPage1.Controls.Add(this.lblMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1165, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "同步脚本";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSyncScript
            // 
            this.txtSyncScript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSyncScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSyncScript.IsReadOnly = true;
            this.txtSyncScript.Location = new System.Drawing.Point(3, 3);
            this.txtSyncScript.Name = "txtSyncScript";
            this.txtSyncScript.Size = new System.Drawing.Size(1159, 564);
            this.txtSyncScript.Styles.LineNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtSyncScript.Styles.LineNumber.IsVisible = false;
            this.txtSyncScript.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.scintillaLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1165, 570);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "操作日志";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // scintillaLog
            // 
            this.scintillaLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scintillaLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintillaLog.IsReadOnly = true;
            this.scintillaLog.LineWrapping.Mode = ScintillaNET.LineWrappingMode.Word;
            this.scintillaLog.Location = new System.Drawing.Point(3, 3);
            this.scintillaLog.Name = "scintillaLog";
            this.scintillaLog.Size = new System.Drawing.Size(1159, 564);
            this.scintillaLog.Styles.LineNumber.BackColor = System.Drawing.Color.Transparent;
            this.scintillaLog.Styles.LineNumber.IsVisible = false;
            this.scintillaLog.TabIndex = 6;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "sql";
            this.saveFileDialog1.Filter = "SQL File|*.sql";
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Image = global::DBDiff.Properties.Resources.setting_tools;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOptions.Location = new System.Drawing.Point(1184, 238);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(95, 51);
            this.btnOptions.TabIndex = 5;
            this.btnOptions.Text = "选项";
            this.btnOptions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Enabled = false;
            this.btnCopy.Image = global::DBDiff.Properties.Resources.clipboard_invoice;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopy.Location = new System.Drawing.Point(1184, 351);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(95, 51);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "复制脚本";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Image = global::DBDiff.Properties.Resources.refresh_all;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdate.Location = new System.Drawing.Point(1184, 407);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 51);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "更新部分";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateAll.Enabled = false;
            this.btnUpdateAll.Image = global::DBDiff.Properties.Resources.database_refresh;
            this.btnUpdateAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdateAll.Location = new System.Drawing.Point(1183, 702);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(95, 51);
            this.btnUpdateAll.TabIndex = 10;
            this.btnUpdateAll.Text = "更新全部";
            this.btnUpdateAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdateAll.UseVisualStyleBackColor = true;
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAs.Enabled = false;
            this.btnSaveAs.Image = global::DBDiff.Properties.Resources.save_as;
            this.btnSaveAs.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveAs.Location = new System.Drawing.Point(1184, 294);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(95, 51);
            this.btnSaveAs.TabIndex = 6;
            this.btnSaveAs.Text = "另存为";
            this.btnSaveAs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Image = global::DBDiff.Properties.Resources.compare;
            this.btnCompare.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompare.Location = new System.Drawing.Point(1184, 182);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(95, 51);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "比较";
            this.btnCompare.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // PanelGlobal
            // 
            this.PanelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelGlobal.BackColor = System.Drawing.Color.White;
            this.PanelGlobal.Controls.Add(this.panel2);
            this.PanelGlobal.Controls.Add(this.PanelDestination);
            this.PanelGlobal.Controls.Add(this.PanelSource);
            this.PanelGlobal.Controls.Add(this.panel1);
            this.PanelGlobal.Location = new System.Drawing.Point(0, 0);
            this.PanelGlobal.Name = "PanelGlobal";
            this.PanelGlobal.Size = new System.Drawing.Size(1281, 155);
            this.PanelGlobal.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Location = new System.Drawing.Point(946, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(326, 150);
            this.panel2.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(10, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(304, 128);
            this.panel6.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonBackup, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonOptimize, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_ProjectManage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSelect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonInit, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 128);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonBackup
            // 
            this.buttonBackup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackup.Image = global::DBDiff.Properties.Resources.database_yellow;
            this.buttonBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackup.Location = new System.Drawing.Point(155, 87);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(146, 38);
            this.buttonBackup.TabIndex = 19;
            this.buttonBackup.Text = "5.备份数据库";
            this.buttonBackup.UseVisualStyleBackColor = false;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonOptimize
            // 
            this.buttonOptimize.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonOptimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOptimize.Image = global::DBDiff.Properties.Resources.database_yellow;
            this.buttonOptimize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOptimize.Location = new System.Drawing.Point(3, 87);
            this.buttonOptimize.Name = "buttonOptimize";
            this.buttonOptimize.Size = new System.Drawing.Size(146, 38);
            this.buttonOptimize.TabIndex = 18;
            this.buttonOptimize.Text = "4.优化数据库";
            this.buttonOptimize.UseVisualStyleBackColor = false;
            this.buttonOptimize.Click += new System.EventHandler(this.buttonOptimize_Click);
            // 
            // btn_ProjectManage
            // 
            this.btn_ProjectManage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_ProjectManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ProjectManage.Image = global::DBDiff.Properties.Resources.folder;
            this.btn_ProjectManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ProjectManage.Location = new System.Drawing.Point(3, 3);
            this.btn_ProjectManage.Name = "btn_ProjectManage";
            this.btn_ProjectManage.Size = new System.Drawing.Size(146, 36);
            this.btn_ProjectManage.TabIndex = 13;
            this.btn_ProjectManage.Text = "   [高级]项目脚本管理";
            this.btn_ProjectManage.UseVisualStyleBackColor = false;
            this.btn_ProjectManage.Click += new System.EventHandler(this.btn_ProjectManage_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Image = global::DBDiff.Properties.Resources.database_yellow;
            this.buttonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClear.Location = new System.Drawing.Point(155, 45);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(146, 36);
            this.buttonClear.TabIndex = 17;
            this.buttonClear.Text = "3.清理数据库";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSelect.Image = global::DBDiff.Properties.Resources.folder;
            this.buttonSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelect.Location = new System.Drawing.Point(155, 3);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(146, 36);
            this.buttonSelect.TabIndex = 15;
            this.buttonSelect.Text = "1.选择文件夹";
            this.buttonSelect.UseVisualStyleBackColor = false;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonInit
            // 
            this.buttonInit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInit.Image = global::DBDiff.Properties.Resources.database_yellow;
            this.buttonInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonInit.Location = new System.Drawing.Point(3, 45);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(146, 36);
            this.buttonInit.TabIndex = 16;
            this.buttonInit.Text = "2.初始化数据库";
            this.buttonInit.UseVisualStyleBackColor = false;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // PanelDestination
            // 
            this.PanelDestination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelDestination.Location = new System.Drawing.Point(553, 3);
            this.PanelDestination.Name = "PanelDestination";
            this.PanelDestination.Size = new System.Drawing.Size(386, 150);
            this.PanelDestination.TabIndex = 11;
            // 
            // PanelSource
            // 
            this.PanelSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelSource.Location = new System.Drawing.Point(161, 3);
            this.PanelSource.Name = "PanelSource";
            this.PanelSource.Size = new System.Drawing.Size(386, 150);
            this.PanelSource.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnNewProject);
            this.panel1.Controls.Add(this.btnProject);
            this.panel1.Controls.Add(this.btnSaveProject);
            this.panel1.Location = new System.Drawing.Point(7, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 150);
            this.panel1.TabIndex = 16;
            // 
            // btnNewProject
            // 
            this.btnNewProject.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNewProject.Image = global::DBDiff.Properties.Resources.new_window;
            this.btnNewProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewProject.Location = new System.Drawing.Point(16, 60);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(113, 30);
            this.btnNewProject.TabIndex = 15;
            this.btnNewProject.Text = "新建项目";
            this.btnNewProject.UseVisualStyleBackColor = false;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnProject
            // 
            this.btnProject.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProject.Image = global::DBDiff.Properties.Resources.folder;
            this.btnProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProject.Location = new System.Drawing.Point(16, 16);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(113, 30);
            this.btnProject.TabIndex = 12;
            this.btnProject.Text = "打开项目";
            this.btnProject.UseVisualStyleBackColor = false;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveProject.Image = global::DBDiff.Properties.Resources.diskette;
            this.btnSaveProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveProject.Location = new System.Drawing.Point(16, 104);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(113, 30);
            this.btnSaveProject.TabIndex = 13;
            this.btnSaveProject.Text = "保存项目";
            this.btnSaveProject.UseVisualStyleBackColor = false;
            this.btnSaveProject.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCompareTableData
            // 
            this.btnCompareTableData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompareTableData.Enabled = false;
            this.btnCompareTableData.Image = global::DBDiff.Properties.Resources.table_analysis;
            this.btnCompareTableData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompareTableData.Location = new System.Drawing.Point(1184, 463);
            this.btnCompareTableData.Name = "btnCompareTableData";
            this.btnCompareTableData.Size = new System.Drawing.Size(95, 51);
            this.btnCompareTableData.TabIndex = 9;
            this.btnCompareTableData.Text = "比较数据";
            this.btnCompareTableData.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompareTableData.UseVisualStyleBackColor = true;
            this.btnCompareTableData.Visible = false;
            this.btnCompareTableData.Click += new System.EventHandler(this.btnCompareTableData_Click);
            // 
            // PrincipalForm
            // 
            this.AcceptButton = this.btnCompare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.PanelGlobal);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCompareTableData);
            this.Controls.Add(this.btnUpdateAll);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrincipalForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库对比工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewObject)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOldObject)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDiff)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyncScript)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintillaLog)).EndInit();
            this.PanelGlobal.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblMessage;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnCompare;
        private Button btnSaveAs;
        private SaveFileDialog saveFileDialog1;
        private Button btnCopy;
        private Button btnUpdate;
        private Button btnUpdateAll;
        private Button btnOptions;
        private TabPage tabPage2;
        private Panel PanelGlobal;
        private Panel PanelSource;
        private Panel PanelDestination;
        private GroupBox groupBox2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private Label label3;
        private Label label2;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Scintilla txtNewObject;
        private Scintilla txtOldObject;
        private Button btnSaveProject;
        private Button btnProject;
        private Button btnNewProject;
        private Button btnCompareTableData;
        private TabPage tabPage6;
        private Scintilla txtDiff;
        private GroupBox groupBox1;
        private SchemaTreeView schemaTreeView1;
        private Scintilla txtSyncScript;
        private Panel panel1;
        private Panel panel2;
        private Button buttonSelect;
        private Panel panel6;
        private Button buttonInit;
        private Button btn_ProjectManage;
        private Button buttonClear;
        private Button buttonOptimize;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonBackup;
        private TabPage tabPage3;
        private Scintilla scintillaLog;
    }
}
